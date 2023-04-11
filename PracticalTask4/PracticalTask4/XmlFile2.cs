using PracticalTask2Library;
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
        /// <param name="engine">Выбранный транспорт.</param>
        /// <param name="nameAttr">Атрибут "название транспорта".</param>
        /// <param name="suffix">Мера нагрузки.</param>
        public override void AddElement(XElement xRoot,
                                        Engine engine,
                                        string nameAttr, 
                                        string suffix)
        {
            // Добавление атрибутов и вложенных элементов.
            XElement autoElem = new("auto",
                new XAttribute("name", nameAttr),
                new XElement("engine",
                    new XAttribute("power", $"{engine.Power} л/с"),
                    new XElement("capacity", $"{engine.Capacity} см.куб."),
                    new XElement("type", $"{engine.Type}"),
                    new XElement("serial_number", $"{engine.SerialNumber}")));

            // Добавление в корневой элемент.
            xRoot.Add(autoElem);

            // Сообщение о выполненном действии.
            Notify?.Invoke(this,
                           new($"Xml файл \"{Name}\": добавлен элемент \"{nameAttr}\""));
        }
    }
}