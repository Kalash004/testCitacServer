using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test56
{
    public class Citac
    {
        private int currentNumber;
        public int AddOne()
        {
            lock (this)
            {
                currentNumber++;
                return currentNumber;
            }
        }

        public int RemoveOne()
        {
            lock (this)
            {
                if (currentNumber <= 0) return 0; 
                currentNumber--;
                return currentNumber;
            }
        }

        public int GetCurrentNum()
        {
            lock (this)
            {
                return currentNumber;
            }
        }
    }
}
