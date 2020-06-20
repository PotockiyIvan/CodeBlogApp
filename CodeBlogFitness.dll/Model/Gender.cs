using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Отдельный класс создается для пола с заделом на буюущий уход от консоли
namespace CodeBlogFitness.dll.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
   public class Gender
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name"> Имя пола. </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));

            Name = name;
        }
        public override string ToString()//Переобределяем метод ToString ,чтобы удобнее видеть и представлять/
        {
            return Name;//Object.ToString является основным методом форматирования в .NET Framework.
            //Он преобразует объект в строковое представление, чтобы его можно было отображать. 
          // Реализации Object.ToString метода по умолчанию возвращают полное имя типа объекта.
        }
    }
}
