namespace PraciticalTask2Lib
{
    /// <summary>
    /// Класс принимает характеристики двигателей авто.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Свойство Power.
        /// </summary>
        public int Power { get; }

        /// <summary>
        /// Свойство Capacity.
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// Свойство Type.
        /// </summary>
        public string? Type { get; }

        /// <summary>
        /// Свойство SerialNumber.
        /// </summary>
        public string? SerialNumber { get; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="power">Мощность.</param>
        /// <param name="capacity">Объем.</param>
        /// <param name="type">Тип двигателя (топливо).</param>
        /// <param name="serialNumber">Серийный номер.</param>
        public Engine(string? power,
                      string? capacity,
                      string? type,
                      string? serialNumber)
        {
            if (!int.TryParse(power, out var resultPower))
            {
                throw new InitializationException("Введите значение корректно!",
                                                  power);
            }
            else if (!int.TryParse(capacity, out var resultCapacity))
            {
                throw new InitializationException("Введите значение корректно",
                                                  capacity);
            }    
            else
            {
                Power = resultPower; Capacity = resultCapacity;
            }
            Type = type; SerialNumber = serialNumber;
        }
    }
}