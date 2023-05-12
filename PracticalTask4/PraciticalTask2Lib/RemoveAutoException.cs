using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraciticalTask2Lib
{
    /// <summary>
    /// Класс представляет исключение RemoveAutoException.
    /// </summary>
    /// <remarks>
    /// Срабатывает при попытке удалить одну из последних 4 единиц транспорта 
    /// в коллекции.
    /// </remarks>
    public class RemoveAutoException : Exception
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        public RemoveAutoException(string? message) : base(message) { }
    }
}
