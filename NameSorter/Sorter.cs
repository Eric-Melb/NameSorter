namespace NameSorter
{
    using System;
    using System.Collections.Generic;

    // we're only sorting names but there's (probably) no harm in being able
    // to sort anything comparable
    // it also allows for some variation in test cases
    public static class Sorter
    {
        // assuming we should implement and test a sort rather than call .Sort()
        // not the most elegant merge sort, but straightforward
        public static List<T> ListSort<T>(List<T> list) where T: IComparable<T>
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int middleIndex = list.Count / 2;
            List<T> leftList = ListSort(list.GetRange(0, middleIndex));
            List<T> rightList = ListSort(list.GetRange(middleIndex, list.Count - middleIndex));
            List<T> sortedList = new List<T>();
            int leftIndex = 0;
            int rightIndex = 0;
            int leftLength = leftList.Count;
            int rightLength = rightList.Count;

            // check the returned lists and add from the lowest values
            while (leftIndex < leftLength && rightIndex < rightLength)
            {
                int comparison = leftList[leftIndex].CompareTo(rightList[rightIndex]);

                if (comparison < 0)
                {
                    sortedList.Add(leftList[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    sortedList.Add(rightList[rightIndex]);
                    rightIndex++;
                }
            }

            // add what's left from the non-exhausted (already sorted) sublist
            if (leftIndex < leftLength)
            {
                for (var i = leftIndex; i < leftLength; i++)
                {
                    sortedList.Add(leftList[i]);
                }
            }
            else
            {
                for (var i = rightIndex; i < rightLength; i++)
                {
                    sortedList.Add(rightList[i]);
                }
            }

            return sortedList;
        }     
    }
}
