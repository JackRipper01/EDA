namespace Binary_Tree_Structure;

public class Binary_Tree<T> where T : IComparable
{
    public T Key { get; set; }
    public int BalanceFactor { get; set; }
    public int Height { get; set; }
    public Binary_Tree<T>? Father;
    public Binary_Tree<T>? Left;
    public Binary_Tree<T>? Right;

    public Binary_Tree(T key, Binary_Tree<T> father)
    {
        Key = key;
        BalanceFactor = 0;
        Height = 0;
        Father = father;
    }
    public Binary_Tree(T key, Binary_Tree<T> left, Binary_Tree<T> right, Binary_Tree<T> father)
    {
        Key = key;
        Left = left;
        Right = right;
        Father = father;
        BalanceFactor = right.Height - left.Height;
    }

    private int Update_Children_Height_BF()
    {
        // if (Left != null)
        //     Left.Height = Left.Get_Height();
        // if (Right != null)
        //     Right.Height = Right.Get_Height();
        // if (Right != null && Left != null)
        // { Height = Math.Max(Left.Height, Right.Height); }
        // else if (Right != null)
        //     Height = Right.Height + 1;
        // else if (Left != null)
        //     Height = Left.Height + 1;

        Height = Math.Max(Right != null ? Right.Update_Children_Height_BF() : -1, Left != null ? Left.Update_Children_Height_BF() : -1) + 1;
        Update_Balance_Factor();
        return Height;
    }
    private void Update_Fathers_Height_BF()
    {
        if (Left != null && Right != null)
            Height = Math.Max(Left.Height, Right.Height) + 1;
        else if (Left != null)
            Height = 1 + Left.Height;
        else if (Right != null)
            Height = Right.Height + 1;
        else
            Height = 0;
        Update_Balance_Factor();
        if (Father != null && Father.Father != null)
            Father.Update_Fathers_Height_BF();
    }
    private void Update_Balance_Factor()
    {
        if (Left != null && Right != null)
            BalanceFactor = Right.Height - Left.Height;
        else if (Left != null)
            BalanceFactor = -1 - Left.Height;
        else if (Right != null)
            BalanceFactor = Right.Height - (-1);
        else
            BalanceFactor = 0;
    }
    private void Update_Height()
    {
        if (Left != null && Right != null)
            Height = Math.Max(Left.Height, Right.Height) + 1;
        else if (Left != null)
            Height = Left.Height + 1;
        else if (Right != null)
            Height = Right.Height + 1;
    }

    private int Get_Height()
    {
        int resultA = 0;
        int resultB = 0;
        if (Left != null)
            resultA += 1 + Left.Get_Height();
        if (Right != null)
            resultB += 1 + Right.Get_Height();
        return Math.Max(resultA, resultB);
    }
    public void Insert(T entry)
    {
        if (entry.CompareTo(Key) == 0)
            return;
        if (entry.CompareTo(Key) == -1)
        {
            if (Left == null)
                Left = new Binary_Tree<T>(entry, this);
            else
                Left.Insert(entry);
        }
        else if (entry.CompareTo(Key) == 1)
        {
            if (Right == null)
                Right = new Binary_Tree<T>(entry, this);
            else
                Right.Insert(entry);
        }
    }
    public void Eliminate(T entry)
    {
        if (Left != null && Left.Key.CompareTo(entry) == 0)
        {
            if (IsLeaf(Left))
                Left = null;
            else if (HasOneChildren(Left))
                Left = GetOnlyChildren(Left);
            else
            {
                Left = GetLargestMinor(Left);
            }
        }
        else if (Right != null && Right.Key.CompareTo(entry) == 0)
        {
            if (IsLeaf(Right))
                Right = null;
            else if (HasOneChildren(Right))
                Right = GetOnlyChildren(Right);
            else
            {
                Right = GetLargestMinor(Right);
            }
        }
        else
        {
            if (Left != null && entry.CompareTo(Key) == -1)
                Left.Eliminate(entry);
            else if (Right != null && entry.CompareTo(Key) == 1)
                Right.Eliminate(entry);
        }
        return;
    }

