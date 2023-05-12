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
    /// Абстрактный класс представляет Xml файл и ряд общих членов.
    /// </summary>
    /// <remarks>
    /// Члены не имеют реализаци - они реализуюся в производных классах.
    /// </remarks>
    abstract class XmlFile
    {
        /// <summary>
        /// Абстрактное свойство Name.
        /// </summary>
        public abstract string? Name { get; set; }
        
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        public XmlFile(string? name) => Name = name;

        /// <summary>
        /// Событие, которое представляет делегат Action.
        /// </summary>
        /// <remarks>
        /// Уведомляет о действиях выполняемых над файлами.
        /// </remarks>
        public abstract event Action<XmlFile, XmlFileEventArgs>? Notify;

        /// <summary>
        /// Абстрактный метод.
        /// </summary>
        /// <remarks>
        /// Принимает объект выбранного транспорта и, используя его функционал, 
        /// добавляет элемент, соответствующий этому транспорту в файл.
        /// </remarks>
        /// <param name="xRoot">Объект класса XElement.</param>
        /// <param name="transport">Выбранный транспорт.</param>
        /// <param name="suffix">Мера нагрузки.</param>
        public abstract void AddElement(XElement xRoot,
                                        Transport transport,
                                        string suffix);
    }
}
