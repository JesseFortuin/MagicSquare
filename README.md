Magic Squares:
Square has to follow such rules to be called Magic Square:

Sum of values in each row is equal to x
Sum of values in each column is equal to x
Sum of values in (each of) diagonal is equal to x
There is no duplicated numbers
All numbers forms valid sequence arithmetic progression
Example:
Value of x should be same in all cases (sum of row / columns / diagonals) for given square.

For such square:

8   1   6   -> 15
3   5   7   -> 15
4   9   2   -> 15

|   |   |
15  15  15
Our magic x is 15.

Also both digonals sum-up to x:

8 + 5 + 2 = 15

4 + 5 + 6 = 15.

Sequence of numbers in square (the arrangement of all numerical inputs in the 2D array in sequential order) are 1, 2, 3, 4, 5, 6, 7, 8, 9, so there is no duplicates and they form arithmetic progression with progression (gap) equal to 1.

Our x has always same value, so given square is magic square.

If any of conditions fails: it is NOT a magic square.

Custom rules:
There is additional rule, which our square has to follow to be called valid:

Gap in sequence has to be equal to given function param: gap.
For example described above (Example header), if param gap would be 1: square would be valid.

If param gap would be 2 (or any other value which is not 1) - the square would NOT be valid.

Note: proper sequence does NOT have to start from value: 1.

E.g. sequence: 2, 3, 4, 5, 6, 7, 8, 9, 10 is also valid arithmetic progression with gap (difference between numbers) = 1.

Your goal
As a programmer you should implement method IsValid which will check all above conditions (of Magic square and custom rules) for us.

If all conditions are met - return true, false otherwise.

Inputs
Inputs will always consist of:

n x n array, where 2 < n < 10
all array cells will be filled with integers
gap will be always a positive integer

----------------------------------------------------------------

Solutions


int n = square.Length;
        int x = square[0].Sum();
        if (!(square.Select(row => row.Sum()).All(s => s == x)
            && Enumerable.Range(0, n).Select(i => square.Select(row => row[i]).Sum()).All(s => s == x)
            && (Enumerable.Range(0, n).Select(i => square[i][i]).Sum() == x)
            && (Enumerable.Range(0, n).Select(i => square[n - i - 1][i]).Sum() == x)
        ))
        {
            return false;
        }
        List<int> elements = square.SelectMany(row => row).OrderBy(s => s).ToList();
        return elements.Zip(elements.Skip(1)).All(t => t.Second - t.First == gap);

------------
var x = square[0].Sum();
      var full = new List<int>();

      if(x != square[1].Sum() || x != square[2].Sum()) return false;
      if(x != square[0][0] + square[1][1] + square[2][2] || x!= square[0][2] + square[1][1] + square[2][0]) return false;
      for(int i = 0; i <3; i++)
      {
        full.Add(square[0][i]);
        full.Add(square[1][i]);
        full.Add(square[2][i]);
        if(x!= square[0][i]+square[1][i]+square[2][i]) return false;
      }
      full.Sort();
      int che = full[0];
      for(int i = 1; i<9; i++)
      {
        che += gap;
        if(full[i] != che) return false;
      }
      
        return true;
-------------

      int n = square.GetLength(0);
      int sum = 0;
      int testSumRow = 0;
      int testSumCol = 0;
      int testSumDiagLeft = 0;
      int testSumDiagRight = 0;
      int[] singleArray = new int[n*n];
      int singleArrayIndex = 0;
      int testGap = 0;
      
      //Sum of rows and cols and diagonals
      for (int row = 0; row < n; row++)
      {
        testSumRow = 0;
        testSumCol = 0;
        
        for (int col = 0; col < n; col++)
        {
          //Assign values to single dim array
          singleArray[singleArrayIndex++] = square[row][col];
          testSumRow += square[row][col];
          testSumCol += square[col][row];
          if (row == col)
          {
            testSumDiagLeft += square[row][col];
          }
          if ((row + col) == (n - 1))
          {
            testSumDiagRight += square[row][col];;
          }
        }
        //assign an initial sum and check if all sums are the same to initial value
        if (row == 0)
        {
            sum = testSumRow;
        }
        if (testSumRow != sum || testSumCol != sum)
        {
            return false;
        }
      }
      
      //Check both diagonals
      if (testSumDiagLeft != sum || testSumDiagRight != sum)
      {
        return false;
      }
      
      Array.Sort(singleArray);
      //duplicates
      if (singleArray.Length != singleArray.Distinct().Count())
      {
        return false;
      }
      
      //check gap
      for (int index = 1; index < singleArray.Length; index++)
      {
        testGap = singleArray[index] - singleArray[index - 1];
        if (testGap != gap)
        {
          return false;
        }
      }
      
      return true;

