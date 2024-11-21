using System.Text;

namespace Tasks
{
    public class Project()
    {
        enum GruntingLevel
        {
            внук, спойкойный, веселый, злой, дикий
        }
        struct Grandpa
        {
            public string name;
            public GruntingLevel gruntingLevel;
            public int bruises;
            public string[] language;
            public int CountBruises(Grandpa grandpa, params string[] obsceneLanguage)
            {
                int obsceneCount = 0;
                for (int i = 0; i < grandpa.language.Length; i++)
                {
                    for (int j = 0; j < obsceneLanguage.Length; j++)
                    {
                        if (grandpa.language[i] == obsceneLanguage[j])
                        {
                            obsceneCount++;
                            break;
                        }
                    }
                }
                bruises = obsceneCount;
                return obsceneCount;
            }
            public void Output()
            {
                Console.WriteLine("Имя - {0}", name);
                Console.WriteLine("Уровень ворчания - {0}", gruntingLevel);
                Console.Write("Ликсикон: ");
                for (int i = 0; i < language.Length; i++)
                {
                    Console.Write("{0} ", language[i]);
                }
                Console.WriteLine();
                Console.WriteLine("\n\n");
            }
        }
            static int ArrayCalculations(int[] arr, ref int multiplication, out int averageArithmetic)
        {
            averageArithmetic = 0;
            bool multiplicationOverflow = false;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    multiplication = checked(multiplication * arr[i]);
                }
                catch (OverflowException)
                {
                    multiplication = 0;
                    multiplicationOverflow = true;
                }
                sum += arr[i];
            }
            averageArithmetic = sum / arr.Length;
            if (multiplicationOverflow)
            {
                multiplication = -1;
            }
            return sum;
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Random randomizer = new Random();

            void StartTask(int n)
            {
                Console.WriteLine("Задача номер {0}", n);
            }

