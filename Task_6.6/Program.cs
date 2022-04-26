using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6._6
{
    class Program
    {

        static int playerScore = 0;

        static void DrawCrocc(int x, int y, int size) // Метод рисует крестик
        {
            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i - j == x - y || i + j == y + x + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("█");
                    }
                }
            }

        }

        static void DrawRectangle(int x, int y, int size) // Метод рисует нолик
        {

            for (int i = x; i <= x + size; i++)
            {
                for (int j = y; j <= y + size; j++)
                {
                    if (i == x || i == x + size || j == y || j == y + size)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("█");
                    }
                }
            }
        }

        static void DrawField(int width, int height, int cellsize) // Метод рисует поле
        {
            for (int y = 0; y <= height; y += cellsize)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }

            for (int x = 0; x <= width; x += cellsize)
            {
                for (int y = 0; y <= height; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("█");
                }
            }

            Console.SetCursorPosition(6, 1); Console.WriteLine("1");

            Console.SetCursorPosition(17, 1); Console.WriteLine("2");

            Console.SetCursorPosition(28, 1); Console.WriteLine("3");

            Console.SetCursorPosition(6, 12); Console.WriteLine("4");

            Console.SetCursorPosition(17, 12); Console.WriteLine("5");

            Console.SetCursorPosition(28, 12); Console.WriteLine("6");

            Console.SetCursorPosition(6, 23); Console.WriteLine("7");

            Console.SetCursorPosition(17, 23); Console.WriteLine("8");

            Console.SetCursorPosition(28, 23); Console.WriteLine("9");
        }

        static void Main(string[] args)

        {
            Console.SetCursorPosition(35, 8);
            Console.Write("Счетчик ходов: ");

            // Базовые настройки и отрисовка поля
            Console.SetWindowSize(90, 34);
            Console.SetBufferSize(90, 34);

            DrawField(33, 33, 11);

            int input;
            int c1, c2, c3, c4, c5, c6, c7, c8, c9; // DrawCross = 0, DrawRectangle = 1, null <= -1
            c1 = -1; c2 = -2; c3 = -3; c4 = -4; c5 = -5; c6 = -6; c7 = -7; c8 = -8; c9 = -9;
            int win = -1;
            int b = 0;

            // Главный цикл игры

            for (int i = 0; i < 9; i++)
            {

                // Пользовательский ввод


                Console.SetCursorPosition(35, 1);
                Console.Write("                                      ");
                Console.SetCursorPosition(35, 1);
                Console.Write("Введите номер клетки: ");

                playerScore += 1; // Счетчик



                // Проверка корректности ввода
                bool errorInput = !int.TryParse(Console.ReadLine(), out input);


                if (input < 1 || input > 9) errorInput = true;
                if (input == 1 && c1 >= 0) errorInput = true;
                if (input == 2 && c2 >= 0) errorInput = true;
                if (input == 3 && c3 >= 0) errorInput = true;
                if (input == 4 && c4 >= 0) errorInput = true;
                if (input == 5 && c5 >= 0) errorInput = true;
                if (input == 6 && c6 >= 0) errorInput = true;
                if (input == 7 && c7 >= 0) errorInput = true;
                if (input == 8 && c8 >= 0) errorInput = true;
                if (input == 9 && c9 >= 0) errorInput = true;

                if (errorInput == true)
                {
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("Вы ввели некорректное значение!");
                    Console.ReadLine();
                    i--;
                    continue;

                }
                Console.SetCursorPosition(49, 8);
                Console.Write("");
                Console.Write(" " + playerScore);

                if (input == 1) c1 = i % 2;
                if (input == 2) c2 = i % 2;
                if (input == 3) c3 = i % 2;
                if (input == 4) c4 = i % 2;
                if (input == 5) c5 = i % 2;
                if (input == 6) c6 = i % 2;
                if (input == 7) c7 = i % 2;
                if (input == 8) c8 = i % 2;
                if (input == 9) c9 = i % 2;

                // Определение куда поставить фигуру
                int x = (input - 1) % 3 * 11 + 2;
                int y = (input - 1) / 3 * 11 + 2;

                // Определение какую фигуру отрисовать и отрисовка


                if (i % 2 == 0)
                {

                    DrawCrocc(x, y, 7);
                    Console.SetCursorPosition(35, 0);
                    Console.Write("Ход игрока 2: ");


                }

                else
                {
                    DrawRectangle(x, y, 7);
                    Console.SetCursorPosition(35, 0);
                    Console.Write("Ход игрока 1: ");

                }


                // Определение победителя
                if (c1 == c2 && c2 == c3) win = c1;
                if (c4 == c5 && c5 == c6) win = c4;
                if (c7 == c8 && c8 == c9) win = c7;
                if (c1 == c4 && c4 == c7) win = c1;
                if (c2 == c5 && c5 == c8) win = c2;
                if (c3 == c6 && c6 == c9) win = c3;
                if (c1 == c5 && c5 == c9) win = c1;
                if (c3 == c5 && c5 == c7) win = c3;

                if (win == 0)
                {
                    Console.SetCursorPosition(35, 3);
                    Console.WriteLine("Победили крестики!");
                    break;
                }

                if (win == 1)
                {
                    Console.SetCursorPosition(35, 3);
                    Console.WriteLine("Победили нолики!");
                    break;
                }
            }

            Console.SetCursorPosition(35, 4);

            if (win == -1) Console.WriteLine("Ничья!");


            Console.ReadKey();
        }
    }
}