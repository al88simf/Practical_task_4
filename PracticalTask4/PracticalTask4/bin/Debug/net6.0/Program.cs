namespace PracticalTask2Library
{
    /// <summary>
    /// Класс Program обеспечивает вывод информации по определенному транспорту.
    /// </summary>
    /// <remarks>
    /// Класс принимает число, соответствующее типу выбранного автомобиля, сверяет 
    /// его с 4 возможными вариантами и, если соответствует, выводит соответствующую 
    /// информацию по характеристикам конкретного автомобиля на консоль.
    /// </remarks>
    public class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args">Список аргументов для командной строки.</param>
        public static void Main(string[] args)
        {
            Engine car = new Chassis
            {
                Power = "68 л/с",
                Capacity = "1294 см.куб.",
                Type = "бензиновый",
                SerialNumber = "Н0123456",

                TransType = "механическая",
                Gear = 5,
                Manufacturer = "ВАЗ",

                Weels = 4,
                Number = "ХТА210500",
                Load = "400 кг"
            };
            Engine truck = new Chassis
            {
                Power = "180 л/с",
                Capacity = "11150 см.куб.",
                Type = "дизельный",
                SerialNumber = "В01234567",

                TransType = "механическая",
                Gear = 5,
                Manufacturer = "ЯМЗ",

                Weels = 4,
                Number = "0123456",
                Load = "10 т"
            };
            Engine bus = new Chassis
            {
                Power = "121 л/с",
                Capacity = "4570 см.куб.",
                Type = "дизельный с турбо-наддувом",
                SerialNumber = "N01234567",

                TransType = "механическая, синхронизированная",
                Gear = 4,
                Manufacturer = "ISUZU",

                Weels = 4,
                Number = "0123456",
                Load = "8 т"
            };
            Engine scooter = new Chassis
            {
                Power = "12 л/с",
                Capacity = "155 см.куб.",
                Type = "бензиновый",
                SerialNumber = "01234",

                TransType = "механическая",
                Gear = 4,
                Manufacturer = "Vespa",

                Weels = 2,
                Number = "012345",
                Load = "150 кг"
            };
            // Цикл проверяет на корректность введенное число и повторяется в случае,
            // если оно не верное.
            while (true)
            {
                Console.WriteLine("Выберите транспортное средство.");
                Console.Write("\tЛегковой автомобиль - нажмите \"1\"" +
                    "\n\tГрузовик - нажмите \"2\"" +
                    "\n\tАвтобус - нажмите \"3\"" +
                    "\n\tСкутер - нажмите \"4\"" +
                    "\nВаш выбор: ");
                string? input = Console.ReadLine();   // введенное значение

                if (int.TryParse(input, out int autoChoice) &&
                    (autoChoice == 1 || autoChoice == 2 ||
                    autoChoice == 3 || autoChoice == 4))
                {
                    switch (autoChoice)
                    {
                        case 1:
                            Display((Chassis)car,
                                "Легковой автомобиль ВАЗ-2105 \"Жигули\"");
                            break;
                        case 2:
                            Display((Chassis)truck, "Грузовик МАЗ-500");
                            break;
                        case 3:
                            Display((Chassis)bus, "Автобус А092 \"Богдан\"");
                            break;
                        default:
                            Display((Chassis)scooter, "Скутер Vespa Primavera 150");
                            break;
                    }
                    break;  // выход из цикла
                }
                else Console.WriteLine("Не верное значение!\n");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Выводит на консоль все характеристики по конкретному типу авто.
        /// </summary>
        /// <param name="auto">Принимает объект, представляющий конкретное 
        /// авто.</param>
        /// <param name="name">Навание авто.</param>
        /// <seealso cref="Chassis">
        /// Тип Chassis.
        /// </seealso>
        static void Display(Chassis auto, string name)
        {
            Console.WriteLine(name);
            auto.PrintEngine();
            auto.PrintChassis();
            auto.PrintTransmission();
        }
    }
}
