Console.WriteLine("Input number of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Input number of columns: ");
int columns = Convert.ToInt32(Console.ReadLine());

int[,] myArray = Create2DMatrix(rows, columns);
Console.WriteLine();
Console.WriteLine("Initial array: ");
Print2DArray(myArray);
Print2DArray(NullInRowAndColCrossingOnMinValue(myArray));
LastFirst(myArray);
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

int[,] NullInRowAndColCrossingOnMinValue(int[,] array)
{
    int[,] nullArray = new int[array.GetLength(0), array.GetLength(1)]; // Создаем не ссылку, а новый массив!!!
    Array.Copy(array, nullArray, array.Length);                         // Копируем содержимое массива array в nullArray
    int min = nullArray[0, 0];
    int minCoordRow = 0;
    int minCoordCol = 0;
    int countMins = 0;

    // Find minimal value
    for(int i = 0; i < nullArray.GetLength(0); i++) for(int j = 0; j < nullArray.GetLength(1); j++) if (min >= array[i, j]) min = array[i, j];
    Console.WriteLine($"Minimal value is: {min}");

    // Find coordinates of all minimals value in array
    for(int i = 0; i < nullArray.GetLength(0); i++)
    {
        for(int j = 0; j < nullArray.GetLength(1); j++)
        {
            if (min == array[i, j])
            {
                minCoordRow = i;
                minCoordCol = j;
                countMins++;
                Console.WriteLine();
                Console.WriteLine($"Coords of minimals: min number {countMins} - r: {minCoordRow}, c:{minCoordCol}");
                 // Зануление строки
                for(int k = 0; k < nullArray.GetLength(1); k++) nullArray[minCoordRow, k] = 0;
                // Зануление столбцов
                for(int r = 0; r < nullArray.GetLength(0); r++) nullArray[r, minCoordCol] = 0;
            }          
        }
    }
    Console.WriteLine();
    Console.WriteLine($"Number of minimals: {countMins}");
    Console.WriteLine();
    Console.WriteLine("Your nulled array: ");
    return nullArray;
}

void LastFirst(int[,] array)
{
    int memory;
    for(int j = 0; j < array.GetLength(1); j++)
    {
        memory = array[0, j];
        array[0, j] = array[array.GetLength(0)-1, j];
        array[array.GetLength(0)-1, j] = memory;
    }
    Console.WriteLine();
    Console.WriteLine($"Last to first and first to last rows:");
    Print2DArray(array);
}

