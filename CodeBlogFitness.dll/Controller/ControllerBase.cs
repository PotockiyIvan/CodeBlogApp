using CodeBlogFitness.dll.Controller;
using System.Collections.Generic;


namespace CodeBlogFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        //manager является экземпляром класса IDataSaver ,а значит  в него мы
        //сможем подставить любой экземпляр реализующий этот интерфейс
        //Если заменить SerializableSaver на Databasesaver , мы будем 
        //сохранять данные не в текстовой файл а в базу данных
        private readonly IDataSaver manager = new SerializableSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}

//https://youtu.be/pRccKqC5D10?t=409 Момент в видео с объяснением