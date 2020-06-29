﻿using CodeBlogFitness.dll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.dll.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";

        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User User;

        /// <summary>
        /// Список упражнений
        /// </summary>
        public List<Exercise> Exercises { get; }

        /// <summary>
        /// Список активностей.
        /// </summary>
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.User = user ?? throw new ArgumentNullException("Пользователь не может быть null", nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        /// <summary>
        /// Добавить активность.
        /// </summary>
        /// <param name="activityName">Название активности.</param>
        /// <param name="start">Время начала активности.</param>
        /// <param name="finish">Время завершения активности.</param>
        public void Add(Activity activity, DateTime start,DateTime finish)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(start, finish, activity, User);
                Exercises.Add(exercise);                            
            }
            else
            {
                var exercise = new Exercise(start, finish, act, User);
                Exercises.Add(exercise);                
            }
            Save();
        }

        /// <summary>
        /// Получить упражнения.
        /// </summary>
        /// <returns></returns>
        private List<Exercise> GetAllExercises()
        {
            return base.Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        /// <summary>
        /// Получить активности.
        /// </summary>
        /// <returns></returns>
        private List<Activity> GetAllActivities()
        {
            return base.Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        /// <summary>
        /// Сохранить упражнения и активности.
        /// </summary>
        private void Save()
        {
            base.Save(EXERCISES_FILE_NAME, Exercises);
            base.Save(ACTIVITIES_FILE_NAME, Activities);

        }
    }
}