            //1.Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива,
            //которые нужно поменять местами.Вывести на экран получившийся массив.
            StartTask(1);
            int[] arrayToSwap = new int[20];
            for (int i = 0; i < arrayToSwap.Length; i++)
            {
                arrayToSwap[i] = randomizer.Next(10000);
                Console.Write("{0} ", arrayToSwap[i]);
            }
            Console.WriteLine();    
            Console.WriteLine("Какие два элемента данного массива нужно поменять местами?(Укажите два числовых значения)");
            int firstToSwap, secondToSwap;
            bool isBreak = false;
            if (int.TryParse(Console.ReadLine(), out firstToSwap)
                && int.TryParse(Console.ReadLine(), out secondToSwap))
            {
                for (int i = 0; i < 20 && !isBreak; i++)
                {
                    for (int j = i + 1; j < 20; j++)
                    {
                        if (arrayToSwap[j] == secondToSwap && arrayToSwap[i] == firstToSwap)
                        {
                            (arrayToSwap[j], arrayToSwap[i]) = (arrayToSwap[i], arrayToSwap[j]);
                            isBreak = true;
                            break;
                        }
                    }
                }
                if (!isBreak)
                {
                    Console.WriteLine("Одного из указанных числовых значений нет в массиве, ничего не поменялось");
                }
                else
                {
                    Console.WriteLine("Массив после изменений");
                }
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("{0} ", arrayToSwap[i]);
                }
            }
            else
            {
                Console.WriteLine("Ошибка нужно ввести два целочисленных значения");
            }
            Console.WriteLine("\n\n");


            //2.Написать метод, где в качества аргумента будет передан массив(ключевое слово
            //params).Вывести сумму элементов массива(вернуть).Вывести(ref) произведение
            //массива.Вывести(out) среднее арифметическое в массиве.
            StartTask(2);
            Console.WriteLine("Наш массив");
            int[] arrayToMultiply = new int[6];
            for (int i = 0; i < arrayToMultiply.Length; i++)
            {
                arrayToMultiply[i] = randomizer.Next(40);
                Console.Write("{0} ", arrayToMultiply[i]);
            }
            int arrayMultiplication = 1;
            Console.WriteLine();
            Console.WriteLine("Его сумма - {0}",
                ArrayCalculations(arrayToMultiply, ref arrayMultiplication, out int arrayAverage));
            if (arrayMultiplication == -1)
            {
                Console.WriteLine("Его произведение - ошибка переполнения");
            }
            else
            {
                Console.WriteLine("Его произведение - {0}", arrayMultiplication);
            }
            Console.WriteLine("Его среднее арифметическое - {0}\n\n", arrayAverage);


            //3.Пользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать
            //изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
            //должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если
            //пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
            //завершает работу, если пользователь введёт слово: exit или закрыть(оба варианта
            //должны сработать) - консоль закроется
            StartTask(3);
            Console.WriteLine("Вводите целочисленные значения");
            bool isExit = false;
            while (!isExit)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int command))
                {
                    if (command < 0 || command > 9)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Thread.Sleep(3000);
                        Console.WriteLine("Произошла ошибка");
                    }
                    else if (command == 0)
                    {

                        Console.WriteLine("#######");
                        Console.WriteLine("#     #");
                        Console.WriteLine("#     #");
                        Console.WriteLine("#     #");
                        Console.WriteLine("#######");
                    }
                    else if (command == 1)
                    {
                        Console.WriteLine("     #");
                        Console.WriteLine("     #");
                        Console.WriteLine("     #");
                        Console.WriteLine("     #");
                        Console.WriteLine("     #");
                    }
                    else if (command == 2)
                    {
                        Console.WriteLine("########");
                        Console.WriteLine("       #");
                        Console.WriteLine("       #");
                        Console.WriteLine("########");
                        Console.WriteLine("#");
                        Console.WriteLine("#");
                        Console.WriteLine("########");
                    }
                    else if (command == 3)
                    {
                        Console.WriteLine("#########");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                        Console.WriteLine("#########");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                        Console.WriteLine("#########");
                    }
                    else if (command == 4)
                    {
                        Console.WriteLine("#       #");
                        Console.WriteLine("#       #");
                        Console.WriteLine("#       #");
                        Console.WriteLine("#########");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                    }
                    else if (command == 5)
                    {
                        Console.WriteLine("#########");
                        Console.WriteLine("#");
                        Console.WriteLine("#");
                        Console.WriteLine("#");
                        Console.WriteLine("#########");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                        Console.WriteLine("#########");
                    }
                    else if (command == 6)
                    {
                        Console.WriteLine("#########");
                        Console.WriteLine("#");
                        Console.WriteLine("#");
                        Console.WriteLine("#########");
                        Console.WriteLine("#       #");
                        Console.WriteLine("#       #");
                        Console.WriteLine("#########");

                    }
                    else if (command == 7)
                    {
                        Console.WriteLine("#########");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                    }
                    else if (command == 8)
                    {
                        Console.WriteLine("#########");
                        Console.WriteLine("#       #");
                        Console.WriteLine("#       #");
                        Console.WriteLine("#########");
                        Console.WriteLine("#       #");
                        Console.WriteLine("#       #");
                        Console.WriteLine("#########");
                    }
                    else if (command == 9)
                    {
                        Console.WriteLine("#########");
                        Console.WriteLine("#       #");
                        Console.WriteLine("#       #");
                        Console.WriteLine("#########");
                        Console.WriteLine("        #");
                        Console.WriteLine("        #");
                        Console.WriteLine("#########");

                    }
                }
                else if (userInput.ToLower() == "exit" || userInput.ToLower() == "закрыть")
                {
                    isExit = true;
                }
                else
                {
                    Console.WriteLine("Исключение Исключение Исключение");
                }
            }
            Console.WriteLine("Консоль закрыта\n\n");
            Console.ResetColor();
            //Environment.Exit(0);
            //Закрывает Консоль, но так как дальше ещё одна задача "Консоль закрыта" - альтернатива


            string[] obsceneLanguage = new string[3] { "ррр!", "Проститутки!", "Гады!" };
            //4.Создать структуру Дед. У деда есть имя, уровень ворчливости(перечисление), массив
            //фраз для ворчания(прим.: “Проститутки!”, “Гады!”), количество синяков от ударов
            //бабки = 0 по умолчанию. Создать 5 дедов.У каждого деда - разное количество фраз для
            //ворчания.Напишите метод(внутри структуры), который на вход принимает деда,
            //список матерных слов (params).Если дед содержит в своей лексике матерные слова из
            //списка, то бабка ставит фингал за каждое слово.Вернуть количество фингалов.
            StartTask(4);
            string[] grandpaIvanString = new string[6] { "ррр!", "ррр!", "ррр!", "Проститутки!", "Гады!", "Ivan ну и беда" };
            Grandpa grandpaIvan = new Grandpa() { name = "Ivan", gruntingLevel = (GruntingLevel)0, bruises = 0, language = grandpaIvanString };
            Console.WriteLine("Бабушка ударила {0} раз", grandpaIvan.CountBruises(grandpaIvan, obsceneLanguage));
            grandpaIvan.Output();
            string[] grandpaOlegString = new string[6] { "ррр!", "ррр!", "ррр!", "Проститутки!", "Гады!", "Oleg ну и беда" };
            Grandpa grandpaOleg = new Grandpa() { name = "Oleg", gruntingLevel = (GruntingLevel)0, bruises = 0, language = grandpaOlegString };
            Console.WriteLine("Бабушка ударила {0} раз", grandpaOleg.CountBruises(grandpaOleg, obsceneLanguage));
            grandpaOleg.Output();
            string[] grandpaAlexanderString = new string[6] { "ррр!", "ррр!", "ррр!", "Проститутки!", "Гады!", "Alexander ну и беда" };
            Grandpa grandpaAlexander = new Grandpa() { name = "Alexander", gruntingLevel = (GruntingLevel)1, bruises = 0, language = grandpaAlexanderString };
            Console.WriteLine("Бабушка ударила {0} раз", grandpaAlexander.CountBruises(grandpaAlexander, obsceneLanguage));
            grandpaAlexander.Output();
            string[] grandpaВикторString = new string[6] { "ррр!", "ррр!", "ррр!", "Проститутки!", "Гады!", "Виктор ну и беда" };
            Grandpa grandpaВиктор = new Grandpa() { name = "Виктор", gruntingLevel = (GruntingLevel)2, bruises = 0, language = grandpaВикторString };
            Console.WriteLine("Бабушка ударила {0} раз", grandpaВиктор.CountBruises(grandpaВиктор, obsceneLanguage));
            grandpaВиктор.Output();
            string[] grandpaЮрийString = new string[6] { "ррр!", "ррр!", "ррр!", "Проститутки!", "Гады!", "Юрий ну и беда" };
            Grandpa grandpaЮрий = new Grandpa() { name = "Юрий", gruntingLevel = (GruntingLevel)3, bruises = 0, language = grandpaЮрийString };
            Console.WriteLine("Бабушка ударила {0} раз", grandpaЮрий.CountBruises(grandpaЮрий, obsceneLanguage));
            grandpaЮрий.Output();
        }
    }
}
