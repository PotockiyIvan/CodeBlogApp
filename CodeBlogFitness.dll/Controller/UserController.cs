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
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        public UserController(
            string userName,
            string genderName,
            DateTime birthDay,
            double weight,
            double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()// можно было прописать возвращаемый тип bool и проверять прошла ли
                          //запись успешно,а так если не удастся сохранить мы получим exception
        {
            #region Комментарии
            //Созданный экземпляр класса BinaryFormatter нужен для преобразования обьектов в
            //Байтовый поток данных для сохранения их в виде метаданных в файле в постоянной
            //памяти(все обьекты в процессе выполнения хранятся в оперативной памяти)
            //это и есть сериализация.
            #endregion
            var formatter = new BinaryFormatter();

            //здeсь мы делвем запись в файл,создаем поток ,передаем ему название для нашего файла
            //и метод,в данном случае OpenOrCreate либо откроет либо создаст нужный файл.            
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                #region Комментарии
                //это непосредственно сериализация,у экземпляра класса BinaryFormatter вызываем 
                //метод Serialize и передаем в качестве параметров наш поток fs и класс который
                //хотим сериализовать,у класса нужно прописать атрибут [Serializable],можно как
                //у всего класса так и у отдельных полей,свойств,методов.
                #endregion
                formatter.Serialize(fs, User);
            }

        }
        //здесь будет десериализация,тоесть запись состояния в объекты

        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                //Возвращаем данные,если их не будет - вернем null.
                if (formatter.Deserialize(fs) is User user)
                    User = user;
            }
            // TODO: Что делать , если пользователя не прочитали.
        }

        //Это другой вариант записи,не через консруктор и создание экземпляра класса
        //а через передачу информации из файла в качестве экдемпляра класса.
        //public User Load()
        //{
        //    var formatter = new BinaryFormatter();

        //    using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
        //    {
        //       //Возвращаем данные,если их не будет - вернем null.
        //        return formatter.Deserialize(fs) as User;                               
        //    }
        //}
    }
}
