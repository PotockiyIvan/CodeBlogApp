using CodeBlogFitness.BL.Controller;
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
    /// <summary>
    /// Контроллер приема пищи.
    /// </summary>
    public class EatingController : ControllerBase
    {

        private readonly User user;
        /// <summary>
        /// Список продуктов.
        /// </summary>
        public List<Food> Foods { get; }
        /// <summary>
        /// Прием пищи.
        /// </summary>
        public Eating Eating { get; }

        //Конструктор вы
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();
        }  
        
        /// <summary>
        /// Добавление приема пищи.
        /// </summary>
        /// <param name="food"> Продукт.</param>
        /// <param name="weight"> Вес Продукта.</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);              
            }
            else            
                Eating.Add(product, weight);              
            
            Save();
        }

        /// <summary>
        /// Сохранить прием пищи.
        /// Сохранить продукт.
        /// </summary>
        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>() { Eating });
        }
        /// <summary>
        /// Получить прием пищи.
        /// </summary>
        /// <returns> Список продуктов.</returns>
        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        /// <summary>
        /// Получить продукт.
        /// </summary>
        /// <returns> Список продуктов.</returns>
        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

    }
}
