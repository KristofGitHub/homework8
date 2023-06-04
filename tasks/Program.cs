Console.WriteLine("Input number of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Input number of columns: ");
int columns = Convert.ToInt32(Console.ReadLine());

int[,] myArray = Create2DMatrix(rows, columns);
Console.WriteLine();
Console.WriteLine("Initial array: ");
Print2DArray(myArray);
// Print2DArray(NullInRowAndColCrossingOnMinValue(myArray));
// LastFirst(myArray);
Console.WriteLine("END");

int[,] Create2DMatrix (int rows, int columns)
{
    int[,] array = new int[rows, columns];
    for(int i = 0; i < rows; i++) for(int j = 0; j < columns; j++) array[i, j] = new Random().Next(1, 100);
    return array;
}

void Print2DArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++) Console.Write(array[i, j] + "\t");
        Console.WriteLine();
    }
    Console.WriteLine();
}

// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



// int[,] NullInRowAndColCrossingOnMinValue(int[,] array)
// {
//     int[,] nullArray = new int[array.GetLength(0), array.GetLength(1)]; // Создаем не ссылку, а новый массив!!!
//     Array.Copy(array, nullArray, array.Length);                         // Копируем содержимое массива array в nullArray
//     int min = nullArray[0, 0];
//     int minCoordRow = 0;
//     int minCoordCol = 0;
//     int countMins = 0;

//     // Find minimal value
//     for(int i = 0; i < nullArray.GetLength(0); i++) for(int j = 0; j < nullArray.GetLength(1); j++) if (min >= array[i, j]) min = array[i, j];
//     Console.WriteLine($"Minimal value is: {min}");

//     // Find coordinates of all minimals value in array
//     for(int i = 0; i < nullArray.GetLength(0); i++)
//     {
//         for(int j = 0; j < nullArray.GetLength(1); j++)
//         {
//             if (min == array[i, j])
//             {
//                 minCoordRow = i;
//                 minCoordCol = j;
//                 countMins++;
//                 Console.WriteLine();
//                 Console.WriteLine($"Coords of minimals: min number {countMins} - r: {minCoordRow}, c:{minCoordCol}");
//                  // Зануление строки
//                 for(int k = 0; k < nullArray.GetLength(1); k++) nullArray[minCoordRow, k] = 0;
//                 // Зануление столбцов
//                 for(int r = 0; r < nullArray.GetLength(0); r++) nullArray[r, minCoordCol] = 0;
//             }          
//         }
//     }
//     Console.WriteLine();
//     Console.WriteLine($"Number of minimals: {countMins}");
//     Console.WriteLine();
//     Console.WriteLine("Your nulled array: ");
//     return nullArray;
// }

// void LastFirst(int[,] array)
// {
//     int memory;
//     for(int j = 0; j < array.GetLength(1); j++)
//     {
//         memory = array[0, j];
//         array[0, j] = array[array.GetLength(0)-1, j];
//         array[array.GetLength(0)-1, j] = memory;
//     }
//     Console.WriteLine();
//     Console.WriteLine($"Last to first and first to last rows:");
//     Print2DArray(array);
// }

