using PracticalTask2Library;
using System.Xml.Linq;

namespace PracticalTask4
{
    /// <summary>
    /// Класс представляет первый файл Xml.
    /// </summary>
    /// <remarks>
    /// Файл содержит полную информацию обо всех транспортных средствах, объем 
    /// двигателя которых больше 1,5 л.
    /// </remarks>
    class XmlFile1 : XmlFile
    {
        /// <summary>
        /// Переопределенное свойство Name.
        /// </summary>
        public override string? Name { get; set; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        public XmlFile1(string? name) : base(name) => Name = name;

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
        /// <param name="xRoot">Объект класса XElement</param>
        /// <param name="engine">Выбранный транспорт.</param>
        /// <param name="nameAttr">Атрибут "название транспорта".</param>
        /// <param name="suffix">Мера нагрузки.</param>
        public override void AddElement(XElement xRoot,
                                        Engine engine,
                                        string nameAttr, 
                                        string suffix)
        {
            // Метод вызывается как при заполнении первого файла, так и для 
            // третьего в силу его универсальности.
            Transmission? transm = engine as Transmission;
            Chassis? chassis = engine as Chassis;

            // Добавление атрибутов и вложенных элементов.
            XElement autoElem = new("auto", 
                new XAttribute("name", nameAttr),
                new XElement("engine", 
                    new XAttribute("power", $"{engine.Power} л/с"),
                    new XElement("capacity", $"{engine.Capacity} см.куб."),
                    new XElement("type", $"{engine.Type}"),
                    new XElement("serial_number", $"{engine.SerialNumber}")),
                new XElement("transmission",
                    new XAttribute("type", $"{transm?.TransType}"),
                    new XElement("gear", $"{transm?.Gear}"),
                    new XElement("manufacturer", $"{transm?.Manufacturer}")),
                new XElement("chassis",
                    new XAttribute("weels", $"{chassis?.Weels}"),
                    new XElement("number", $"{chassis?.Number}"),
                    new XElement("load", $"{chassis?.Load} {suffix}")));

            // Добавление в корневой элемент.
            xRoot.Add(autoElem);

            // Сообщение о выполненном действии.
            Notify?.Invoke(this,
                           new($"Xml файл \"{Name}\": добавлен элемент \"{nameAttr}\""));
        }
    }
}