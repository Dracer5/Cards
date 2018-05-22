using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    /// <summary>
    /// Карточная колода
    /// </summary>
    public class CardDeck
    {
        private ISorter _sorter;

        public CardDeck(ISorter sorter)
        {
            _sorter = sorter;
        }

        /// <summary>
        /// Несортированный список карточек
        /// </summary>
        public List<Card> Cards { get; set; }

        /// <summary>
        /// Метод сортировки карточек
        /// </summary>
        /// <returns>Сортированный список карточек</returns>
        public List<Card> Sort()
        {
            return _sorter.Sort(Cards);
        }
    }
}
