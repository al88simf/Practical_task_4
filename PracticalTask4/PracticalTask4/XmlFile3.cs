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
    /// Класс представляе третий файл Xml.
    /// </summary>
    /// <remarks>
    /// Файл содержит полную информацию обо всех транспортных средствах, 
    /// сгруппированных по типу трансмиссии.
    /// </remarks>
    class XmlFile3 : XmlFile
    {
        /// <summary>
        /// Переопределенное свойство Name.
        /// </summary>
        public override string? Name { get; set; }
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Имя файла.</param>
        public XmlFile3(string? name) : base(name) => Name = name;

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
        /// <remarks>
        /// Данный метод не вызывается.
        /// </remarks>
        /// <param name="xRoot">Объект класса XElement</param>
        /// <param name="engine">Выбранный транспорт.</param>
        /// <param name="suffix">Мера нагрузки.</param>
        public override void AddElement(XElement xRoot,
                                        Transport transport,
                                        string suffix)
        { }

        /// <summary>
        /// Генерирует сообщение об успешном завершении работы над файлами.
        /// </summary>
        public void MakeFinalMes()
        {
            Notify?.Invoke(this, new("Все файлы успешно сохранены."));
        }
    }
}
