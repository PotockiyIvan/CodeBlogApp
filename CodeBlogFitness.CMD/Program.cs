using CodeBlogFitness.dll.Controller;
using CodeBlogFitness.dll.Model;
using System;
using CodeBlogFitness.CMD.languages;
using System.Globalization;
using System.Resources;

namespace CodeBlogFitness.CMD
{
    //Приложение консольное но с заделом на интеграцию,здесь будет 
    //реализовываться консольный интерфейс.
    class Program
    {
        static void Main(string[] args)
        {
            //Культура - это языковая настройка,включает в себя: какой язык использовать
            //как отображать время,какой знак разделения у дробей и так далее
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            //Менеджер ресурсов - 1 аргумент - корневое имя файла с ресурсом без расширения,2 аргумент - наша сборка(Главный класс приложения - Programm).
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.languages.Messages_ru-ru", typeof(Program).Assembly);
            //Теперь мы вызываем строки из файла ресурсов,все это нужно для локализации на разные языки.
            Console.WriteLine(resourceManager.GetString("Hello",culture));
            Console.WriteLine(resourceManager.GetString("EnterName",culture));
            var name = Console.ReadLine();

            //Создаем usercontroller и если пользователь новый,выполняем логику ввода данных пользователя с консоли
            var userController = new UserController(name);
            if (userController.IsNewUser)//тот самый флаг
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDate();
                var weight = ParseDouble("Вес");//методы определены, чтобы не повторять код
                var height = ParseDouble("Рост");

                //создаем нового пользователя
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            

            //Создаем eatingcontroller и выполняем логику ввода данных приемов пищи и продуктов питания с консоли
            var eatingController = new EatingController(userController.CurrentUser);
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("1. Ввести прием пищи");
            var command = Convert.ToInt32(Console.ReadLine());

            switch (command)
            {
                case 1:
                    var foods =EnterEating();
                    eatingController.Add(foods.Food, foods.Weight);//КОРТЕЖИ - Интересное именование!!!
                    foreach(var item in eatingController.Eating.Foods)
                        Console.WriteLine($"\t{item.Key} - {item.Value}");

                    break;
                default:
                    break;
            }

        }
        private static (Food Food,double Weight) EnterEating()//КОРТЕЖИ - интересное именование!!!
        {
            Console.Write("Введите название продукта: ");
            var food = Console. ReadLine();
            //РАЗБОРКА ВОТ ТУТ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var calories =      ParseDouble("калорийность");
            var proteins =      ParseDouble("кол-во белков");
            var fats =          ParseDouble("кол-во жиров");
            var Carbohydrates = ParseDouble("кол-во углеводов");
            var weight =        ParseDouble("вес порции");

            var product = new Food(food, proteins, fats, Carbohydrates, calories);

            return (product, weight);
        }

        //метод для парсинга даты из консоли 
        /// <summary>
        /// Парсинг данных из консоли
        /// </summary>
        /// <returns> Дата рождения.</returns>
        private static DateTime ParseDate()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения в формате (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                    return birthDate;
                else
                    Console.WriteLine("Неверный формат даты рождения");
            }
        }

        //метод для парсинга из консоли в дабл для веса и роста
        /// <summary>
        /// Парсинг данных из консоли.
        /// </summary>
        /// <param name="name">Вес или Рост</param>
        /// <returns></returns>
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                else
                    Console.WriteLine($"Неверный формат поля {name}");
            }

        }
    }
}

