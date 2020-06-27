using CodeBlogFitness.dll.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.dll.Controller
{
    //Контроллер пользователя для сохранения данных
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        //Константа нужная для рефакторинга,представляет имя документа для сериализации и десериализации.
        private const string USERS_FILE_NAME = "users.dat";

        /// <summary>
        /// Список пользователей приложения.
        /// </summary>
        /// Создаем список пользователей
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь приложения.
        /// </summary>
        public User CurrentUser { get; }

        //проверка(флаг) новый ли пользователь,если нет ,не используем,если да,то в конструкторе
        //присваеваем true и потом в мейне мы сможем используя это поле в if конструкции запросить
        //доп данные
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            
            Users = GetUserData();
            //Поиск нужного пользователя
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            //Если пользователь не найден,создаем нового.
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                IsNewUser = true;//флаг - так как пользователь новый(мы же в конструкторе),ставим true
                Users.Add(CurrentUser);//добавляем в коллекцию
            }
            else
                Console.WriteLine(CurrentUser.ToString());
        }

        /// <summary>
        /// Добавление новго пользователя.
        /// </summary>
        /// <param name="genderName">Пол.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public void SetNewUserData(string genderName,//Метод нужный для создания нового пользователя,чтобы инкапсулировать логику он определен
            DateTime birthDate,                      //в контроллере а не классе User или методе Main
            double weight = 1,
            double height = 1)
        {
            //здесь будет проверка
            //Присваиваем данные и сохраняем
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Сохранить пользователя.
        /// </summary>
        private void Save()
        {
            base.Save(USERS_FILE_NAME, Users);
        }

        /// <summary>
        /// Получить пользователя.
        /// </summary>
        /// <returns> Список пользователей. </returns>
        private  List<User> GetUserData()
        {
            return base.Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        #region Первоначальная реализация сериализации и десериализации без ControllerBAse
        //private List<User> GetUserData()
        //{
        //    var formatter = new BinaryFormatter();

        //    using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
        //    {
        //        //Если получилось загрузить список - возвращаем его
        //        //Если нет - мы возвращаем пустой список
        //        if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
        //            return users;
        //        else
        //            return new List<User>();
        //    }

        //}

        //public void Save()// можно было прописать возвращаемый тип bool и проверять прошла ли
        //                  //запись успешно,а так если не удастся сохранить мы получим exception
        //{
        //    #region Комментарии
        //    //Созданный экземпляр класса BinaryFormatter нужен для преобразования обьектов в
        //    //Байтовый поток данных для сохранения их в виде метаданных в файле в постоянной
        //    //памяти(все обьекты в процессе выполнения хранятся в оперативной памяти)
        //    //это и есть сериализация.
        //    #endregion
        //    var formatter = new BinaryFormatter();

        //    //здeсь мы делвем запись в файл,создаем поток ,передаем ему название для нашего файла
        //    //и метод,в данном случае OpenOrCreate либо откроет либо создаст нужный файл.            
        //    using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
        //    {
        //        #region Комментарии
        //        //это непосредственно сериализация,у экземпляра класса BinaryFormatter вызываем 
        //        //метод Serialize и передаем в качестве параметров наш поток fs и класс который
        //        //хотим сериализовать,у класса нужно прописать атрибут [Serializable],можно как
        //        //у всего класса так и у отдельных полей,свойств,методов.
        //        #endregion
        //        formatter.Serialize(fs, Users);
        //    }
        #endregion
    }


}

