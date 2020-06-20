﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.dll.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        #region Свойства.
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }//имя пользователя можно будет установить лишь раз 
                                   //при создании экземпляра класса так как сеттера нет.
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }//так же и здесь,для избежания ошибок. 
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        #endregion

        //В конструкторе организовывается проверка данных введенных пользователем,при некоректности данных выкидываем исключения.
        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name,
                      Gender gender,
                      DateTime birthDate,
                      double weight,
                      double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));

            if (Gender == null)
                throw new ArgumentNullException("Пол не может быть null.", nameof(gender));

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));

            if (weight <= 0)
                throw new ArgumentException("Вес не может быть меньше либо равен нулю.", nameof(weight));

            if (height <= 0)
                throw new ArgumentException("Рост не может быть меньше либо равен нулю.", nameof(height));
            #endregion //используется регион,для сокрытия куска кода для удобства.

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()//снова переопределяем ToString.
        {
            return Name;
        }
    }
}