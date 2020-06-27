using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.dll.Controller
{
    //Класс нужный для обобщения логики сереализации и дисериализации,чтобы избежать повторения кода
    //В классе usercontroller закоменчена старая реализация
    public abstract class ControllerBase
    {
        /// <summary>
        /// Сохранить данные.
        /// </summary>
        /// <param name="filename">Имя файла для сериализации.</param>
        /// <param name="item">Объект сериализации.</param>
        protected void Save(string filename,object item )
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
        /// <summary>
        /// Получить данные.
        /// </summary>
        /// <typeparam name="T"> Получаемые данные.</typeparam>
        /// <param name="filename"> Имя файла для десериализации.</param>
        /// <returns> List Users или List Foods. </returns>
        protected T Load<T>(string filename)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                    return items;
                else
                    return default(T);
            }
        }
    }
}
