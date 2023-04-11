using PracticalTask2Library;
using System.Xml.Linq;

namespace PracticalTask4
{
    /// <summary>
    /// Класс предназначен для вывода информации по определенным критериям в Xml
    /// файлы.
    /// </summary>
    /// <remarks>
    /// Класс использует классы из практического задания 2 и с их помощью заполняет 
    /// три Xml файла по следующим критериям:
    /// 1-й файл заполняется полной информацией обо всех транспортных средствах, 
    /// объем двигателя которых превышает 1,5 л;
    /// 2-й файл заполняется информацией по типу двигателя, серийному номеру и его 
    /// мощности для грузовиков и автобусов;
    /// 3-й файл заполняется полной информацией обо всех транспортных средствах, 
    /// сгруппированной по типу трансмиссии.
    /// </remarks>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Список аргументов для командной строки.</param>
        static void Main(string[] args)
        {
            Name auto = new();
            XDocument document1 = new();
            XDocument document2 = new();
            XDocument document3 = new();
            XElement root1 = new("transport");   // корень файла
            XElement root2 = new("transport");
            XElement root3 = new("transport");

            var files = new XmlFile[]           // файлы
            {
                new XmlFile1("TransEngineMoreThan1500.xml"),
                new XmlFile2("EngineOfTruckAndBus.xml"),
                new XmlFile3("TransmissionInfo.xml")
            };
            List<Engine> transport = new()
            {
                new Chassis             // легковой автомобиль
                {
                    Power = "68",       // л/с
                    Capacity = "1294",  // см.куб.
                    Type = "бензиновый",
                    SerialNumber = "Н0123456",

                    TransType = "механическая",
                    Gear = 5,
                    Manufacturer = "ВАЗ",

                    Weels = 4,
                    Number = "ХТА210500",
                    Load = "400"        // кг
                },
                new Chassis             // грузовик
                {
                    Power = "180",
                    Capacity = "11150",
                    Type = "дизельный",
                    SerialNumber = "В01234567",

                    TransType = "механическая",
                    Gear = 5,
                    Manufacturer = "ЯМЗ",

                    Weels = 4,
                    Number = "0123456",
                    Load = "10"         // т
                },
                new Chassis             // автобус
                {
                    Power = "121", 
                    Capacity = "4570", 
                    Type = "дизельный с турбо-наддувом", 
                    SerialNumber = "N01234567", 

                    TransType = "механическая, синхронизированная", 
                    Gear = 4, 
                    Manufacturer = "ISUZU", 

                    Weels = 4, 
                    Number = "0123456", 
                    Load = "8"
                }, 
                new Chassis             // скутер
                {
                    Power = "12", 
                    Capacity = "155", 
                    Type = "бензиновый", 
                    SerialNumber = "01234", 

                    TransType = "механическая", 
                    Gear = 4, 
                    Manufacturer = "Vespa", 

                    Weels = 2, 
                    Number = "012345", 
                    Load = "150"
                } 
            };
            // Цикл, по мере перебора файлов, заполняет их соответствующей
            // информацией и сохраняет.
            foreach (var file in files)
            {
                // Подписывает на обработчик, выводящий сообщение на консоль.
                file.Notify += (sender, e) => Console.WriteLine(e.Message);

                // Выбор первого файла.
                if (file is XmlFile1 file1 && file1 is not null)
                {
                    for (int i = 0; i < transport.Count; i++)
                    {
                        var name = auto[i];     // название авто

                        // Выбор транспорта, у которого объем двигателя больше 1,5л
                        // (1500 см.куб.).
                        if (int.Parse(transport[i].Capacity) > 1500)
                        {
                            // Правильное обозначение нагрузки.
                            string suff = GetSuffix(transport[i]);
                            
                            file1.AddElement(root1, transport[i], name, suff);
                        }
                    }
                    document1.Add(root1);
                    document1.Save(file1.Name);
                }
                // Выбор второго файла.
                else if (file is XmlFile2 file2 && file2 is not null)
                {
                    for (int i = 0; i < transport.Count; i++)
                    {
                        var name = auto[i];

                        // Выбор грузовиков и автобусов и вывод информации по
                        // их двигателям.
                        if (i == 1 || i == 2)
                        {
                            file2.AddElement(root2, transport[i], name, "");
                        }
                    }
                    document2.Add(root2);
                    document2.Save(file2.Name);
                }
                // Выбор третьего файла.
                else if (file is XmlFile3 file3 && file3 is not null)
                {
                    // Вызывается метод первого файла, т.к. он более универсален.
                    XmlFile1 xmlFile3 = new(file3.Name);

                    // Повторно подписывает на обработчик, т.к. вызывается
                    // через новый объект.
                    xmlFile3.Notify += (s, e) => Console.WriteLine(e.Message);

                    // Сначала перебор по механическим.
                    for (int i = 0; i < transport.Count; i++)
                    {
                        var name = auto[i];

                        string suff = GetSuffix(transport[i]);
                        var transmission = transport[i] as Transmission;

                        // Выбор транспорта по типу трансмиссии.
                        if (transmission?.TransType == "механическая")
                        {
                            xmlFile3.AddElement(root3, transport[i], name, suff);
                        }
                    }
                    for (int i = 0; i < transport.Count; i++)
                    {
                        var name = auto[i];

                        string suff = GetSuffix(transport[i]);
                        var transmission = transport[i] as Transmission;

                        if (transmission?.TransType != "механическая")
                        {
                            xmlFile3.AddElement(root3, transport[i], name, suff);
                        }
                    }
                    document3.Add(root3);
                    document3.Save(file3.Name);
                    file3.MakeFinalMes();
                }
            }
            Console.ReadKey();


            // Принимает выбранный транспорт и возвращает меру нагрузки в
            // соответствии с объемом двигателя.
            static string GetSuffix(Engine engine)
            {
                var capacity = int.Parse(engine.Capacity);
                
                return capacity > 1500 ? "т" : "кг";
            }
        }
    }
}