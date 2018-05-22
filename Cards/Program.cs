using System;
using System.Collections.Generic;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> list = GenerateRandomList();
            list.ForEach(card => Console.WriteLine("{0} --> {1}", card.Departure, card.Arrival));
            Console.WriteLine();

            ISorter sorter = new Except();
            CardDeck deck = new CardDeck(sorter) { Cards = list };

            List<Card> sortedList = deck.Sort();

            sortedList.ForEach(card => Console.WriteLine("{0} --> {1}", card.Departure, card.Arrival));
            Console.ReadLine();
        } 

        /// <summary>
        /// Создает карточки пар перелетов
        /// </summary>
        /// <returns>Несортированный список карточек</returns>
        private static List<Card> GenerateRandomList()
        {
            Random rand = new Random();
            List<Card> list = new List<Card>();
            List<string> cities = new List<string>() { "Санкт-петербург", "Брюгге", "Лондон", "Кандапога", "Кельн", "Москва", "Казань", "Екатеринбург", "Берлин", "Владимир", "Копенгаген", "Дели", "Пхукет", "Грозный" };

            int count = rand.Next(0, cities.Count - 1);
            string Prev = cities[count];
            cities.RemoveAt(count);

            while (cities.Count > 0)
            {
                count = rand.Next(0, cities.Count - 1);
                list.Add(new Card (Prev, cities[count]));
                Prev = cities[count];
                cities.RemoveAt(count);
            }
            list.Shuffle();

            return list;
        }
    }
}
