using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraciticalTask2Lib
{
    /// <summary>
    /// Класс принимает характеристики трансмиссий авто.
    /// </summary>
    public class Chassis
    {
        /// <summary>
        /// Свойство Weels.
        /// </summary>
        public int Weels { get; }

        /// <summary>
        /// Свойство Number.
        /// </summary>
        public string? Number { get; }

        /// <summary>
        /// Свойство Load.
        /// </summary>
        public int Load { get; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="weels">Количество колес.</param>
        /// <param name="number">Номер шасси.</param>
        /// <param name="load">Допустимая нагрузка.</param>
        public Chassis(string? weels, string? number, string? load)
        {
            if (!int.TryParse(weels, out var resultWeels))
            {
                throw new InitializationException("Введите значение корректно!",
                                                  weels);
            }
            else if (!int.TryParse(load, out var resultLoad))
            {
                throw new InitializationException("Введите значение корректно!",
                                                  load);
            }
            else
            {
                (Weels, Number, Load) = (resultWeels, number, resultLoad);
            }
        }
    }
}
