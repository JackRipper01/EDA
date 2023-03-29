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
int[] arrayRegado = { 3, 1, 7, 5, 8, 3, 9, 10, 11, 4, 17, 15, 19, 20 };
int[] arrrray = { 5, 6, 1, 2, 4, 3 };

Binary_Tree<int> test = Binary_Tree<int>.Create_Binary_Tree_From_Sorted_Array_Efficiently(arrrray);



Console.WriteLine("END OF PROGRAM");

