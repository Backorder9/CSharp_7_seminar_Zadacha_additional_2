/* Дополнительно 2:
3: Дана матрица целых чисел размером n*m. Выведите
количество седловых точек. (Седловой точкой называется
элемент, который является наименьшим в своей строке и
наибольшим в своём столбце или, наоборот, наибольшим в
своей строке и наименьшим в своём столбце).
3 4 - размерность
7 1 5 3
3 2 6 4  -> 2
5 2 8 6
*/

int FindSaddlePoints(int[,] arr)
{
    int l_result = 0;
    int i; int j; int index;
    int N = arr.GetLength(0);
    int M = arr.GetLength(1);
    int[] l_row = new int[M];
    int[] l_column = new int[N];
 
    for (i = 0; i < N; i++)
    {
        index = 0;
        for (j = 1; j < M; j++)
        {
            if (arr[i, j] < arr[i, index])
            {
                index = j;
            }
        }
        l_column[i] = index;
    }

    for (j = 0; j < M; j++)
    {
        index = 0;

        //find the max
        for (i = 1; i < N; i++)
        {
            if (arr[i, j] > arr[index, j])
            {
                index = i;
            }
        }
        l_row[j] = index;
    }

    for (i = 0; i < N; i++)
    {
        for (j = 0; j < M; j++)
        {
            if (l_row[j] == i && l_column[i] == j && i != N && j != M)
            {
                l_result++;
            }
        }
    }

    return l_result;
}

int[,] ddd =    {{1,2,0,3,9,4,5,3,6,7},
                 {2,4,3,5,9,0,2,3,4,1},
                 {5,3,4,7,6,1,9,0,4,2},
                 {6,9,7,8,6,7,7,4,5,6},
                 {8,3,1,9,2,0,6,2,8,2},
                 {2,7,3,0,3,6,3,1,5,3},
                 {8,2,5,9,7,7,8,3,7,3},
                 {1,7,4,8,5,8,5,0,0,6}};
int num = FindSaddlePoints(ddd);
System.Console.WriteLine($"Количество седловых точек: {num}.");