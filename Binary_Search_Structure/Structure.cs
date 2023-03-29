namespace Binary_Tree_Structure;

public class Binary_Tree<T> where T : IComparable
{
    public T Key { get; set; }

    public Binary_Tree<T>? Parent;
    public Binary_Tree<T>? Left;
    public Binary_Tree<T>? Right;

    public Binary_Tree(T key)
    {
        Key = key;

    }
    public Binary_Tree(T key, Binary_Tree<T> left, Binary_Tree<T> right)
    {
        Key = key;
        Left = left;
        Right = right;
    }
    public void Insert(T entry)
    {
        if (entry.CompareTo(Key) == 0)
            return;
        if (entry.CompareTo(Key) == -1)
        {
            if (Left == null)
                Left = new Binary_Tree<T>(entry);
            else
                Left.Insert(entry);
        }
        else if (entry.CompareTo(Key) == 1)
        {
            if (Right == null)
                Right = new Binary_Tree<T>(entry);
            else
                Right.Insert(entry);
        }
    }
    public static Binary_Tree<int> Create_Binary_Tree_From_Sorted_Array_Efficiently(int[] array)
    {
        Binary_Tree<int> result = new Binary_Tree<int>(array[array.Length / 2]);
        Make_Treee(array, result);
        return result;
    }
    static void Make_Treee(int[] array, Binary_Tree<int> result)
    {
        int[] left_array = array[0..(array.Length / 2)];

        int[] right_array = array[(array.Length / 2 == 1 ? array.Length / 2 : array.Length / 2 + 1)..array.Length];

        if (left_array.Length == 1 && left_array[0] != result.Key)
        {
            result.Left = new Binary_Tree<int>(left_array[0]);
            return;
        }
        else
            Make_Treee(left_array, result.Left = new Binary_Tree<int>(left_array[left_array.Length / 2]));

        if (right_array.Length == 1 && right_array[0] != result.Key)
            result.Right = new Binary_Tree<int>(right_array[0]);
        else
            Make_Treee(right_array, result.Right = new Binary_Tree<int>(right_array[right_array.Length / 2]));
    }

    //falta avl

    public static Binary_Tree<int> Create_Binary_Tree(int[] array)
    {
        Binary_Tree<int> result = new Binary_Tree<int>(array[0]);
        for (int i = 1; i < array.Length; i++)
        {
            result.Insert(array[i]);
        }
        return result;
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




}