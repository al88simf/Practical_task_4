using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraciticalTask2Lib
{
    /// <summary>
    /// Класс представляет исключение GetAutoByParameterException.
    /// </summary>
    /// <remarks>
    /// Срабатывает, если введенное значение параметра поиска в коллекции не 
    /// существует.
    /// </remarks>
    public class GetAutoByParameterException : Exception
    {
        /// <summary>
        /// Свойство WrongParam.
        /// </summary>
        public string? WrongParam { get; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        /// <param name="wrongParam">Неверное значение.</param>
        public GetAutoByParameterException(string? message,
                                           string? wrongParam) : base(message)
        {
            WrongParam = wrongParam;
        }
    }
}
