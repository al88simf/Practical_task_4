using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraciticalTask2Lib
{
    /// <summary>
    /// Абстрактный класс представляет единицу транспорта и ряд его свойств.
    /// </summary>
    public abstract class Transport
    {
        /// <summary>
        /// Абстрактное свойство Name.
        /// </summary>
        public abstract string? Name { get; set; }

        /// <summary>
        /// Астрактное свойство Engine.
        /// </summary>
        public abstract Engine? Engine { get; set; }

        /// <summary>
        /// Абстрактное свойство Transmission.
        /// </summary>
        public abstract Transmission? Transmission { get; set; }

        /// <summary>
        /// Абстрактное свойство Chassis.
        /// </summary>
        public abstract Chassis? Chassis { get; set; }

        public Transport(string? name,
                         Engine engine,
                         Transmission transmission,
                         Chassis chassis)
        {
            (Name, Engine, Transmission, Chassis) =
                (name, engine, transmission, chassis);
        }
    }
}
