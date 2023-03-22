// See https://aka.ms/new-console-template for more information
using Binary_Tree_Structure;
Binary_Tree<int> arbol =
new Binary_Tree<int>(1,

    new Binary_Tree<int>(2,

        new Binary_Tree<int>(5),
        new Binary_Tree<int>(4)),

    new Binary_Tree<int>(8,

        new Binary_Tree<int>(7),
        new Binary_Tree<int>(10,
            null,
            new Binary_Tree<int>(11)))

    );
int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

Binary_Tree<int> test = Make_Tree(array);

Console.WriteLine("END OF PROGRAM");
static Binary_Tree<int> Make_Tree(int[] array)
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