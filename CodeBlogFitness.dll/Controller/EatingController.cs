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
        //Константа представляет имя документа для сериализации и десериализации.
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

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
            //проверка на всякий случай
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        /// <summary>
        /// Сохранить прием пищи.
        /// Сохранить продукт.
        /// </summary>
        private void Save()
        {
            base.Save(EATINGS_FILE_NAME, Eating);
            base.Save(FOODS_FILE_NAME, Foods);
        }
        /// <summary>
        /// Получить прием пищи.
        /// </summary>
        /// <returns> Список продуктов.</returns>
        private Eating GetEating()
        {
            return base.Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        /// <summary>
        /// Получить продукт.
        /// </summary>
        /// <returns> Список продуктов.</returns>
        private List<Food> GetAllFoods()
        {
            return base.Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

    }
}
