using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.dll.Model
{
    [Serializable]
    public class Activity
    {
        //Индентификатор для внедрения entity framework
        public int Id { get; set; }
        /// <summary>
        /// Название активности.
        /// </summary>
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        /// <summary>
        /// Кол-во калорий затрачиваемых в минуту.
        /// </summary>
        public double CaloriesPerMinute { get; set; }
        public Activity() { }

        public Activity(string name, double caloriesPerMinute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
