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
    //Тестирование(Правило трех А)
    //Arrange(Обьявление) - здесь мы задаем данные которые будут 
    //подаваться на вход и ожидаться на выходе.
    //Act(Действие) - здесь мы вызываем что - то.
    //Assert(Проверка) - проверяем то,что получилось c тем, что ожидалось.
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange(Обьявление)
            var userName = Guid.NewGuid().ToString();
            var gender = "man";
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var controller = new UserController(userName);


            //Act(Действие)
            controller.SetNewUserData(gender, (DateTime)birthDate, weight, height);
            var controller2 = new UserController(userName);//прочитали уже существующего пользователя


            //Assert(Проверка)//В данном случае каждого отдельного парраметра
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
           
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange(Обьявление)
            var userName = Guid.NewGuid().ToString();//Создаем пользователя с уникальным именем

            //Act(Действие)
            var controller = new UserController(userName);//Производим все заплонированные в конструкторе действия

            //Assert(Проверка) - этот класс содержит в себе набор проверок(утверждений которые мы должны проверять)
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            //Здесь сравниваются ожидаемый объект (userName) - который введет пользователь
            //и актуальный объект(controller.CurrentUser.Name)


        }
    }
}