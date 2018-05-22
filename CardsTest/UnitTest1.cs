using System.Collections.Generic;
using System.Linq;
using Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardsTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly List<Card> unsortedCards = new List<Card>()
        {
            new Card("Копенгаген", "Казань"),
            new Card("Кельн", "Владимир"),
            new Card("Екатеринбург", "Дели"),
            new Card("Брюгге", "Копенгаген"),
            new Card("Лондон", "Санкт-петербург"),
            new Card("Дели", "Грозный"),
            new Card("Берлин", "Пхукет"),
            new Card("Казань", "Берлин"),
            new Card("Владимир", "Москва"),
            new Card("Пхукет", "Екатеринбург"),
            new Card("Санкт-петербург", "Кондопога"),
            new Card("Кондопога", "Брюгге"),
            new Card("Москва", "Лондон")
        };

        /// <summary>
        /// Первая карточка не имеет предшественника?
        /// </summary>
        [TestMethod]
        public void First_Card_Departure_Has_No_Predecessor()
        {
            ISorter sorter = new Except();
            CardDeck deck = new CardDeck(sorter);
            List<Card> sortedCards = sorter.Sort(unsortedCards);

            if (sortedCards != null && sortedCards.Count > 0)
            {
                Card firstCard = sortedCards.FirstOrDefault();
                sortedCards.RemoveAt(0);
                bool firstHasNoPredecessor = sortedCards.TrueForAll(a => a.Arrival != firstCard.Departure);
                Assert.IsTrue(firstHasNoPredecessor);
            }

        }

        /// <summary>
        /// Карточки сортированы правильно?
        /// </summary>
        [TestMethod]
        public void Is_List_Correctly_Sorted()
        {
            ISorter sorter = new Except();
            CardDeck deck = new CardDeck(sorter);
            List<Card> sortedCards =  sorter.Sort(unsortedCards);

            if (sortedCards != null && sortedCards.Count > 0)
            {
                Card prevCard = sortedCards.FirstOrDefault();
                sortedCards.Remove(prevCard);

                while(sortedCards.Count > 0)
                {
                    Card nextCard = sortedCards.FirstOrDefault();
                    Assert.AreEqual(prevCard.Arrival, nextCard.Departure);
                    prevCard = nextCard;
                    sortedCards.Remove(prevCard);
                }
            }
        }
    }
}
