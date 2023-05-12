using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask4
{
    class XmlFileEventArgs
    {
        /// <summary>
        /// Хранилище свойства Message.
        /// </summary>
        string? message;    // текст сообщения

        /// <summary>
        /// Свойство Message.
        /// </summary>
        public string? Message
        {
            get => message;
            set => message = value;
        }
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        public XmlFileEventArgs(string? message) => this.message = message;
    }
}
