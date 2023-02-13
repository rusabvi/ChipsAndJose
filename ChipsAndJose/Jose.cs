namespace ChipsAndJose
{
    public class Jose
    {
        private List<int> SelectIndexOfSeatWithBiggestChipAmount(int[] seats)
        {
            int max = seats[0];
            List<int> indexes = new List<int> { 0 };

            for (int i = 1; i < seats.Length; i++)
            {
                if (seats[i] > max)
                {
                    indexes = new List<int> { i };
                    max = seats[i];
                }

                else if (seats[i] == max)
                    indexes.Add(i);
            }

            return indexes;
        }

        private List<int> SelectIndexOfSeatWithSmallestChipAmount(int[] seats)
        {
            int min = seats[0];
            List<int> indexes = new List<int> { 0 };

            for (int i = 1; i < seats.Length; i++)
            {
                if (seats[i] < min)
                {
                    indexes = new List<int> { i };
                    min = seats[i];
                }

                else if (seats[i] == min)
                    indexes.Add(i);
            }

            return indexes;
        }

        private int[] SelectCloseIndexesAndDistance(List<int> indexesOfSeatWithBiggestChipAmount,
                                                    List<int> indexesOfSeatWithSmallestChipAmount,
                                                    int seatAmount)
        {
            int[] indexes = { -1, -1, -1 };
            int distance = int.MaxValue;

            foreach (int big in indexesOfSeatWithBiggestChipAmount)
                foreach (int small in indexesOfSeatWithSmallestChipAmount)
                {
                    int distance1 = Math.Abs(big - small);
                    int distance2 = Math.Abs(seatAmount - distance1);

                    if (distance1 < distance)
                    {
                        distance = distance1;
                        indexes[0] = big;
                        indexes[1] = small;
                        indexes[2] = distance1;
                    }

                    if (distance2 < distance)
                    {
                        distance = distance2;
                        indexes[0] = big;
                        indexes[1] = small;
                        indexes[2] = distance2;
                    }
                }

            return indexes;
        }

        public int DealWithChips(int[] seats)
        {
            if (seats.Length == 0)
                return 0;

            int moveAmount = 0;

            while (true)
            {
                List<int> indexesOfSeatWithBiggestChipAmount = SelectIndexOfSeatWithBiggestChipAmount(seats);
                List<int> indexesOfSeatWithSmallestChipAmount = SelectIndexOfSeatWithSmallestChipAmount(seats);

                if (indexesOfSeatWithBiggestChipAmount.Count == seats.Length)   // if every element taken like biggest
                    return moveAmount;

                int[] indexes = SelectCloseIndexesAndDistance(indexesOfSeatWithBiggestChipAmount,
                                                              indexesOfSeatWithSmallestChipAmount,
                                                              seats.Length);

                seats[indexes[0]]--;        // bigger--
                seats[indexes[1]]++;        // smaller++
                moveAmount += indexes[2];   // += distance
            }
        }
    }
}