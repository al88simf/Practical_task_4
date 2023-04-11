namespace PracticalTask2Library
{
    /// <summary>
    /// Класс принимает характеристики двигателей авто для вывода на консоль.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Свойство Power.
        /// </summary>
        public string Power { get; set; }

        /// <summary>
        /// Свойство Capacity.
        /// </summary>
        public string Capacity { get; set; }

        /// <summary>
        /// Свойство Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Свойство SerialNumber.
        /// </summary>
        public string SerialNumber { get; set; }


        /// <summary>
        /// Выводит на консоль характеристики двигателей.
        /// </summary>
        public void PrintEngine() => Console.WriteLine($"Двигатель" +
            $"\n\tМощность: {Power}" +
            $"\n\tОбъем: {Capacity}" +
            $"\n\tТип: {Type}" +
            $"\n\tСерийный номер: {SerialNumber}");
    }
}
