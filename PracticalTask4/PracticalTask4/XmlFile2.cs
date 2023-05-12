using PraciticalTask2Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticalTask4
{
    /// <summary>
    /// Класс представляет второй файл Xml.
    /// </summary>
    /// <remarks>
    /// Файл содержит информацию по типу двигателя, его серийного номера и 
    /// мощности всех грузовиков и автобусов.
    /// </remarks>
    class XmlFile2 : XmlFile
    {
        /// <summary>
        /// Переопределенное свойство Name.
        /// </summary>
        public override string? Name { get; set; }
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        public XmlFile2(string? name) : base(name) => Name = name;

        /// <summary>
        /// Событие, которое представляет делегат Action.
        /// </summary>
        /// <remarks>
        /// Уведомляет о действиях выполняемых над файлами.
        /// </remarks>
        public override event Action<XmlFile, XmlFileEventArgs>? Notify;


        /// <summary>
        /// Принимает объект выбранного транспорта и, используя его функционал, 
        /// добавляет элемент, соответствующий этому транспорту в файл.
        /// </summary>
        /// <param name="xRoot">Объект класса XElement.</param>
        /// <param name="transport">Выбранный транспорт.</param>
        /// <param name="suffix">Мера нагрузки.</param>
        public override void AddElement(XElement xRoot,
                                        Transport transport,
                                        string suffix)
        {
            // Добавление атрибутов и вложенных элементов.
            XElement autoElem = new("auto",
                new XAttribute("name", transport?.Name),
                new XElement("engine",
                    new XAttribute("power", $"{transport?.Engine?.Power} л/с"),
                    new XElement("capacity",
                                 $"{transport?.Engine?.Capacity} см.куб."),
                    new XElement("type", $"{transport?.Engine?.Type}"),
                    new XElement("serial_number",
                                 $"{transport?.Engine?.SerialNumber}")));

            // Добавление в корневой элемент.
            xRoot.Add(autoElem);

            // Сообщение о выполненном действии.
            Notify?.Invoke(this,
                           new($"Xml файл \"{Name}\": добавлен элемент "
                               + $"\"{transport?.Name}\""));
        }
    }
}
