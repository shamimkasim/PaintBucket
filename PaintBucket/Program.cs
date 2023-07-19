using System;

namespace PaintBucket
{
    class Program
    {
        static void Main()
        {
            char[,] image = new char[,]
            {
                { '.', '#', '#', '#', '.', '.' },
                { '.', '#', '.', '.', '#', '.' },
                { '.', '#', '#', '#', '.', '.' },
                { '.', '#', '.', '.', '.', '.' }
            };

            while (true)
            {
                Console.WriteLine("Before:");
                PrintImage(image);

                Console.Write("Enter the row for the paint bucket fill (0-3): ");
                if (!int.TryParse(Console.ReadLine(), out int row) || row < 0 || row >= image.GetLength(0))
                {
                    Console.WriteLine("Invalid row input. Exiting...");
                    break;
                }

                Console.Write("Enter the column for the paint bucket fill (0-5): ");
                if (!int.TryParse(Console.ReadLine(), out int col) || col < 0 || col >= image.GetLength(1))
                {
                    Console.WriteLine("Invalid column input. Exiting...");
                    break;
                }

                Console.Write("Enter the new color character: ");
                char newColor = Console.ReadKey().KeyChar;

                
                Paint(image, row, col, newColor);

                Console.WriteLine("\nAfter:");
                PrintImage(image);

                Console.Write("Do you want to continue (Y/N)? ");
                char response = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (response != 'y')
                    break;
            }
        }

        static void Paint(char[,] image, int row, int col, char newColor)
        {
            char targetColor = image[row, col];
            if (targetColor == newColor || row < 0 || col < 0 || row >= image.GetLength(0) || col >= image.GetLength(1))
                return;

            FillRegion(image, row, col, targetColor, newColor);
        }

        static void FillRegion(char[,] image, int row, int col, char targetColor, char newColor)
        {
            if (row < 0 || col < 0 || row >= image.GetLength(0) || col >= image.GetLength(1) || image[row, col] != targetColor)
                return;

            image[row, col] = newColor;

            FillRegion(image, row - 1, col, targetColor, newColor); 
            FillRegion(image, row + 1, col, targetColor, newColor); 
            FillRegion(image, row, col - 1, targetColor, newColor); 
            FillRegion(image, row, col + 1, targetColor, newColor); 
        }

        static void PrintImage(char[,] image)
        {
            int rows = image.GetLength(0);
            int cols = image.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(image[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
