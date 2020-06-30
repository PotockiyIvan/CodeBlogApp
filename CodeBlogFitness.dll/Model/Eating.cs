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
        //Индентификатор для внедрения entity framework
        public int Id { get; set; }

        /// <summary>
        /// Время приема пищи.
        /// </summary>
        public DateTime Moment { get; set; }
        /// <summary>
        /// Прием пищи.
        /// </summary>
        public Dictionary<Food,double> Foods { get; set; }//Список словарь ключ(Food) - какая еда ,значение(double) - сколько еды

        //Чтото для entity framework
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }

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
