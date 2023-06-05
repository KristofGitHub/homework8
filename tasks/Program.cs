////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("    T  A  S  K    -    1");
Console.WriteLine();
// Запрос ввода пользователем размера матрицы
Console.WriteLine("Input number of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Input number of columns: ");
int columns = Convert.ToInt32(Console.ReadLine());
// Генерация матрицы, ее заполнение
int[,] myArray = Create2DMatrix(rows, columns);
// Печать матрицы
Console.WriteLine();
Console.WriteLine("Initial array: ");
Print2DArray(myArray);
// Сортировка строк матрицы по убыванию
Console.WriteLine("Transformed array: ");
DownStairsFromArray(myArray);
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("    T  A  S  K    -    2");
// Печать матрицы
Console.WriteLine();
Console.WriteLine("Initial array: ");
Print2DArray(myArray);
// Нахождение строки с минимальной суммой элементов
MinSumRowFinder(myArray);
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("    T  A  S  K    -    3");
// Умножать матрицы можно только тогда, когда количество столбцов первой матрицы равно количеству строк второй матрицы.
// матрица 1 уже есть, создаем матрицу 2
Console.WriteLine();
// Генерация матрицы, ее заполнение
int[,] mySecondArray = Create2DMatrix(columns, rows);
// Печать первой матрицы
Console.WriteLine();
Console.WriteLine("A matrix: ");
Print2DArray(myArray);
// Печать первой матрицы
Console.WriteLine("B matrix: ");
Print2DArray(mySecondArray);
AmplifyMatrix(myArray, mySecondArray);
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("    T  A  S  K    -    4");
Console.WriteLine();
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

void DownStairsFromArray(int[,] array)
{
    int temp;
    int k;
    for(int i = 0; i < array.GetLength(0); i++)                     // Цикл проходит по всем строкам вообще
    {
        for(int j = 0; j < array.GetLength(1) - 1; j++)             // Цикл проходит по всем столбцам вообще
        {
            k = j + 1;
            while(k < array.GetLength(1))                           // Цикл проходит по всем столбцам для одной заданной чейки
            {                                                       // чтобы учесть случай, когда в следующей ячейке лежит
                temp = array[i, j];                                 // меньшее значение, чем в текущей.
                if (temp < array[i, k])                             // Отвязка от j с помощью k делается, чтобы сравнить одну ячейку
                {                                                   // со всеми остальными ячейками строки, при этом оставаясь внутри
                    array[i, j] = array[i, k];                      // обоих циклов прохода по всем строкам и столбцам.
                    array[i, k] = temp;
                }
                k++;
            }
        }
    }
    Print2DArray(array);
}

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void MinSumRowFinder(int[,] array)
{
    int minRowSumNumber = 0;
    int minSumRow = 0;
    int sumRow = 0;
    for(int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)         // Цикл суммирования значений ячеек одной (текущей) строки.
        {
            sumRow += array[i, j];                          // Суммируем значения ячеек текущей строки.    
        }
        if (i == 0) minSumRow = sumRow;                     // При первом проходе скидываем сумму ячеек первой строки в minSumRow.
        else if (minSumRow > sumRow) 
        {
            minSumRow = sumRow;
            minRowSumNumber = i;                            // Фиксируем номер строки с минимальной суммой элементов.
        }
        sumRow = 0;
    }
    Console.WriteLine($"Number of row with minimal sum of elements is {minRowSumNumber} (строка № {minRowSumNumber + 1})");
    Console.WriteLine($"Sum of elements this row is {minSumRow}");
    Console.WriteLine();
}

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void AmplifyMatrix(int[,] arrayA, int[,] arrayB)
{
    int ic = 0;
    int jc = 0;
    int value = 0;
    int[,] arrayC = new int[arrayA.GetLength(0), arrayB.GetLength(1)];
    while(ic < arrayA.GetLength(1))
    {
        for(int i = 0; i < arrayA.GetLength(0); i++)
        {
            for(int j = 0; j < arrayA.GetLength(1); j++)
            {
                value += arrayA[ic, j] * arrayB[j, jc];
                Console.WriteLine($"{arrayA[ic, j]} * {arrayB[j, jc]} + privious term = {value}");
            }
            arrayC[ic, jc] = value;
            Console.WriteLine($"{value}, row {ic}, col {jc}");
            value = 0;
            if(jc < arrayA.GetLength(0)) jc++;
            else jc = 0;
        }
        ic++;
        jc = 0;
    }
    Console.WriteLine();
    Console.WriteLine("Amplifying of A matrix and B matrix give a C-matrix: ");
    Print2DArray(arrayC);
}

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

