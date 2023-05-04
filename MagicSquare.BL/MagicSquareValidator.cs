namespace MagicSquare.BL
{
    public class MagicSquareValidator : IMagicSquareValidator
    {
        public bool IsValid(int[][] square, int gap)
        {
            var orderedSquare = new List<int>();

            var sum = square[0][0] + square[0][1] + square[0][2];

            if (square[1][0] + square[1][1] + square[1][2] != sum ||
                square[2][0] + square[2][1] + square[2][2] != sum ||
                square[0][0] + square[1][0] + square[2][0] != sum ||
                square[0][1] + square[1][1] + square[2][1] != sum ||
                square[0][2] + square[1][2] + square[2][2] != sum ||
                square[0][0] + square[1][1] + square[2][2] != sum ||
                square[0][2] + square[1][1] + square[2][0] != sum)
            {
                return false;
            }

            for (int i = 0; i < square.Length; i++)
            {
                foreach (var num in square[i]) 
                {
                    orderedSquare.Add(num);
                }
            }
            
            int[] arr = orderedSquare.ToArray();

            Array.Sort(arr);

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] < gap || arr[i] - arr[i - 1] > gap)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}