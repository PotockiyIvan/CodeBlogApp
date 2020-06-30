using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.dll.Model
{
    [Serializable]
    public class Exercise
    {
        #region свойства
        //Индентификатор для внедрения entity framework
        public int Id { get; set; }
        
        /// <summary>
        /// Начало упражнения.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Конец упражнения.
        /// </summary>
        public DateTime Finish { get; set; }

        //Чтото для entity framework
        public int ActivityId { get; set; }

        /// <summary>
        ///  Активность.
        /// </summary>
        public virtual Activity Activity { get; set; }

        //Чтото для entity framework
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }
        #endregion

        public Exercise(DateTime start,
                        DateTime finish,
                        Activity activity,
                        User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
