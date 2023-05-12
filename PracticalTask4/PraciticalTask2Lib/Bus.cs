using PracticalTask4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraciticalTask2Lib
{
    /// <summary>
    /// Класс представляет автобус.
    /// </summary>
    public class Bus : Transport
    {
        /// <summary>
        /// Хранилище свойства Name.
        /// </summary>
        string? name;

        /// <summary>
        /// Свойство Name.
        /// </summary>
        public override string? Name
        {
            get => name;
            set
            {
                if (value?.Length < 2) throw new AddException("Имя должно " +
                    "состоять минимум из 3 символов.");
                else name = value;
            }
        }

        /// <summary>
        /// Свойство Engine.
        /// </summary>
        public override Engine? Engine { get; set; }

        /// <summary>
        /// Свойство Transmission.
        /// </summary>
        public override Transmission? Transmission { get; set; }

        /// <summary>
        /// Свойство Chassis.
        /// </summary>
        public override Chassis? Chassis { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Название автомобиля.</param>
        /// <param name="engine">Тип Engine.</param>
        /// <param name="transmission">Тип Transmission.</param>
        /// <param name="chassis">Тип Chassis.</param>
        public Bus(string? name,
                   Engine engine,
                   Transmission transmission,
                   Chassis chassis) : base(name,
                                           engine,
                                           transmission,
                                           chassis)
        {
            (Name, Engine, Transmission, Chassis) =
                (name, engine, transmission, chassis);
        }
    }
}
