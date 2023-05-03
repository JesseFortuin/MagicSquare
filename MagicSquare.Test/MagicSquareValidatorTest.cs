namespace MagicSquare.Test
{
    public class MagicSquareValidatorTest
    {
        [Fact]
        public void IsValidSuccessTest()
        {
            //arrange
            IMagicSquareValidator valid = new MagicSquareValidator();

            int gap = 1;

            var magicSquare = new int[,]
            {
                {8, 1, 6},
                {3, 5, 7},
                {4, 9, 2}
            };

            bool expected = true;

            //act
            bool actual = valid.IsValid(magicSquare, gap);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidGapFailTest()
        {
            //arrange
            IMagicSquareValidator valid = new MagicSquareValidator();

            int gap = 2;

            var magicSquare = new int[,]
            {
                {8, 1, 6},
                {3, 5, 7},
                {4, 9, 2}
            };

            bool expected = false;

            //act
            bool actual = valid.IsValid(magicSquare, gap);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidDuplicateFoundTest()
        {
            //arrange
            IMagicSquareValidator valid = new MagicSquareValidator();

            int gap = 0;

            var magicSquare = new int[,]
            {
                {8, 1, 6},
                {3, 5, 7},
                {4, 8, 2}
            };

            bool expected = false;
            //act
            bool actual = valid.IsValid(magicSquare, gap);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidNotPerfectSquareTest()
        {
            //arrange
            IMagicSquareValidator valid = new MagicSquareValidator();

            int gap = 1;

            var magicSquare = new int[,]
            {
                {8, 1, 6},
                {3, 5, 7},
                {4, 9, 20}
            };

            bool expected = false;

            //act
            bool actual = valid.IsValid(magicSquare, gap);

            //assert
            Assert.Equal(expected, actual);
        }

    }
}