    public static Binary_Tree<int> Create_Binary_Tree(int[] array)
    {
        Binary_Tree<int> result = new Binary_Tree<int>(int.MaxValue, null);
        for (int i = 0; i < array.Length; i++)
        {
            result.Insert(array[i]);
        }
        return result;
    }
    bool IsLeaf(Binary_Tree<T> node) => node.Left == null && node.Right == null;
    bool HasOneChildren(Binary_Tree<T> node) => (node.Left != null && node.Right == null) || (node.Left == null && node.Right != null);
    Binary_Tree<T> GetOnlyChildren(Binary_Tree<T> node)
    {
        if (node.Left != null)
            return node.Left;
        else if (node.Right != null)
            return node.Right;
        throw new Exception(message: "empty node");
    }
    Binary_Tree<T> GetLargestMinor(Binary_Tree<T> node)
    {
        if (node.Left == null && node.Right != null)
            return node.Right;
        else if (node.Left != null)
        {
            return GetLargestMinor(node.Left);
        }
        throw new Exception();
    }

    ////////// AVL MODE /////////
    public static Binary_Tree<int> Create_AVL(int[] array)
    {
        Binary_Tree<int> result = new Binary_Tree<int>(int.MaxValue, null);
        for (int i = 0; i < array.Length; i++)
        {
            result.Insert_AVLmode(array[i]);
            // updaate all altura y fb
            result.Update_Children_Height_BF();
        }
        return result;
    }
    public void Insert_AVLmode(T entry)
    {
        Binary_Tree<T> father = Insert_and_Get_Father(entry);
        if (father == null)
            return;

        int H_before = father.Height;
        father.Update_Height();
        int h_after = father.Height;

        if (H_before == h_after)
        {
            father.Update_Balance_Factor();
            return;
        }


        int BF_before = father.BalanceFactor;
        father.Update_Balance_Factor();
        int BF_after = father.BalanceFactor;

        if (BF_after == 0)
            return;
        else
        {
            if (entry.CompareTo(3) == 0)
            { }
            Going_Back_In_The_Track(father);
        }
        return;
    }
    private void Going_Back_In_The_Track(Binary_Tree<T> actual_node)
    {
        if (actual_node.Father == null || actual_node.Father.Father == null)
            return;

        actual_node.Father.Update_Balance_Factor();
        actual_node.Father.Update_Height();
        if (actual_node.Father.BalanceFactor == 0)
            return;

        if ((actual_node.Father.BalanceFactor == -1 || actual_node.Father.BalanceFactor == 1))
        {
            Going_Back_In_The_Track(actual_node.Father);
        }
        else
        {
            if (actual_node.Father.BalanceFactor >= 2)
            {
                if (actual_node.BalanceFactor == 1)
                {
                    //shift_left
                    Shift_Left(actual_node);
                    if (actual_node.Left != null)
                        actual_node.Left.Update_Fathers_Height_BF();
                }
                else if (actual_node.BalanceFactor == -1)
                {
                    //double_shift_rigth
                    Double_Shift_Right(actual_node);
                    if (actual_node.Right != null)
                        actual_node.Right.Update_Fathers_Height_BF();

                }
            }
            else if (actual_node.Father.BalanceFactor <= -2)
            {
                if (actual_node.BalanceFactor == -1)
                {
                    //shift_rigth
                    Shift_Rigth(actual_node);
                    if (actual_node.Right != null)
                        actual_node.Right.Update_Fathers_Height_BF();
                }
                else if (actual_node.BalanceFactor == 1)
                {
                    //double_shift_left
                    Double_Shift_Left(actual_node);
                    if (actual_node.Left != null)
                        actual_node.Left.Update_Fathers_Height_BF();
                }
            }
            return;
        }
    }
    private void Shift_Left(Binary_Tree<T> actual_node)
    {
        if (actual_node.Father == null || actual_node.Father.Father == null)
            return;
        //analizar direccion de father.father(es Left or Right ?)
        Binary_Tree<T> temp = actual_node.Father; //guardo el nodo A

        if (actual_node.Father.Father != null)
        {
            if (actual_node.Father.Father.Key.CompareTo(actual_node.Key) < 0)
            {
                actual_node.Father.Father.Right = actual_node;
                actual_node.Father = actual_node.Father.Father;//pongo el nodo B en donde va

            }
            else
            {

                actual_node.Father.Father.Left = actual_node;
                actual_node.Father = actual_node.Father.Father;

            }
        }
        else
            actual_node.Father = null;

        temp.Right = actual_node.Left;//le asigno el hijo isquierdo de B como hijo derecho a A
        if (actual_node.Left != null)
            actual_node.Left.Father = temp;

        actual_node.Left = temp; // pongo A en nodo isquierdo de B
        temp.Father = actual_node;
    }
    private void Shift_Rigth(Binary_Tree<T> actual_node)//nodo actual es B
    {
        if (actual_node.Father == null || actual_node.Father.Father == null)
            return;
        //analizar direccion de father.father(es Left or Right ?)
        Binary_Tree<T> temp = actual_node.Father; //guardo el nodo A

        if (actual_node.Father.Father != null)
        {
            if (actual_node.Father.Father.Key.CompareTo(actual_node.Key) > 0)
            {
                actual_node.Father.Father.Left = actual_node;
                actual_node.Father = actual_node.Father.Father;//pongo el nodo B en donde va

            }
            else
            {
                actual_node.Father.Father.Right = actual_node;
                actual_node.Father = actual_node.Father.Father;

            }
        }
        else
            actual_node.Father = null;
        temp.Left = actual_node.Right;//le asigno el hijo derecho de B a A
        if (actual_node.Right != null)
            actual_node.Right.Father = temp;

        actual_node.Right = temp; // pongo A en nodo derecho de B
        temp.Father = actual_node;
    }
    private void Double_Shift_Left(Binary_Tree<T> actual_node)
    {
        Shift_Left(actual_node.Right);
        Shift_Rigth(actual_node.Father);

    }
    private void Double_Shift_Right(Binary_Tree<T> actual_node)
    {
        Shift_Rigth(actual_node.Left);
        Shift_Left(actual_node.Father);
    }
    private Binary_Tree<T> Insert_and_Get_Father(T entry)
    {
        if (entry.CompareTo(Key) == 0)
            return null;
        if (entry.CompareTo(Key) < 0)
        {
            if (Left == null)
            {
                Left = new Binary_Tree<T>(entry, this);
                return this;
            }
            else
                return Left.Insert_and_Get_Father(entry);
        }
        else if (entry.CompareTo(Key) > 0)
        {
            if (Right == null)
            {
                Right = new Binary_Tree<T>(entry, this);
                return this;
            }
            else
                return Right.Insert_and_Get_Father(entry);
        }
        throw new Exception(message: "imposible wtf");
    }

    public static Binary_Tree<int> Create_Binary_Tree_From_Sorted_Array_Efficiently(int[] array)
    {
        Binary_Tree<int> result = new Binary_Tree<int>(array[array.Length / 2], null);
        Make_Treee(array, result);
        return result;
    }
    static void Make_Treee(int[] array, Binary_Tree<int> result)
    {
        int[] left_array = array[0..(array.Length / 2)];

        int[] right_array = array[(array.Length / 2 == 1 ? array.Length / 2 : array.Length / 2 + 1)..array.Length];

        if (left_array.Length == 1 && left_array[0] != result.Key)
        {
            result.Left = new Binary_Tree<int>(left_array[0], result);
            return;
        }
        else
            Make_Treee(left_array, result.Left = new Binary_Tree<int>(left_array[left_array.Length / 2], result));

        if (right_array.Length == 1 && right_array[0] != result.Key)
            result.Right = new Binary_Tree<int>(right_array[0], result);
        else
            Make_Treee(right_array, result.Right = new Binary_Tree<int>(right_array[right_array.Length / 2], result));
    }
}