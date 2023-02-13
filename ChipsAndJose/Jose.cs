using System;

namespace ChipsAndJose
{
    public class Jose
    {
        private int CountAverageChipAmount(int[] seats)
        {
            if (seats.Length == 0)
                throw new Exception("No seats");

            int totalChipAmount = 0;

            foreach (int seat in seats)
                totalChipAmount += seat;

            return totalChipAmount / seats.Length;
        }

        /*private int SelectIndexOfSeatWithBiggestChipAmount(int[] seats, List<int> indexesToAvoid)
        {
            int index = -1;
            int averageChipAmount;
            try { averageChipAmount = CountAverageChipAmount(seats); }
            catch { return 0; }

            for (int i = 0, max = -1; i < seats.Length; i++)
            {
                if (seats[i] > max && !indexesToAvoid.Contains(i))
                {
                    max = seats[i];
                    index = i;
                }
            }

            return index;
        }*/

        /*private int SelectIndexOfNearbySeatWithSmallestChipAmount(int[] seats,
                                                                  int indexOfSeatWithBiggestChipAmount)
        {
            int index1 = indexOfSeatWithBiggestChipAmount - 1;
            int index2 = indexOfSeatWithBiggestChipAmount + 1;

            int nearbySeat1;
            try
            {
                nearbySeat1 = seats[index1];
            }
            catch
            {
                index1 = seats.Length - 1;
                nearbySeat1 = seats[index1];
            }

            int nearbySeat2;
            try
            {
                nearbySeat2 = seats[index2];
            }
            catch
            {
                index2 = 0;
                nearbySeat2 = seats[index2];
            }

            if (nearbySeat1 < nearbySeat2)
                return index1;

            return index2;
        }*/

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

        private int[] SelectCloseIndexes(List<int> indexesOfSeatWithBiggestChipAmount,
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

        /*private (int, int) SelectIndexPairOfSeatsWithBiggestChipDifference(int[] seats)
        {
            (int, int) indexPair = (-1, -1);
            int difference = -1;
            {
                int currentDifference = Math.Abs(seats[0] - seats[seats.Length - 1]);

                if (difference < currentDifference)
                {
                    difference = currentDifference;
                    indexPair = (0, seats.Length - 1);
                }
            }

            for (int i = 1; i < seats.Length; i++)
            {
                int currentDifference = Math.Abs(seats[i] - seats[i - 1]);

                if ((difference == currentDifference &&
                    i == SelectIndexOfSeatWithBiggestChipAmount(seats)) ||
                    difference < currentDifference)
                {
                    difference = currentDifference;
                    indexPair = (i, i - 1);
                }
            }

            return indexPair;
        }*/

        public int DealWithChips(int[] seats)
        {
            if (seats.Length == 0)
                return 0;

            int moveAmount = 0;
            //List<int> indexesToAvoid = new List<int>();

            /*
             * v1
            while (!dealt)
            {
                int indexOfBiggest = SelectIndexOfSeatWithBiggestChipAmount(seats, indexesToAvoid);
                int indexOfNeighbor = SelectIndexOfNearbySeatWithSmallestChipAmount(seats, indexOfBiggest);

                if (seats[indexOfBiggest] == averageChipAmount)
                    dealt = true;

                else if (indexOfBiggest == indexOfNeighbor)
                    indexesToAvoid.Add(indexOfBiggest);

                else
                {
                    seats[indexOfBiggest]--;
                    seats[indexOfNeighbor]++;
                    moveAmount++;
                    indexesToAvoid = new List<int>();
                }
            }
            */
            /*
             * v2
            while (true)
            {
                (int, int) indexPair = SelectIndexPairOfSeatsWithBiggestChipDifference(seats);

                if (seats[indexPair.Item1] - seats[indexPair.Item2] == 0)
                    return moveAmount;

                else
                {
                    seats[indexPair.Item1]--;
                    seats[indexPair.Item2]++;
                    moveAmount++;
                }
            }
            */

            while (true)
            {
                List<int> indexesOfSeatWithBiggestChipAmount = SelectIndexOfSeatWithBiggestChipAmount(seats);
                List<int> indexesOfSeatWithSmallestChipAmount = SelectIndexOfSeatWithSmallestChipAmount(seats);

                if (indexesOfSeatWithBiggestChipAmount.Count == seats.Length)
                    return moveAmount;

                int[] indexes = SelectCloseIndexes(indexesOfSeatWithBiggestChipAmount,
                                                 indexesOfSeatWithSmallestChipAmount,
                                                 seats.Length);

                seats[indexes[0]]--;
                seats[indexes[1]]++;
                moveAmount += indexes[2];
                /*
                if (indexOfSeatWithBiggestChipAmount >= indexOfSeatWithSmallestChipAmount)
                    distance1 = indexOfSeatWithBiggestChipAmount - indexOfSeatWithSmallestChipAmount;
                else
                    distance1 = indexOfSeatWithSmallestChipAmount - indexOfSeatWithBiggestChipAmount;

                distance2 = seats.Length - distance1;

                seats[indexOfSeatWithBiggestChipAmount]--;
                seats[indexOfSeatWithSmallestChipAmount]++;

                if (distance1 >= distance2)
                    moveAmount += distance2;
                else
                    moveAmount += distance1;
                */
            }
        }
    }
}