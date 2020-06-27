using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.dll.Model
{
    [Serializable]
    /// <summary>
    /// Прием пищи.
    /// </summary>
    public class Eating
    {
        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime Moment { get; }
        /// <summary>
        /// Прием пищи.
        /// </summary>
        public Dictionary<Food,double> Foods { get; }//Список словарь ключ(Food) - какая еда ,значение(double) - сколько еды
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть null.", nameof(User));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        /// <summary>
        /// Добавить прием пищи.
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
        public void Add(Food food,double weight)
        {
            //проверяем подходит ли ключ стловаря - тоесть название продукта к переданному значению
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            //если да,добавляем прием пищи
            if (product == null)
                Foods.Add(food, weight);
            ///если нет ,добавляем вес к уже существующему продукту
            else
                Foods[product] += weight;
        }

    }
}
