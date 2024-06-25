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
                Console.WriteLine("Введите строку из круглых скобок или exit:");
                string lineInput = Console.ReadLine();

                switch (lineInput)
                {
                    case ButtonExit:
                        isRunning = false;
                        break;

                    default:
                        int currentDepth = 0;
                        int maxDepth = 0;

                        int numberOpenParenthesis = 0;
                        int numberCloseParenthesis = 0;

                        int lastIndex = lineInput.Length - 1;

                        bool isParentheticalCorrect = false;

                        string[] lineOpenParenthesis = lineInput.Split(closeParenthesis);
                        string[] lineCloseParenthesis = lineInput.Split(openParenthesis);

                        if (lineInput[0] == closeParenthesis || lineInput[lastIndex] == openParenthesis || lineOpenParenthesis.Length != lineCloseParenthesis.Length)
                        {
                            isParentheticalCorrect = false;
                        }
                        else if (lineOpenParenthesis.Length == lineCloseParenthesis.Length)
                        {
                            for (int i = 0; i < lineInput.Length; i++)
                            {
                                if (lineInput[i] == openParenthesis)
                                {
                                    numberOpenParenthesis++;
                                    currentDepth = numberOpenParenthesis - numberCloseParenthesis;
                                }
                                else if (lineInput[i] == closeParenthesis)
                                {
                                    numberCloseParenthesis++;
                                    currentDepth--;

                                    if (numberCloseParenthesis > numberOpenParenthesis)
                                    {
                                        i = lineInput.Length;
                                    }
                                }

                                if (currentDepth > maxDepth)
                                {
                                    maxDepth = currentDepth;
                                }
                            }

                            if (currentDepth < 0)
                            {
                                isParentheticalCorrect = false;
                            }
                            else
                            {
                                isParentheticalCorrect = true;
                            }
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
