using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack)
        {
            Stack<int> result = new Stack<int>();

            return result;
        }

        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();
            int currentItem = -1;

            for (int i = 0; i < sourceArr.Length; i++)
            {
                currentItem = sourceArr[i];
                result.Add(currentItem, GetValueTypeFromNum(currentItem));
            }

            return result;
        }

        private static EValueType GetValueTypeFromNum(int currentItem)
        {
            EValueType result = EValueType.Prime;

            if (currentItem % 2 == 0)
            {
                result = EValueType.Two;
            }
            else if (currentItem % 3 == 0)
            {
                result = EValueType.Three;
            }
            else if (currentItem % 5 == 0)
            {
                result = EValueType.Five;
            }
            else if (currentItem % 7 == 0)
            {
                result = EValueType.Seven;
            }

            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            int result = 0;

            foreach (var item in sourceDict)
            {
                if (item.Value.Equals(type))
                {
                    result++;
                }
            }

            return result;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();

            if (sourceDict.Count > 0)
            {
                List<KeyValuePair<int, EValueType>> dictEntries = new List<KeyValuePair<int, EValueType>>();

                foreach (var item in sourceDict)
                {
                    dictEntries.Add(new KeyValuePair<int, EValueType>(item.Key, item.Value));
                }

                SortElements(dictEntries);

                foreach (var entry in dictEntries)
                {
                    result.TryAdd(entry.Key, entry.Value);
                }
            }

            return result;
        }

        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = { new Queue<Ticket>(), new Queue<Ticket>(), new Queue<Ticket>() };
            List<Ticket> paymentElements = new List<Ticket>();
            List<Ticket> subsElements = new List<Ticket>();
            List<Ticket> cancelElements = new List<Ticket>();

            for (int i = 0; i < sourceList.Count; i++)
            {
                switch (sourceList[i].RequestType)
                {
                    case Ticket.ERequestType.Payment:
                        paymentElements.Add(sourceList[i]);
                        break;

                    case Ticket.ERequestType.Subscription:
                        subsElements.Add(sourceList[i]);
                        break;

                    case Ticket.ERequestType.Cancellation:
                        cancelElements.Add(sourceList[i]);
                        break;
                }
            }

            SortElements(paymentElements);
            EnqueueElements(paymentElements, result[0]);
            SortElements(subsElements);
            EnqueueElements(subsElements, result[1]);
            SortElements(cancelElements);
            EnqueueElements(cancelElements, result[2]);

            return result;
        }

        private static void SortElements(List<Ticket> sourceList)
        {
            int n = sourceList.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sourceList[j].Turn > sourceList[j + 1].Turn)
                    {
                        Ticket temp = sourceList[j];
                        sourceList[j] = sourceList[j + 1];
                        sourceList[j + 1] = temp;
                    }
                }
            }
        }

        private static void SortElements(List<KeyValuePair<int, EValueType>> sourceList)
        {
            int n = sourceList.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sourceList[j].Key < sourceList[j + 1].Key)
                    {
                        KeyValuePair<int, EValueType> temp = sourceList[j];
                        sourceList[j] = sourceList[j + 1];
                        sourceList[j + 1] = temp;
                    }
                }
            }
        }

        private static void EnqueueElements(List<Ticket> sourceList, Queue<Ticket> targetQueue)
        {
            foreach (var item in sourceList)
            {
                targetQueue.Enqueue(item);
            }
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = true;
            Ticket currentTicket = targetQueue.Peek();

            result = ticket.Turn <= 99 && currentTicket.RequestType.Equals(ticket.RequestType);

            if (result)
            {
                targetQueue.Enqueue(ticket);
            }

            return result;
        }
    }
}