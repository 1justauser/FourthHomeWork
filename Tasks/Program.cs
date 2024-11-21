using System.Text;

namespace Tasks
{
    public class Project()
    {
        static void Main(string[] args) 
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            void StartTasks(int n)
            {
                Console.WriteLine("Задание {0}", n);
            }


            StartTasks(0);
            Console.WriteLine("Русский язык работает");
        }
    }
}