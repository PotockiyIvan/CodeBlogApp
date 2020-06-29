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
        /// <summary>
        /// Начало упражнения.
        /// </summary>
        public DateTime Start { get; }
        /// <summary>
        /// Конец упражнения.
        /// </summary>
        public DateTime Finish { get; }
        /// <summary>
        ///  Активность.
        /// </summary>
        public Activity Activity { get; }
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }
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
