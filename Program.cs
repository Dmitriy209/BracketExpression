using System;

namespace BracketExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ButtonExit = "exit";

            bool isRunning = true;

            char openParenthesis = '(';
            char closeParenthesis = ')';

            while (isRunning)
            {
                Console.WriteLine($"Введите строку из круглых скобок или {ButtonExit}:");
                string lineInput = Console.ReadLine();

                switch (lineInput)
                {
                    case ButtonExit:
                        isRunning = false;
                        break;

                    default:
                        int currentDepth = 0;
                        int maxDepth = 0;

                        int lastIndex = lineInput.Length - 1;

                        bool isParentheticalCorrect = false;

                        for (int i = 0; i < lineInput.Length; i++)
                        {
                            if (lineInput[i] == openParenthesis)
                            {
                                currentDepth++;
                            }
                            else if (lineInput[i] == closeParenthesis)
                            {
                                currentDepth--;

                                if (currentDepth < 0)
                                {
                                    i = lineInput.Length;
                                    isParentheticalCorrect = false;
                                }
                            }

                            if (currentDepth > maxDepth)
                            {
                                maxDepth = currentDepth;
                            }
                        }

                        if (currentDepth == 0)
                        {
                            isParentheticalCorrect = true;
                        }

                        if (isParentheticalCorrect == true)
                        {
                            Console.WriteLine($"Ваша строка: {lineInput} и она корректна, " +
                                $"максимальная глубина равняется {maxDepth}.");
                        }
                        else
                        {
                            Console.WriteLine($"Строка {lineInput} - некорректна.");
                        }
                        break;
                }
            }

            Console.WriteLine("Программа завершена.");
        }
    }
}
