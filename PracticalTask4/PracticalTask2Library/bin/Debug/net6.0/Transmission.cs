namespace PracticalTask2Library
{
    /// <summary>
    /// Класс принимает характеристики трансмиссий авто для вывода на консоль.
    /// </summary>
    public class Transmission : Engine
    {
        /// <summary>
        /// Свойство TransType.
        /// </summary>
        public string? TransType { get; set; }       // тип трансмиссии

        /// <summary>
        /// Свойство Gear.
        /// </summary>
        public int Gear { get; set; }

        /// <summary>
        /// Свойство Manufacturer.
        /// </summary>
        public string? Manufacturer { get; set; }


        /// <summary>
        /// Выводит на консоль характеристики трансмиссий.
        /// </summary>
        public void PrintTransmission() => Console.WriteLine($"Трансмиссия" +
            $"\n\tТип: {TransType}" +
            $"\n\tКоличество передач: {Gear}" +
            $"\n\tПроизводитель: {Manufacturer}");
    }
}
