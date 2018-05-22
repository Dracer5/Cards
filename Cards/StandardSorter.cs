using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    /// <summary>
    /// Реализация стандартного сортировщика
    /// </summary>
    public class Except : ISorter
    {
        /// <summary>
        /// Сортирует карточки так, чтобы пункт отправки был равен пункту предыдущего назначения
        /// </summary>
        /// <param name="notSortedList">Несортированный список карточек</param>
        /// <returns>Сортированный список карточек</returns>
        public List<Card> Sort(List<Card> notSortedList)
        {
            List<Card> sortedList = new List<Card>(notSortedList.Capacity);

            Card firstCard = GetFirstCard(notSortedList);
            notSortedList.Remove(firstCard);
            sortedList.Add(firstCard);
            while (notSortedList.Count > 0)
            {
                sortedList.Add(notSortedList.Find(card => card.Departure == sortedList.Last().Arrival));
                notSortedList.Remove(sortedList.Last());
            }

            return sortedList;
        }

        /// <summary>
        /// Вычисляет первую карточку, которая не имеет начала
        /// </summary>
        /// <param name="cards">Несортированный список карточек</param>
        /// <returns>Первая карточка</returns>
        private static Card GetFirstCard(List<Card> cards)
        {
            // string - для города
            // bool - для проверки, что есть пара
            Dictionary<string, bool> cityPairs = new Dictionary<string, bool>();
            for (int i = 0; i < cards.Count(); i++)
            {
                if (cityPairs.ContainsKey(cards[i].Departure))
                    cityPairs[cards[i].Departure] = true;
                else
                    cityPairs.Add(cards[i].Departure, false);

                if (cityPairs.ContainsKey(cards[i].Arrival))
                    cityPairs[cards[i].Arrival] = true;
                else
                    cityPairs.Add(cards[i].Arrival, false);
            }

            return cards.Find(card => cityPairs.Where(x => x.Value == false).Select(x => x.Key).Any(x => x == card.Departure));
        }
    }
}
