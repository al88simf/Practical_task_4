using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask4
{
    /// <summary>
    /// Класс представляет исключение AddException.
    /// </summary>
    /// <remarks>
    /// Срабатывает, если нельзя добавить транспорт в коллекцию.
    /// </remarks>
    public class AddException : Exception
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        public AddException(string message) : base(message) { }
    }
}
