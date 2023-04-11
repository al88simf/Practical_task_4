namespace PracticalTask4
{
    /// <summary>
    /// Класс представляет название каждой единицы транспорта из коллекции.
    /// </summary>
    class Name
    {
        const string Car = "Легковой автомобиль ВАЗ-2105 \"Жигули\"";
        const string Truck = "Грузовик МАЗ-500";
        const string Bus = "Автобус А092 \"Богдан\"";
        const string Scooter = "Скутер Vespa Primavera 150";

        // Возвращает название по текущему индексу.
        public string this[int index]
        {
            get
            {
                return index switch
                {
                    0 => GetName(Vehicle.Car),
                    1 => GetName(Vehicle.Truck),
                    2 => GetName(Vehicle.Bus),
                    _ => GetName(Vehicle.Scooter),
                };
            }
        }

        /// <summary>
        /// Позволяет получить название выбранного транспорта.
        /// </summary>
        /// <param name="type">Тип перечисления.</param>
        /// <returns>
        /// Название транспорта, согласно выбранного перечисления.
        /// </returns>
        static string GetName(Vehicle type)
        {
            switch (type)
            {
                case Vehicle.Car: return Car;
                case Vehicle.Truck: return Truck;
                case Vehicle.Bus: return Bus;
                default: return Scooter;
            }
        }
    }
}