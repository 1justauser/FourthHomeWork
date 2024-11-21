using System.Text;

namespace Tumakov
{
    public class Project()
    {


        static int Fibonacci(int n, ref int[] fibonacciSequence)
        {
            if (fibonacciSequence[n - 1] == 0)
            {
                if (n == 1)
                {
                    fibonacciSequence[n - 1] = 1;
                    return 1;
                }
                if (n == 2)
                {
                    fibonacciSequence[n - 1] = 1;
                    return 1;
                }
                try
                {
                    int f1 = Fibonacci(n - 1, ref fibonacciSequence);
                    int f2 = Fibonacci(n - 2, ref fibonacciSequence);
                    if (f1 != -1 && f2 != -1)
                    {
                        fibonacciSequence[n - 1] = checked(f1 + f2);
                        return fibonacciSequence[n - 1];
                    }
                    else
                    {
                        fibonacciSequence[n - 1] = -1;
                        return -1;
                    }
                }
                catch (OverflowException)
                {
                    fibonacciSequence[n - 1] = -1;
                    return -1;
                }
            }
            else
            {
                return fibonacciSequence[n - 1];
            }
        }


        static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int lowerFactorial = Factorial(n - 1);
            if (lowerFactorial == -1)
            {
                return -1;
            }
            try
            {
                return checked(Factorial(n - 1) * n);
            }
            catch (OverflowException)
            {
                return -1;
            }
        }


