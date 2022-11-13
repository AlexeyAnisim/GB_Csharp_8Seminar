Start();
void Start()
{
    while (true)
    {
        Console.ReadLine();
        Console.Clear();
        System.Console.WriteLine("Задание 1 (введите 1)");
        System.Console.WriteLine("Задание 2 (введите 2)");
        System.Console.WriteLine("Задание 3 (введите 3)");
        System.Console.WriteLine("Задание 4 (введите 4)");
        System.Console.WriteLine("Задание 5 (введите 5)");
        System.Console.WriteLine("End (если введено - 0)");
        int numTask = Convert.ToInt32(Console.ReadLine());

        switch (numTask)
        {
            case 0: return; 
            case 1: SmallestElement(); break;
            case 2: LineSmallestElement(); break;
            case 3: ProductMatr(); break;
            case 4: ArrayNonRepeatingNnumbers(); break;
            case 5: SpiralArray(); break;
            default: System.Console.WriteLine("Ошибка ввода"); break;
        }
    }
}
// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит
// по убыванию элементы каждой строки двумерного массива.

void SmallestElement()
{
Console.Clear();
Console.WriteLine("введите количество строк");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("введите количество столбцов");
int columns = Convert.ToInt32(Console.ReadLine());
int[,] numbers = new int[rows, columns];

FillArrayRandomNumbers(numbers);

Console.WriteLine();
Console.WriteLine("Первоначальный массив: ");

PrintArray(numbers);
// изменение массива
for (int i = 0; i < numbers.GetLength(0); i++)
{
    for (int j = 0; j < numbers.GetLength(1) - 1; j++)
    {
        for (int z = 0; z < numbers.GetLength(1) - 1; z++)
        {
            if (numbers[i, z] < numbers[i, z + 1])
            {
                int temp = 0;
                temp = numbers[i, z];
                numbers[i, z] = numbers[i, z + 1];
                numbers[i, z + 1] = temp;
            }
        }
    }
}
Console.WriteLine();
Console.WriteLine("Новый отсортированный массив");
PrintArray(numbers);

// создание первоначального массива
void FillArrayRandomNumbers(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(-100, 100);
        }
    }
}
// печать массива
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine("");
    }
}
}
// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
void LineSmallestElement()
{
  Console.WriteLine("введите количество строк");
       int rows = Convert.ToInt32(Console.ReadLine());
       Console.WriteLine("введите количество столбцов");
       int columns = Convert.ToInt32(Console.ReadLine());
       int[,] array = new int[rows, columns];
       
       FillArrayRandom(array);
       
       System.Console.WriteLine("Массив:");
       PrintArray(array);
       
       FindMin(SumOfArrayRows(array));
       
       void FillArrayRandom(int[,] array) // заполнение случайными числами
       {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = new Random().Next(-100,100);
            }
        }
        }
        void PrintArray(int[,] array) // печать массива
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    System.Console.Write($"{array[i, j]} ");
                }
                System.Console.WriteLine();
            }
        }
        int[] SumOfArrayRows(int[,] array)
        {
            int[] temp = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
                temp[i] = sum;
            }
            return temp;
        }
        void FindMin(int[] array)
        {
            int index = 0;
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    index = i;
                }
            }
            System.Console.WriteLine($"В строке {index + 1} наименьшая сумма элементов: {min}");
        }   
}
// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить
// произведение двух матриц.
void ProductMatr()
{
    Console.WriteLine("введите количество строк матрицы А");
    int rows1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("введите количество столбцов матрицы А");
    int column1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("введите количество строк матрицы В");
    int rows2 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("введите количество столбцов матрицы В");
    int column2 = Convert.ToInt32(Console.ReadLine());
    int[,] matrixA = new int[rows1, column1];
    int[,] matrixB = new int[rows2, column2];
    int[,] matrixResult = new int[rows1, column2];
    
    if (rows1 != column2)
    {
        Console.WriteLine("Произведение двух матриц найти нельзя");
        return;
    }
    FillArrayRandom(matrixA);
    Console.WriteLine("Матрица A:");
    PrintArray(matrixA);
    Console.WriteLine();
    
    FillArrayRandom(matrixB);
    Console.WriteLine("Матрица B:");
    PrintArray(matrixB);
    Console.WriteLine();
    
    matrixResult = MatrixMultiply(matrixA, matrixB);
    Console.WriteLine("Произведение матриц A x B =");
    Console.WriteLine();
    PrintArray(matrixResult);
    
    int[,] MatrixMultiply(int[,] matrixA, int[,] matrixB)
    {
        for (int i = 0; i < matrixA.GetLength(0); i++)
        {
            for (int j = 0; j < matrixB.GetLength(1); j++)
            {
                for (int n = 0; n < matrixA.GetLength(1); n++)
                {
                    matrixResult[i, j] += matrixA[i, n] * matrixB[n, j];
                }
            }
        }
        return matrixResult;
    }
    void FillArrayRandom(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = new Random().Next(0,10);
            }
        }
    }
    
    void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }   
}
// Задача 60.Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя
// индексы каждого элемента.
void ArrayNonRepeatingNnumbers()
{
    Console.WriteLine("введите размерность массива Х:");
    int arraySizeX = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("введите размерность массива Y:");
    int arraySizeY = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("введите размерность массива Z:");
    int arraySizeZ = Convert.ToInt32(Console.ReadLine());
    int minNumber = 10;
    int maxNumber = 99;
    if (arraySizeX * arraySizeY * arraySizeZ > maxNumber)
    {
        Console.Write("Массив задан неверно");
        return;
    }
    int[,,] matrixArray = new int[arraySizeX, arraySizeY, arraySizeZ];
    Console.Clear();
    
    FillArrayRandomNumber(matrixArray, minNumber, maxNumber);
    PrintArrayWithIdex(matrixArray);
    
    void FillArrayRandomNumber(int[,,] array, int minNumber, int maxNumber)
    {
        Random rand = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(2); k++)
                {
                    while (array[i, j, k] == 0)
                    {
                    int number = rand.Next(minNumber, maxNumber + 1);
                    if (IsNumberInArray(array, number) == false)
                    {
                        array[i, j, k] = number;
                    }
                    }

                }
            }
        }
    }
    bool IsNumberInArray(int[,,] array, int number)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(2); k++)
                {
                    if (array[i, j, k] == number) return true;
                }
            }
        }
        return false;
    }
    
    void PrintArrayWithIdex(int[,,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.WriteLine();
                for (int k = 0; k < array.GetLength(2); k++)
                {
                    Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
                }
            }
        }
    }  
}

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// решение для любого квадратного массива

void SpiralArray()
{
    Console.WriteLine("Введите размер массива");
    int size = Convert.ToInt32(Console.ReadLine());
    int[,] nums = new int[size, size];
    int num = 1;
    int i = 0;
    int j = 0;
    while (num <= size * size)
    {
        nums[i, j] = num;
        if (i <= j + 1 && i + j < size - 1)
        ++j;
        else if (i < j && i + j >= size - 1)
        ++i;
        else if (i >= j && i + j > size - 1)
        --j;
        else
        --i;
        ++num;
    }
    
    PrintArray(nums);
    
    void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine("");
        }
    }
}