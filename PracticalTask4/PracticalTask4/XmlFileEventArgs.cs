namespace PracticalTask4
{
    /// <summary>
    /// Класс представляет аргументы для события.
    /// </summary>
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