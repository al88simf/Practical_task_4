namespace PracticalTask2Library
{
    /// <summary>
    /// Класс принимает характеристики шасси авто для вывода на консоль.
    /// </summary>
    public class Chassis : Transmission
    {
        /// <summary>
        /// Свойство Weels.
        /// </summary>
        public int Weels { get; set; }

        /// <summary>
        /// Свойство Number.
        /// </summary>
        public string? Number { get; set; }      // серийный номер

        /// <summary>
        /// Свойство Load.
        /// </summary>
        public string? Load { get; set; }


        /// <summary>
        /// Выводит на консоль характеристики шасси.
        /// </summary>
        public void PrintChassis() => Console.WriteLine($"Шасси" +
            $"\n\tКоличество колес: {Weels}" +
            $"\n\tНомер: {Number}" +
            $"\n\tДопустимая нагрузка: {Load}");
    }
}
