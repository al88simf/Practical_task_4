using PraciticalTask2Lib;
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
            // Содежит 4 типа транспорта по-умолчанию.
            var transports = new List<Transport>()
            {
                new Car("Легковой автомобиль ВАЗ-2105 \"Жигули\"",
                    new Engine("68",          // л/с
                               "1294",        // кг.см/куб.
                               "бензиновый",
                               "Н0123456"), 
                    new Transmission("механическая", "5", "ВАЗ"),
                    new Chassis("4",
                                "XTA210500",
                                "400")),      // кг
                new Truck("Грузовик МАЗ-500",
                    new Engine("180", "11150", "дизельный", "В01234567"), 
                    new Transmission("механическая", "5", "ЯМЗ"), 
                    new Chassis("4",
                                "0123456",
                                "10")),       // т
                new Bus("Автобус А092 \"Богдан\"", 
                    new Engine("121",
                               "4570",
                               "дизельный с турбо-наддувом",
                               "N01234567"), 
                    new Transmission("механическая, синхронизированная",
                                     "4",
                                     "ISUZU"), 
                    new Chassis("4",
                                "0123456",
                                "8")),        // т
                new Scooter("Скутер Vespa Primavera 150", 
                    new Engine("180", "11150", "бензиновый", "01234"), 
                    new Transmission("механическая", "4", "Vespa"), 
                    new Chassis("2",
                                "012345",
                                "150"))       // кг
            };
            while (true)
            {
                try
                {
                    Console.Write($"В настоящий момент автопарк имеет "
                        + $"{transports.Count} автомобилей. \nВведите действие, "
                        + $"которое хотите осуществить над автомобилем из автопарка:"
                        + $"\n\t- Добавить новый"
                        + $"\n\t- Получить полную информацию"
                        + $"\n\t- Заменить"
                        + $"\n\t- Удалить"
                        + $"\n: ");
                    var input = Console.ReadLine();     // введенное значение
                    Transport? auto;                    // выбранный автомобиль
                    switch (input)
                    {
                        case "Добавить новый":
                            {
                                // Добавление большого количества транспорта.
                                while (true)
                                {
                                    Console.Write("Чтобы добавить транспорт, " +
                                        "нажмите \"+\", чтобы выйти, нажмите " +
                                        "\"x\":\n\t");
                                    var sign = Console.ReadLine();
                                    if ((sign is not null) && (sign == "+"))
                                    {
                                        auto = SelectOperation(Operation.Add);
                                        transports.Add(auto);
                                        Console.WriteLine($"Автомобиль " +
                                            $"{auto.Name} добавлен в автопарк.");
                                    }
                                    else break;
                                }
                                break;
                            }
                        case "Получить полную информацию":
                            {
                                auto = SelectOperation(Operation.Search);
                                PrintParam(auto);
                                break;
                            }
                        case "Заменить":
                            {
                                auto = SelectOperation(Operation.Update);
                                Console.WriteLine($"Замена произведена на " +
                                    $"автомобиль {auto?.Name}");
                                break;
                            }
                        case "Удалить":
                            {
                                auto = SelectOperation(Operation.Remove);
                                Console.WriteLine($"Автомобиль {auto?.Name} " +
                                    $"удален.");
                                break;
                            }
                        default:
                            throw new InitializationException("Введите " +
                                "значение корректно!", input);
                    }
                    break;
                }
                catch (InitializationException ex)
                {
                    Console.WriteLine($"Неверное значение {ex.WrongInput}");
                    Console.WriteLine(ex.Message);
                }
            }


            // Цикл, по мере перебора файлов, заполняет их соответствующей
            // информацией и сохраняет.
            foreach (var file in files)
            {
                // Подписывает на обработчик, выводящий сообщение на консоль.
                file.Notify += (sender, e) => Console.WriteLine(e.Message);

                // Выбор первого файла.
                if ((file is XmlFile1 file1) && (file1 is not null))
                {
                    foreach (var transport in transports)
                    {
                        string suff = GetSuffix(transport);
                        
                        // Выбор транспорта, у которого объем двигателя больше 1,5л
                        // (1500 см.куб.).
                        if (transport?.Engine?.Capacity > 1500)
                        {
                            file1.AddElement(root1, transport, suff);
                        }
                    }
                    document1.Add(root1);
                    document1.Save(file1?.Name);
                }
                // Выбор второго файла.
                else if ((file is XmlFile2 file2) && (file2 is not null))
                {
                    foreach (var transport in transports)
                    {
                        // Выбор грузовиков и автобусов и вывод информации по
                        // их двигателям.
                        if ((transport is Truck) || (transport is Bus))
                        {
                            file2.AddElement(root2, transport, "");
                        }
                    }
                    document2.Add(root2);
                    document2.Save(file2?.Name);
                }
                // Выбор третьего файла.
                else if ((file is XmlFile3 file3) && (file3 is not null))
                {
                    // Вызывается метод первого файла, т.к. он более универсален.
                    XmlFile1 xmlFile3 = new(file3.Name);

                    // Повторно подписывает на обработчик, т.к. вызывается
                    // через новый объект.
                    xmlFile3.Notify += (s, e) => Console.WriteLine(e.Message);

                    // Сначала перебор по механическим.
                    foreach (var transport in transports)
                    {
                        string suff = GetSuffix(transport);

                        // Выбор транспорта по типу трансмиссии.
                        if ((transport?.Transmission?.Type == "механическая") &&
                            (transport is not null))
                        {
                            xmlFile3.AddElement(root3, transport, suff);
                        }
                    }
                    foreach (var transport in transports)
                    {
                        string suff = GetSuffix(transport);

                        if ((transport?.Transmission?.Type != "механическая") &&
                            (transport is not null))
                        {
                            xmlFile3.AddElement(root3, transport, suff);
                        }
                    }
                    document3.Add(root3);
                    document3.Save(file3?.Name);
                    file3.MakeFinalMes();
                }
            }


            // Принимает выбранный транспорт и возвращает меру нагрузки в
            // соответствии с объемом двигателя.
            static string GetSuffix(Transport? transport)
            {
                var capacity = transport?.Engine?.Capacity;

                return capacity > 1500 ? "т" : "кг";
            }

            // Принимает выбранное значение перечисления и возвращает 
            // соответствующий метод.
            Transport? SelectOperation(Operation operation)
            {
                switch (operation)
                {
                    case Operation.Add: return GetNew();
                    case Operation.Search: return Search(transports);
                    case Operation.Update: return Update(transports);
                    default: return Remove(transports);
                }
            }

            // Обеспечивает вывод полной информации по найденному транспорту.
            static void PrintParam(Transport? auto)
            {
                string suff = GetSuffix(auto);

                Console.WriteLine($"Название автомобиля: {auto?.Name}");
                Console.WriteLine($"Характеристики двигателя: " +
                    $"\n\t- Мощность: {auto?.Engine?.Power} л/с;" +
                    $"\n\t- Объем: {auto?.Engine?.Capacity} кг.см/куб.;" +
                    $"\n\t- Тип: {auto?.Engine?.Type};" +
                    $"\n\t- Сериный номер: {auto?.Engine?.SerialNumber}.");
                Console.WriteLine($"Характеристики трансмиссии: " +
                    $"\n\t- Тип: {auto?.Transmission?.Type};" +
                    $"\n\t- Количество передач: {auto?.Transmission?.Gear};" +
                    $"\n\t- Производитель: {auto?.Transmission?.Manufacturer}.");
                Console.WriteLine($"Характеристики шасси: " +
                    $"\n\t- Количество колес: {auto?.Chassis?.Weels};" +
                    $"\n\t- Номер: {auto?.Chassis?.Number};" +
                    $"\n\t- Допустимая нагрузка: {auto?.Chassis?.Load} {suff}.");
            }
        }

        /// <summary>
        /// Метод получает параметры новой единицы транспорта и создает его 
        /// объект.
        /// </summary>
        /// <returns>Объект выбранного транспорта.</returns>
        /// <exception cref="InitializationException">
        /// Исключение InitializationExpression.
        /// </exception>
        /// <exception cref="NullReferenceException">
        /// Исключение NullReferenceExpression.
        /// </exception>
        public static Transport GetNew()
        {
            // Цикл повторяется, если произошло выбрасывание исключения.
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите тип транспорта: "
                                      + "\n\t\"- Легковой автомобиль\""
                                      + "\n\t\"- Грузовик\""
                                      + "\n\t\"- Автобус\""
                                      + "\n\t\"- Скутер\"");
                    var input = Console.ReadLine();     // введенное значение

                    switch (input)
                    {
                        case "Легковой автомобиль":
                            {
                                while (true)
                                {
                                    try
                                    {
                                        var param = GetArgs(input);  // параметры
                                        return new Car(param.name,
                                            new Engine(param.power,
                                                       param.capacity,
                                                       param.engType,
                                                       param.engNumber),
                                            new Transmission(param.transType,
                                                             param.gear,
                                                             param.manufacturer),
                                            new Chassis(param.weels,
                                                        param.chassisNumber,
                                                        param.load));
                                    }
                                    catch (AddException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (InitializationException ex)
                                    {
                                        Console.WriteLine($"Неверное значение " +
                                            $"{ex.WrongInput}");
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                            }
                        case "Грузовик":
                            {
                                while (true)
                                {
                                    try
                                    {
                                        var param = GetArgs(input);
                                        return new Truck(param.name,
                                            new Engine(param.power,
                                                       param.capacity,
                                                       param.engType,
                                                       param.engNumber),
                                            new Transmission(param.transType,
                                                             param.gear,
                                                             param.manufacturer),
                                            new Chassis(param.weels,
                                                        param.chassisNumber,
                                                        param.load));
                                    }
                                    catch (AddException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (InitializationException ex)
                                    {
                                        Console.WriteLine($"Неверное значение " +
                                            $"{ex.WrongInput}");
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                            }
                        case "Автобус":
                            {
                                while (true)
                                {
                                    try
                                    {
                                        var param = GetArgs(input);
                                        return new Bus(param.name,
                                            new Engine(param.power,
                                                       param.capacity,
                                                       param.engType,
                                                       param.engNumber),
                                            new Transmission(param.transType,
                                                             param.gear,
                                                             param.manufacturer),
                                            new Chassis(param.weels,
                                                        param.chassisNumber,
                                                        param.load));
                                    }
                                    catch (AddException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (InitializationException ex)
                                    {
                                        Console.WriteLine($"Неверное значение " +
                                            $"{ex.WrongInput}");
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                            }
                        case "Скутер":
                            {
                                while (true)
                                {
                                    try
                                    {
                                        var param = GetArgs(input);
                                        return new Scooter(param.name,
                                            new Engine(param.power,
                                                       param.capacity,
                                                       param.engType,
                                                       param.engNumber),
                                            new Transmission(param.transType,
                                                             param.gear,
                                                             param.manufacturer),
                                            new Chassis(param.weels,
                                                        param.chassisNumber,
                                                        param.load));
                                    }
                                    catch (AddException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (InitializationException ex)
                                    {
                                        Console.WriteLine($"Неверное значение " +
                                            $"{ex.WrongInput}");
                                    }
                                }
                            }
                        default:
                            {
                                if (input != null)
                                {
                                    throw new InitializationException
                                        ("Введите значение корректно!",
                                         input);
                                }
                                else
                                    throw new NullReferenceException
                                        ("Ввод отсутствует.");
                            }
                    }
                }
                catch (InitializationException ex)
                {
                    Console.WriteLine($"Некорректное значение {ex.WrongInput}");
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    // Для любого другого типа исключения.
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Принимает из консоли параметры выбранного транспорта и возвращает 
        // кортеж переменных, которые их хранят.
        static (string? name, 
                string? power, 
                string? capacity,
                string? engType, 
                string? engNumber, 
                string? transType, 
                string? gear, 
                string? manufacturer, 
                string? weels, 
                string? chassisNumber, 
                string? load) GetArgs(string input)
        {
            Console.Write("Введите название модели автомобиля: ");

            // Добавляет в название выбранный тип автомобиля.
            var inputName = input + " " + Console.ReadLine();   // модель

            // Параметры двигателя.
            Console.Write("\nВведите значение мощности автомобиля, л/с: ");
            var inputPower = Console.ReadLine();            // мощность двигателя
            Console.Write("\nВведите значение объема двигателя, кг/см.куб: ");
            var inputCapacity = Console.ReadLine();         // объем двигателя
            Console.Write("\nВведите значение типа двигателя: ");
            var inputEngType = Console.ReadLine();          // тип двигателя
            Console.Write("\nВведите значение номера двигателя: ");
            var inputEngNumber = Console.ReadLine();        // номер двигателя

            // Параметры трансмиссии.
            Console.Write("\nВведите тип трансмиссии: ");
            var inputTransType = Console.ReadLine();        // тип трансмиссии
            Console.Write("\nВведите количество передач: ");
            var inputGear = Console.ReadLine();             // количество передач
            Console.Write("\nВведите название производителя: ");
            var inputManufacturer = Console.ReadLine();     // производитель

            // Параметры шасси.
            Console.Write("\nВведите количество колес: ");
            var inputWeels = Console.ReadLine();            // количество колес
            Console.Write("\nВведите значение номера шасси: ");
            var inputChassisNumber = Console.ReadLine();    // номер шасси
            Console.Write("\nВведите значение допустимой нагрузки, "
                              + "кг или т: ");
            var inputLoad = Console.ReadLine();             // допустимая нагрузка

            return (inputName, inputPower, inputCapacity, inputEngType,
                inputEngNumber, inputTransType, inputGear, inputManufacturer,
                inputWeels, inputChassisNumber, inputLoad);
        }

        /// <summary>
        /// Обеспечивает поиск конкретного автомобиля по названию его модели.
        /// </summary>
        /// <param name="transports">Коллекция автомобилей.</param>
        /// <returns>
        /// Возвращает объект найденного автомобиля.
        /// </returns>
        public static Transport? Search(List<Transport>? transports)
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите название транспорта, информацию " +
                        "по которому хотите получить:\n\t");
                    var input = Console.ReadLine();
                    if ((input is not null) &&
                        (transports.Exists(p => p.Name == input)))
                    {
                        var auto = transports.Find(p => p.Name == input);
                        return auto;
                    }
                    else
                    {
                        throw new GetAutoByParameterException("Данного " +
                            "автомобиля в автопарке нет. Попробуйте ввести " +
                            "значение снова.", input);

                    }
                }
                catch (GetAutoByParameterException ex)
                {
                    Console.WriteLine($"Неверное значение: {ex.WrongParam}");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Заменяет выбранный транспорт новым.
        /// </summary>
        /// <param name="transports">Коллекция автомобилей.</param>
        /// <remarks>
        /// Данный метод выполняе ряд действий: поиск, получение индекса, 
        /// удаление объекта по индексу, добавление нового транспорта и его 
        /// вставку по этому индексу.
        /// </remarks>
        /// <returns>Возвращает новый транспорт.</returns>
        public static Transport? Update(List<Transport>? transports)
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите название транспорта, который " +
                        "хотите заменить:\n\t");
                    var input = Console.ReadLine();
                    if ((input is not null) &&
                        (transports.Exists(p => p.Name == input)))
                    {
                        // Поиск в коллекции.
                        var transport = transports.Find(p => p.Name == input);
                        int index = 0;
                        if (transport != null)
                        {
                            // Получение индекса.
                            index = transports.IndexOf(transport);
                        }
                        transports.RemoveAt(index);     // удаление

                        var auto = GetNew();            // новый транспорт
                        transports.Insert(index, auto); // добавление по индексу

                        return auto;
                    }
                    else
                    {
                        throw new UpdateAutoException("Данного автомобиля в " +
                            "автопарке нет. Введите значение заново или " +
                            "добавьте автомобиль.", input);
                    }
                }
                catch (UpdateAutoException ex)
                {
                    Console.WriteLine($"Неверное значение {ex.InvalidAuto}");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Удаляет транспорт который находит по названия его модели.
        /// </summary>
        /// <param name="transports">Коллекция автомобилей.</param>
        /// <remarks>
        /// Метод также, как и предыдущий выполняет похожий ряд действий: 
        /// поиск по имени, получение индекса, удаление.
        /// </remarks>
        /// <returns>
        /// Возвращает удаленный транспорт.
        /// </returns>
        public static Transport? Remove(List<Transport> transports)
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите название транспорта, который " +
                        "хотите удалить:\n\t");
                    var input = Console.ReadLine();
                    if ((input is not null) &&
                        (transports.Exists(p => p.Name == input)) &&
                        (transports.Count > 4))
                    {
                        var transport = transports.Find(p => p.Name == input);
                        int index = 0;
                        if (transport is not null)
                        {
                            index = transports.IndexOf(transport);
                        }
                        transports.RemoveAt(index);

                        return transport;
                    }
                    else if (transports.Count <= 4)
                    {
                        throw new RemoveAutoException("Удаление невозможно. " +
                            "В автопарке должно остаться минимум 4 " +
                            "автомобиля.");
                    }
                    else
                    {
                        throw new GetAutoByParameterException("Данного " +
                            "автомобиля в автопарке нет.", input);
                    }
                }
                catch (RemoveAutoException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (GetAutoByParameterException ex)
                {
                    Console.WriteLine($"Неверное значение {ex.WrongParam}");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
    enum Operation
    {
        Add, Search, Update, Remove
    }
}