namespace ChipsAndJose
{
    public class Jose
    {
        private int CountAverageChipsAmount(int[] seats)
        {
            if (seats.Length == 0)
                return 0;

            int totalChipsAmount = 0;

            foreach (int seat in seats)
                totalChipsAmount += seat;

            return totalChipsAmount / seats.Length;
        }

        private int SelectIndexOfSeatWithBiggestChipsAmount(int[] seats)
        {
            int max = seats[0];
            int index = 0;

            for (int i = 1; i < seats.Length; i++)
                if (seats[i] > max)
                {
                    index = i;
                    max = seats[i];
                }

            return index;
        }

        private int SelectIndexOfNearbySeatWithSmallerChipsAmount(int[] seats,
                                                                  int indexOfSeatWithBiggestChipsAmount,
                                                                  int averageChipsAmount)
        {
            for (int i = 1; i < seats.Length / 2 + 1; i++)
            {
                int leftIndexOfNearbySeatWithSmallerChipsAmount = indexOfSeatWithBiggestChipsAmount - i;
                if (leftIndexOfNearbySeatWithSmallerChipsAmount < 0)
                    leftIndexOfNearbySeatWithSmallerChipsAmount += seats.Length;

                int rightIndexOfNearbySeatWithSmallerChipsAmount = indexOfSeatWithBiggestChipsAmount + i;
                if (rightIndexOfNearbySeatWithSmallerChipsAmount >= seats.Length)
                    rightIndexOfNearbySeatWithSmallerChipsAmount -= seats.Length;
                
                if (seats[leftIndexOfNearbySeatWithSmallerChipsAmount] < averageChipsAmount
                    && seats[leftIndexOfNearbySeatWithSmallerChipsAmount] < seats[rightIndexOfNearbySeatWithSmallerChipsAmount])
                    return leftIndexOfNearbySeatWithSmallerChipsAmount;

                if (seats[rightIndexOfNearbySeatWithSmallerChipsAmount] < averageChipsAmount
                    && seats[rightIndexOfNearbySeatWithSmallerChipsAmount] < seats[leftIndexOfNearbySeatWithSmallerChipsAmount])
                    return rightIndexOfNearbySeatWithSmallerChipsAmount;
            }

            return indexOfSeatWithBiggestChipsAmount;
        }

        private int CountDistance(int indexOfSeatWithBiggestChipsAmount,
                                  int indexOfNearbySeatWithSmallerChipsAmount,
                                  int seatsAmount)
        {
            int distance1 = Math.Abs(indexOfSeatWithBiggestChipsAmount - indexOfNearbySeatWithSmallerChipsAmount);
            int distance2 = seatsAmount - distance1;

            if (distance1 < distance2)
                return distance1;

            return distance2;
        }

        private int CountChipsAmountToTransport(int biggestChipsAmount, int smallerChipsAmount, int averageChipsAmount)
        {
            int differenceFromBiggest = biggestChipsAmount - averageChipsAmount;
            int differenceFromSmaller = averageChipsAmount - smallerChipsAmount;

            if (differenceFromBiggest < differenceFromSmaller)
                return differenceFromBiggest;

            return differenceFromSmaller;
        }

        public int DealWithChips(int[] seats)
        {
            if (seats.Length == 0)
                return 0;

            int movesAmount = 0;
            int averageChipsAmount = CountAverageChipsAmount(seats);

            while (true)
            {
                int indexOfSeatWithBiggestChipsAmount = SelectIndexOfSeatWithBiggestChipsAmount(seats);

                if (seats[indexOfSeatWithBiggestChipsAmount] == averageChipsAmount)
                    return movesAmount;

                while (seats[indexOfSeatWithBiggestChipsAmount] > averageChipsAmount)
                {
                    int indexOfNearbySeatWithSmallerChipsAmount =
                        SelectIndexOfNearbySeatWithSmallerChipsAmount(seats,
                                                                      indexOfSeatWithBiggestChipsAmount,
                                                                      averageChipsAmount);

                    int distanceCoefficient = CountDistance(indexOfSeatWithBiggestChipsAmount, indexOfNearbySeatWithSmallerChipsAmount, seats.Length);
                    int chipsAmountToTransport = CountChipsAmountToTransport(seats[indexOfSeatWithBiggestChipsAmount],
                                                                             seats[indexOfNearbySeatWithSmallerChipsAmount],
                                                                             averageChipsAmount);

                    seats[indexOfSeatWithBiggestChipsAmount] -= chipsAmountToTransport;
                    seats[indexOfNearbySeatWithSmallerChipsAmount] += chipsAmountToTransport;
                    movesAmount += distanceCoefficient * chipsAmountToTransport;
                }
            }
        }
    }
}