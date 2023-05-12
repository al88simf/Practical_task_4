using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraciticalTask2Lib
{
    /// <summary>
    /// Класс представляет исключение UpdateAutoException.
    /// </summary>
    /// <remarks>
    /// Срабатывает если введенное значение названия транспорта отсутствует в 
    /// коллекции и его нельзя заменить.
    /// </remarks>
    public class UpdateAutoException : Exception
    {
        /// <summary>
        /// Свойство InvalidAuto.
        /// </summary>
        public string? InvalidAuto { get; }
        
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        /// <param name="invalidAuto">Отсутствующий автомобиль.</param>
        public UpdateAutoException(string? message,
                                   string? invalidAuto) : base(message)
        {
            InvalidAuto = invalidAuto;
        }
    }
}
