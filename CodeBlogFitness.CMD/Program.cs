using CodeBlogFitness.dll.Controller;
using CodeBlogFitness.dll.Model;
using System;
using CodeBlogFitness.CMD.languages;
using System.Globalization;
using System.Resources;

//https://youtu.be/PCDuxxKBEc0?t=1661 ПОДКЛЮЧЕНИЕ ENTITY FRAMEWORK
//https://youtu.be/PCDuxxKBEc0?t=3274 ОБЯСНЕНИЕ МОДЕЛИ ПРИЛОЖЕНИЯ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            #region комментарии к созданию контроллеров
            //Создаем usercontroller и если пользователь новый,выполняем логику ввода данных пользователя с консоли
            //Создаем eatingcontroller и выполняем логику ввода данных приемов пищи и продуктов питания с консоли
            //Создаем exerciseController и выолняем логику ввода данных активности
            #endregion
              
            var userController =     new UserController(name);           
            var eatingController =   new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            
            if (userController.IsNewUser)//тот самый флаг
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender =    Console.ReadLine();
                var birthDate = ParseDate("дата рождения");
                var weight =    ParseDouble("Вес");//методы определены, чтобы не повторять код
                var height =    ParseDouble("Рост");

                //создаем нового пользователя
                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1. Добавить прием пищи \t 2.Добавить упражнение");
                var command = Convert.ToInt32(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);//КОРТЕЖИ - Интересное именование!!!
                        foreach (var item in eatingController.Eating.Foods)
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        break;

                    case 2:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.activity, exe.start, exe.finish);
                        foreach(var item in exerciseController.Exercises)
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        break;

                    case 3:
                        break;
                    default:
                        break;
                }
            }
        }
        //Изначально метод возвращал Exercise и последней строкой было
        //return new Exercise(start, finish, activity, UserController.CurrentUser);
        //но,так как в статическом методе мы не можем использовать созданный userController 
        //из-за ограничения области видимости,мы опять будем возвращать кортеж в виде
        //(DateTime start,DateTime finish, Activity activity)
        //Благодаре этому сверху в свитче мы можем передать в качестве аргументов данные через свойста созданного экземпляра
        //var exe = EnterExercise();
        //exerciseController.Add(exe.activity, exe.start, exe.finish);
        /// <summary>
        /// Добавить упражнение.
        /// </summary>
        /// <returns></returns>
        private static (DateTime start,DateTime finish, Activity activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var exerciseName = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");              
            var start =  ParseDate("Время начала упражнения");
            var finish = ParseDate("Время конца упражнения");

            var activity = new Activity(exerciseName, energy);

            return (start, finish, activity);
        }

        /// <summary>
        /// Добавить прием пищи.
        /// </summary>
        /// <returns></returns>
        private static (Food Food, double Weight) EnterEating()//КОРТЕЖИ - интересное именование!!!
        {
            Console.Write("Введите название продукта: ");
            var food = Console.ReadLine();
            //РАЗБОРКА ВОТ ТУТ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var calories =      ParseDouble("калорийность");
            var proteins =      ParseDouble("кол-во белков");
            var fats =          ParseDouble("кол-во жиров");
            var Carbohydrates = ParseDouble("кол-во углеводов");
            var weight =        ParseDouble("вес порции");

            var product = new Food(food, proteins, fats, Carbohydrates, calories);

            return (product, weight);
        }

        /// <summary>
        /// Парсинг данных из консоли
        /// </summary>
        /// <returns> Дата рождения.</returns>
        private static DateTime ParseDate(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                    return birthDate;
                else
                    Console.WriteLine($"Неверный формат {value}");
            }
        }
 
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

