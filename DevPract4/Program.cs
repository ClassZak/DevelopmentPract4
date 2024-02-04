using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPract4
{
    internal class Program
    {
        static string Sum(string a, string b)
        {
            string result=string.Empty;
            byte curr1=0,curr2=0;
            bool validSecondIndex = false;
            int SecondIndex;
            if(a.Length >= b.Length)
                for(int i=a.Length-1;i!=-1;--i)
                {
                    curr1 += (byte)char.GetNumericValue(a, i);

                    if (!validSecondIndex)
                    {
                        SecondIndex = b.Length - 1 - (a.Length - i - 1);
                        if (SecondIndex == -1)
                            validSecondIndex = true;
                        else
                        {
                            curr2 = (byte)char.GetNumericValue(b, SecondIndex);
                            curr1 += curr2;
                        }
                    }
                    
                    result = (curr1 % 10).ToString() + result;
                    curr2 = 0;
                    curr1 /= 10;
                }
            else
                for (int i = b.Length - 1; i != -1; --i)
                {
                    curr1 += (byte)char.GetNumericValue(b, i);

                    if (!validSecondIndex)
                    {
                        SecondIndex = a.Length - 1 - (b.Length - i - 1);
                        if (SecondIndex == -1)
                            validSecondIndex = true;
                        else
                        {
                            curr2 = (byte)char.GetNumericValue(a, SecondIndex);
                            curr1 += curr2;
                        }
                    }

                    result = (curr1 % 10).ToString() + result;
                    curr2 = 0;
                    curr1 /= 10;
                }


            if(curr1==1)
                result=1.ToString()+result;


            return result;
        }
        static void Main(string[] args)
        {
            try
            {
                string a, b;
                Console.Write("Введите два ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("положительных");
                Console.ResetColor();
                Console.WriteLine(" числа");


                Console.WriteLine("Введите первое число->");
                Console.ForegroundColor = ConsoleColor.Green;
                a=Console.ReadLine();
                Console.ResetColor();
                if (a.Contains('-'))
                    throw new Exception("Первое число окозалось отрицательным при вводе!");

                Console.WriteLine("Введите второе число->");
                Console.ForegroundColor = ConsoleColor.Green;
                b = Console.ReadLine();
                Console.ResetColor();
                if(b.Contains('-'))
                    throw new Exception("Второе число окозалось отрицательным при вводе!");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Sum(a, b));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
            }
            finally
            {
                Console.ResetColor();
                Console.ReadKey(false);
            }
            
        }
    }
}
