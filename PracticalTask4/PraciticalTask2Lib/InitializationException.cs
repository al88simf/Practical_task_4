using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraciticalTask2Lib
{
    /// <summary>
    /// Класс представляет исключение InitializationException.
    /// </summary>
    /// <remarks>
    /// Срабатывает, при вводе значения с неправильным типом данных.
    /// </remarks>
    public class InitializationException : Exception
    {
        /// <summary>
        /// Свойство WrongInput.
        /// </summary>
        public string? WrongInput { get; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="message">Сообщение об ошибке.</param>
        /// <param name="wrongInput">Неправильный ввод.</param>
        public InitializationException(string message,
                                       string? wrongInput) : base(message)
        {
            WrongInput = wrongInput;
        }
    }
}
