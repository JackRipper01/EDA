namespace Binary_Tree_Structure;

public class Binary_Tree<T>
{
    public int Key { get; set; }

    public Binary_Tree<T>? Left;
    public Binary_Tree<T>? Right;

    public Binary_Tree(int key)
    {
        Key = key;

    }
    public Binary_Tree(int key, Binary_Tree<T> left, Binary_Tree<T> right)
    {
        Key = key;
        Left = left;
        Right = right;
    }

}