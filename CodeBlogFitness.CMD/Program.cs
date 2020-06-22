using CodeBlogFitness.dll.Controller;
using CodeBlogFitness.dll.Model;
using System;


namespace CodeBlogFitness.CMD
{
    //Приложение консольное но с заделом на интеграцию,здесь будет 
    //реализовываться консольный интерфейс.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение CodeBlogFitness");

            Console.WriteLine("Введите имя польэователя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите вec");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();


        }
    }
}
