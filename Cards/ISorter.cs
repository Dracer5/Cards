using System.Collections.Generic;

namespace Cards
{
    /// <summary>
    /// Интерфейс для сортировщика
    /// </summary>
    public interface ISorter
    {
        /// <summary>
        /// Сортирует карточки так, чтобы пункт отправки был равен пункту предыдущего назначения
        /// </summary>
        /// <param name="notSortedList">Несортированный список карточек</param>
        /// <returns>Сортированный список карточек</returns>
        List<Card> Sort(List<Card> notSortedList);
    }
}
