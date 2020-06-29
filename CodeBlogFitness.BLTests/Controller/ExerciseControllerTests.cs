using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.dll.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.dll.Model;

namespace CodeBlogFitness.dll.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        

        [TestMethod()]
        public void AddTest()
        {

            //Arrange(Обьявление)
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10,50));

            // Act(Действие)
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddMinutes(30));

            //Assert(Проверка)            
            Assert.AreEqual(activity.Name, exerciseController.Activities.First().Name);

        }
    }
}