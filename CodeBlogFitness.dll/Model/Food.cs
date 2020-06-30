using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.dll.Model
{
    [Serializable]
    /// <summary>
    /// Продукт.
    /// </summary>
    public class Food
    {
        //Индентификатор для внедрения entity framework
        public int Id { get; set; }

        #region Свойства
        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Калории на 100г. продукта.
        /// </summary>
        public double Callories { get; set; }
        #endregion

        public virtual ICollection<Eating> Eatings { get; set; }
        public Food() { }

        #region Приватные свойства нужные для рассчетов было решено заменить на деление в конструкторе
        ///// <summary>
        ///// Белки на 1г. продукта.
        ///// </summary>
        //private double ProteinsPerOneGrramm { get { return Proteins / 100.0; } }
        ///// <summary>
        ///// Жиры на 1г. продукта.
        ///// </summary>
        //private double FatsPerOneGrramm { get { return Fats / 100.0; } }
        ///// <summary>
        ///// Углеводы на 1г. gпродукта.
        ///// </summary>
        //private double CarbohydratesPerOneGrramm { get { return Carbohydrates / 100.0; } }
        ///// <summary>
        ///// Калории на 1г. продукта.
        ///// </summary>
        //private double CalloriesPerOneGramm { get => Callories / 100; }
        #endregion

        /// <summary>
        /// Добавление готового продукта.
        /// </summary>
        /// <param name="name"> Название продукта. </param>
        public Food(string name) : this(name, 0, 0, 0, 0) { }
       
        /// <summary>
        /// Добавление нового продукта.
        /// </summary>
        /// <param name="name"> Название продукта. </param>
        /// <param name="proteins"> Белки. </param>
        /// <param name="fats"> Жиры. </param>
        /// <param name="carbohydrates"> Углеводы.</param>
        /// <param name="callories"> Калории. </param>
        public Food(string name,
                    double proteins,
                    double fats,
                    double carbohydrates,
                    double callories)
        {
            //TODO: Проверка
            //Делим на 100 для расчетов для 1г. продукта
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Callories = callories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
