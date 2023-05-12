using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraciticalTask2Lib
{
    /// <summary>
    /// Класс принимает харатеристики трансмиссий авто.
    /// </summary>
    public class Transmission
    {
        /// <summary>
        /// Свойство TransType.
        /// </summary>
        public string? Type { get; }      // тип трансмиссии

        /// <summary>
        /// Свойство Gear.
        /// </summary>
        public int Gear { get; }

        /// <summary>
        /// Свойство Manufacturer.
        /// </summary>
        public string? Manufacturer { get; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="transType">Тип трансмиссии.</param>
        /// <param name="gear">Количество передач.</param>
        /// <param name="manufacturer">Производитель.</param>
        public Transmission(string? type, string? gear, string? manufacturer)
        {
            Type = type;
            if (!int.TryParse(gear, out var resultGear))
            {
                throw new InitializationException("Введите значение корректно!",
                                                  gear);
            }
            else
            {
                Gear = resultGear;
            }
            Manufacturer = manufacturer;
        }
    }
}
