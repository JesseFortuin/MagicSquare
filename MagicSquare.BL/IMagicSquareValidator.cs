using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquare.BL
{
    public interface IMagicSquareValidator
    {
        public bool IsValid(int[][] square, int gap);
    }
}
