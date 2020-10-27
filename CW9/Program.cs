// Name: Jimmy Butcher
// Date: 10/27/2020
// File: Program.cs
// Description: This is a program to estimate the value of pi using the Monte Carlo method.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace CW9
{
    public class FindPiThread
    {
        private int dartsToThrow;
        private int dartsInCircle;
        public Random randNum;

        public FindPiThread(int darts)
        {
            dartsToThrow = darts;
            dartsInCircle = 0;
            randNum = new Random();
        }

        public void throwDarts()
        {
            for (int i = 0; i < dartsToThrow; i++)
            {
                double x = randNum.NextDouble(0.0, 1.0);
                double y = randNum.NextDouble(0.0, 1.0);
                
                if (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) <= 1)
                {
                    dartsInCircle++;
                }
            }
        }

        public int Darts
        {
            get { return dartsInCircle; }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfThrows = 0;
            int numberOfThreads = 0;
            double pi = 0.0;
            
            Console.WriteLine("Enter how many throws to make: ");
            numberOfThrows = Console.Read();
            Console.WriteLine("Enter how many threads to run: ");
            numberOfThreads = Console.Read();

            List<Thread> threads = new List<Thread>(numberOfThreads);
            List <FindPiThread> piFinds = new List<FindPiThread>(numberOfThreads);

            for (int i = 0; i < numberOfThreads; i++)
            {
                FindPiThread findPi = new FindPiThread(numberOfThrows);
                piFinds.Add(findPi);
                Thread tl = new Thread(new ThreadStart(piFinds[i].throwDarts)0);

                threads.Add(tl);

                tl.Start();

                Thread.Sleep(16);
            }

            for (int i = 0; i < numberOfThreads; i++)
            {
                threads[i].Join();
            }


            pi = 4 * (dartsInside / totalDarts);

            int dartsInside = 0;
            double estimatePi = 0.00;

            for(int i = 0; i < numberOfThreads; i++)
            {
                dartsInside = piFinds[i].Darts();
            }

        }
    }
}
