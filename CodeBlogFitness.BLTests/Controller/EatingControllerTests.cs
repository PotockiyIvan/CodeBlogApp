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
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange(Обьявление)
            var userName = "Жора";
            var foodName = "Еда";
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName,
                                rnd.Next(50, 100),
                                rnd.Next(50, 100),
                                rnd.Next(50, 100),
                                rnd.Next(50, 100));

            // Act(Действие)
            eatingController.Add(food, 200);

            //Assert(Проверка)
            Assert.AreEqual(userController.CurrentUser.Name, userController.Users.First().Name);
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);


        }
    }
}