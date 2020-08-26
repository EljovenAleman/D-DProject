using System;

namespace BandB
{
    static class RNG
    {
        static Random numberGenerator = new Random();

        static public int RollD20()
        {
            int randomNumber = numberGenerator.Next(1, 21);

            return randomNumber;
        }


    }
}


