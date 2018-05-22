namespace Cards
{
    /// <summary>
    /// Единичная карта
    /// </summary>
    public class Card
    {
        public Card(string departure, string arrival)
        {
            Departure = departure;
            Arrival = arrival;
        }

        /// <summary>
        /// Пункт отправления
        /// </summary>
        public string Departure;
        /// <summary>
        /// Пункт назначения
        /// </summary>
        public string Arrival;
    }
}