        static bool Factorial(int n, ref int ans)
        {
            if (n == 1)
            {
                ans = 1;
                return true;
            }
            try
            {
                int newAns = 1;
                if (Factorial(n - 1, ref newAns))
                {
                    ans = checked(newAns * n);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (OverflowException)
            {
                return false;
            }
        }


        static void Switch(ref double a, ref double b)
        {
            (a, b) = (b, a);
        }


        static void Switch(ref string a, ref string b)
        {
            (a, b) = (b, a);
        }


        static void Switch(ref double[] a, ref double[] b)
        {
            (a, b) = (b, a);
        }


        static int GreatestCommonFactor(int a, int b)
        {
            if (a < b)
            {
                (a, b) = (b, a);
            }
            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }
            else
            {
                return GreatestCommonFactor(b, a % b);
            }
        }


        static int GreatestCommonFactor(int a, int b, int c)
        {
            return GreatestCommonFactor(a, GreatestCommonFactor(b, c));
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            double BiggestAmongTwoNumbers(double a, double b)
            {
                if (a > b)
                {
                    return a;
                }
                return b;
            }


            //Упражнение 5.1 Написать метод, возвращающий наибольшее из двух чисел. Входные
            //параметры метода – два целых числа.Протестировать метод
            Console.WriteLine("Упражнение 5.1");
            Console.WriteLine("Проверим метод - введите два числовых значения, чтобы найти наибольшее");
            double firstNumber, secondNumber;
            if (double.TryParse(Console.ReadLine(), out firstNumber) && double.TryParse(Console.ReadLine(), out secondNumber))
            {
                Console.WriteLine(BiggestAmongTwoNumbers(firstNumber, secondNumber));
            }
            else
            {
                Console.WriteLine("Ошибка: Нужно ввести два числовых значение");
            }


            //Упражнение 5.2 Написать метод, который меняет местами значения двух передаваемых
            //параметров.Параметры передавать по ссылке. Протестировать метод.
            Console.WriteLine("\n\nУпражнение 5.2");
            Console.WriteLine("Введите тип значений (\"Число\", \"Строка\", \"Массив чисел\"),");
            Console.WriteLine("затем два значения, чтобы поменять их местами");
            string TypeVariable = Console.ReadLine().ToLower();
            switch (TypeVariable)
            {
                case "число":
                    double firstDouble, secondDouble;
                    double firstCopyDouble, secondCopyDouble;
                    Console.WriteLine("\nВведите первое значение");
                    if (!double.TryParse(Console.ReadLine(), out firstDouble))
                    {
                        Console.WriteLine("Ошибка необходимо указать числовое значение");
                        break;
                    }
                    Console.WriteLine("\nВведите второе значение");
                    if (!double.TryParse(Console.ReadLine(), out secondDouble))
                    {
                        Console.WriteLine("Ошибка необходимо указать числовое значение");
                        break;
                    }
                    (firstCopyDouble, secondCopyDouble) = (firstDouble, secondDouble);
                    Switch(ref firstDouble, ref secondDouble);
                    Console.WriteLine("\n\nПроверка");
                    Console.WriteLine("Первое значение - {0}", firstDouble);
                    Console.WriteLine("Второе значение - {0}", secondDouble);
                    if (firstCopyDouble == secondDouble && secondCopyDouble == firstDouble)
                    {
                        Console.WriteLine("Успешно!");
                    }
                    else
                    {
                        Console.WriteLine("Метод не работает");
                    }
                    break;
                case "строка":
                    string firstString, secondString;
                    string firstCopyString, secondCopyString;
                    Console.WriteLine("\nВведите первое значение");
                    firstString = Console.ReadLine();
                    Console.WriteLine("\nВведите второе значение");
                    secondString = Console.ReadLine();
                    firstCopyString = firstString;
                    secondCopyString = secondString;
                    Switch(ref firstString, ref secondString);
                    Console.WriteLine("\n\nПроверка");
                    Console.WriteLine("Первое значение - {0}", firstString);
                    Console.WriteLine("Второе значение - {0}", secondString);
                    if (firstCopyString == secondString &&
                        secondCopyString == firstString)
                    {
                        Console.WriteLine("Успешно!");
                    }
                    else
                    {
                        Console.WriteLine("Метод не работает");
                    }
                    break;
                case "массив чисел":
                    Console.WriteLine("Введите длину первого Массива");
                    int firstLength, secondLenght;
                    if (!int.TryParse(Console.ReadLine(), out firstLength) || firstLength < 1)
                    {
                        Console.WriteLine("Длина должна быть указана в виде натурального числа");
                        break;
                    }
                    Console.WriteLine("Введите длину второго Массива");
                    if (!int.TryParse(Console.ReadLine(), out secondLenght) || secondLenght < 1)
                    {
                        Console.WriteLine("Длина должна быть указана в виде натурального числа");
                        break;
                    }
                    double[] firstArray = new double[firstLength];
                    double[] secondArray = new double[secondLenght];
                    bool isBreak = false;
                    for (int i = 0; i < firstLength; i++)
                    {
                        Console.WriteLine("Введите {0} элемент первого массива", i + 1);
                        if (!double.TryParse(Console.ReadLine(), out firstArray[i]))
                        {
                            Console.WriteLine("Ошибка длина должна быть указана в виде натурального числа");
                            isBreak = true;
                            break;
                        }
                    }
                    if (isBreak)
                    {
                        break;
                    }
                    for (int i = 0; i < secondLenght; i++)
                    {
                        Console.WriteLine("Введите {0} элемент первого массива", i + 1);
                        if (!double.TryParse(Console.ReadLine(), out secondArray[i]))
                        {
                            Console.WriteLine("Ошибка длина должна быть указана в виде натурального числа");
                            isBreak = false;
                            break;
                        }
                    }
                    if (isBreak) 
                    {
                        break;
                    }
                    double[] firstCopyArray = firstArray, secondCopyArray = secondArray;
                    Switch(ref firstArray, ref secondArray);
                    Console.WriteLine("\n\nПроверка");
                    Console.WriteLine("Первый массив");
                    for (int i = 0; i < firstArray.Length; i++)
                    {
                        Console.Write("{0} ", firstArray[i]);
                    }
                    Console.WriteLine("\nВторой массив");
                    for (int i = 0; i < secondArray.Length; i++)
                    {
                        Console.Write("{0} ", secondArray[i]);
                    }
                    if (firstArray == secondCopyArray && secondArray == firstCopyArray)
                    {
                        Console.WriteLine("\nУспешно!");
                    }
                    else
                    {
                        Console.WriteLine("\nМетод не работает");
                    }
                    break;
                default:
                    Console.WriteLine("Нужно правильно указать один из трех доступных типов");
                    break;
            }


            //Упражнение 5.3 Написать метод вычисления факториала числа, результат вычислений
            //    передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
            //если в процессе вычисления возникло переполнение, то вернуть значение false.Для
            //    отслеживания переполнения значения использовать блок checked.
            Console.WriteLine("\n\nУпражнение 5.3");
            Console.WriteLine("Укажите номер факториала");
            int factorialNumberBool, factorialValueBool = 1;
            if (int.TryParse(Console.ReadLine(), out factorialNumberBool)
                && factorialNumberBool > 0)
            {
                if (Factorial(factorialNumberBool, ref factorialValueBool))
                {
                    Console.WriteLine("Успешный подсчет факториала");
                    Console.WriteLine("Результат - {0}", factorialValueBool);
                }
                else
                {
                    Console.WriteLine("Произошло переполнение");
                }
            }
            else
            {
                Console.WriteLine("Ошибка необходимо указать натуральное число");
            }




            //Упражнение 5.4 Написать рекурсивный метод вычисления факториала числа.
            Console.WriteLine("\n\nУпражнение 5.4");
            Console.WriteLine("Укажите номер факториала");
            if (int.TryParse(Console.ReadLine(), out int factorialNumberRecursion))
            {
                int factorialValueRecursion = Factorial(factorialNumberRecursion);
                if (factorialValueRecursion == -1)
                {
                    Console.WriteLine("Произошло переполнение");
                }
                else
                {
                    Console.WriteLine("Значение факториала {0}", factorialValueRecursion);
                }
            }


            //Домашнее задание 5.1 Написать метод, который вычисляет НОД двух натуральных чисел
            //(алгоритм Евклида).Написать метод с тем же именем, который вычисляет НОД трех
            //натуральных чисел.
            Console.WriteLine("Домашнее задание 5.1");
            Console.WriteLine("Сколько чисел (2,3) для нахождения НОД?");
            int factorsAmount;
            if (int.TryParse(Console.ReadLine(), out factorsAmount))
            {

                if (factorsAmount == 2)
                {
                    Console.WriteLine("Введите два натуральных числа для нахождения НОД");
                    int firstFactor, secondFactor;
                    if (int.TryParse(Console.ReadLine(), out firstFactor)
                        && int.TryParse(Console.ReadLine(), out secondFactor))
                    {
                        if (firstFactor > 0 && secondFactor > 0)
                        {
                            Console.WriteLine("НОД {0} и {1} - {2}", firstFactor, secondFactor,
                                GreatestCommonFactor(firstFactor, secondFactor));
                        }
                        else
                        {
                            Console.WriteLine("Нужно два натуральных числа");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка нужно указать два числа");
                    }
                }
                else if (factorsAmount == 3)
                {
                    Console.WriteLine("Введите три натуральных числа для нахождения НОД");
                    int firstFactor, secondFactor, thirdFactor;
                    if (int.TryParse(Console.ReadLine(), out firstFactor)
                        && int.TryParse(Console.ReadLine(), out secondFactor)
                          && int.TryParse(Console.ReadLine(), out thirdFactor))
                    {
                        if (firstFactor > 0 && secondFactor > 0
                            && thirdFactor > 0)
                        {
                            Console.WriteLine("НОД {3}, {0} и {1} - {2}", firstFactor, secondFactor,
                                GreatestCommonFactor(firstFactor, secondFactor, thirdFactor), thirdFactor);
                        }
                        else
                        {
                            Console.WriteLine("Нужно три натуральных числа");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка нужно указать три числа");
                    }
                }
                else
                {
                    Console.WriteLine("Может быть только 2 либо 3");
                }
            }
            else
            {
                Console.WriteLine("Ошибка нужно ввести целое число");
            }


            //Домашнее задание 5.2 Написать рекурсивный метод, вычисляющий значение n - го числа
            //ряда Фибоначчи.Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8,
            //13... Для таких чисел верно соотношение Fk = Fk - 1 + Fk - 2.
            Console.WriteLine("Домашнее задание 5.2");
            Console.WriteLine("Укажите номер ряда Фибоначчи");
            if (int.TryParse(Console.ReadLine(), out int fibonacciNumber))
            {
                int[] fibonacciSequence = new int[fibonacciNumber];
                int fibonacciValue = Fibonacci(fibonacciNumber, ref fibonacciSequence);
                if (fibonacciValue > 0)
                {
                    Console.WriteLine("Значение {0} числа Фибоначчи - {1}", fibonacciNumber, fibonacciValue);
                }
                else
                {
                    Console.WriteLine("Переполнение");
                }
            }
            else
            {
                Console.WriteLine("Ошибка укажите число");
            }
        }
    }
}
