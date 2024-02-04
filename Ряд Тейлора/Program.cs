using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Ряд_Тейлора//№1
{
    internal class Program
    {
        #region Вычисление функции
        static void ТаблицаРядаТейлора()
        {
            double x0, x, dx;
            const double eps = 0.1e-7;

            Console.Write("Введите x начальное->");
            Console.ForegroundColor = ConsoleColor.Green;
            x0=Convert.ToDouble(Console.ReadLine());
            Console.ResetColor();
            if(x0<0)
                throw new Exception("Невозможно вычислить логарифм отрицательного числа в множестве действительных чисел!");

            Console.Write("Введите x конечное->");
            Console.ForegroundColor = ConsoleColor.Green;
            x = Convert.ToDouble(Console.ReadLine());
            Console.ResetColor();
            if(x0>x)
                throw new Exception("Неверно введён конец диапозона!");

            Console.Write("Введите шаг dx->");
            Console.ForegroundColor = ConsoleColor.Green;
            dx = Convert.ToDouble(Console.ReadLine());
            Console.ResetColor();
            if (dx <= 0)
                throw new Exception("Шаг вычисления функции должен быть больше 0!");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tТаблица ряда Тейлора функции ln((x+1)/(x-1)");
            Console.WriteLine("|Аргумент\t\t|Значение функции\t\t\t|Количество членов ряда для eps={0}\t|",eps);
            for(int i = 0; i!=Console.LargestWindowWidth/2; ++i)
                Console.Write('-');

            uint argumentNumber = 1;
            double currResult=0, currSeriesMember=0;
            for(double i=x0;(i<=x) && (Math.Abs(i-x)) >= eps;i+=dx)
            {
                try
                {
                    if(i<1)
                        throw new ArithmeticException("Невозможно вычислить логарифм отрицательного числа в множестве действительных чисел!");
                    if(i==1.0 || Math.Abs(i-1)<=eps)
                        throw new DivideByZeroException("При вычислении логорифма не может быть деления на 0!");



                    do
                    {
                        currSeriesMember = 1 / (Math.Pow(i,argumentNumber*2-1)*(argumentNumber*2-1));
                        if (currSeriesMember == double.PositiveInfinity)
                            throw new DivideByZeroException("При вычислении члена ряда было произведено деление на 0!");
                        currResult += currSeriesMember;
                        ++argumentNumber;
                    } while (currSeriesMember >= eps);
                    currResult *= 2;


                    Console.WriteLine("|{0}\t\t\t|{1}\t\t\t|{2}\t\t\t|",i, currResult, argumentNumber);

                }
                catch(DivideByZeroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                    Console.ResetColor();
                    throw;
                }
                catch (ArithmeticException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    throw;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неожиданное исключение при вычислении значения аргумента!");
                    Console.ResetColor();
                    throw;
                }
                finally
                {
                    argumentNumber = 1;
                    currResult = 0;
                }
            }

            for (int i = 0; i != Console.LargestWindowWidth / 2; ++i)
                Console.Write('-');





            Console.ResetColor();
        }
        #endregion
        static void Main(string[] args)
        {
            try
            {
                ТаблицаРядаТейлора();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
            }
            finally
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine("Для завершения нажмите любую клавишу . . .");
                Console.ResetColor();
                Console.ReadKey(false);
            }
        }
    }
}
