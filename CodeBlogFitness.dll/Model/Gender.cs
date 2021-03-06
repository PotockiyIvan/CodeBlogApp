﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Отдельный класс создается для пола с заделом на буюущий уход от консоли
namespace CodeBlogFitness.dll.Model
{
    [Serializable]
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {
        //Индентификатор для внедрения entity framework
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public Gender() { }

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
