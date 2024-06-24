using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

            Console.WriteLine("Введите скобки:");
            string line = Console.ReadLine();

            //char[] tempLine = new char[line.Length];

            //for (int i = 0; i < line.Length; i++)
            //{
            //    tempLine[i] = line[i];
            //}

            char tempParenthesis;
            char openParenthesis = '(';
            char closeParenthesis = ')';

            int currentDepth = 0;
            int maxDepth = 0;
            int expectedDepth = 0;

            int numberOpenParenthesis = 0;
            int numberCloseParenthesis = 0;

            int numberOpenParenthesisRow = 0;
            int numberCloseParenthesisRow = 0;

            int lastIndex = line.Length - 1;

            bool isParentheticalCorrect = false;

            bool lastTurnOpenParenthesis = false;
            bool lastTurnCloseParenthesis = false;

            string[] lineOpenParenthesis = line.Split(closeParenthesis);
            string[] lineCloseParenthesis = line.Split(openParenthesis);

            if (line[0] == closeParenthesis || line[lastIndex] == openParenthesis || lineOpenParenthesis.Length != lineCloseParenthesis.Length)
            {
                isParentheticalCorrect = false;
            }
            else if (lineOpenParenthesis.Length == lineCloseParenthesis.Length)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    

                    if (line[i] == openParenthesis)
                    {
                        numberOpenParenthesis++;
                        currentDepth = numberOpenParenthesis - numberCloseParenthesis;
                    }
                    else if (line[i] == closeParenthesis)
                    {
                        numberCloseParenthesis++;
                        currentDepth --;
                    }

                    if (currentDepth > maxDepth)
                    {
                        maxDepth = currentDepth;
                    }
                    
                }

                //if (numberOpenParenthesis == numberCloseParenthesis)
                //{
                isParentheticalCorrect = true;
                //}

            }

            Console.WriteLine($"Текущая глубина {currentDepth}\n" +
                $"Максимальная глубина {maxDepth}");

            if (isParentheticalCorrect == true)
            {
                Console.WriteLine($"Ваша строка: {line} и она корректна.");
            }
            else if (isParentheticalCorrect == false)
            {
                Console.WriteLine($"Строка {line} - некорректна.");
            }
            else
            {
                Console.WriteLine("Необработанное исключение.");
            }
            Console.WriteLine("Конец программы");


            }
        }
    }
}
