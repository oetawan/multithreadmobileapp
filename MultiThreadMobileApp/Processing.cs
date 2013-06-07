using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreadMobileApp
{
    public class Processing
    {
        private const int nrLoops = 10;
        private int counter1;
        private int counter2;
        
        public Processing()
        {
            counter1 = 0;
            counter2 = 0;
        }

        public void Function1()
        {
            Monitor.Enter(this);
            for(int i = 0; i < nrLoops; i++)
            {
                int localCounter = counter1;
                Thread.Sleep(0);
                localCounter++;
                Thread.Sleep(0);
                counter1 = localCounter;
                Thread.Sleep(0);
            }
            Monitor.Exit(this);
        }

        public void Function2()
        {
            Monitor.Enter(this);
            for (int i = 0; i < nrLoops; i++)
            {
                int localCounter = counter2;
                localCounter++;
                counter2 = localCounter;
            }
            Monitor.Exit(this);
        }

        public int Counter
        {
            get
            {
                return counter1 - counter2;
            }
        }
    }
}