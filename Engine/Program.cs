using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace LifeOhLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // classical algorithms        
            SimpleLife sl = new SimpleLife();
            sl.GenerateRandomField(123, 0.5);
            while(true)
            {
                sl.Run(1);
                Console.Clear();
                Console.Write(sl.GetRectangle(0, 0, 50, 20));
            }
            // создать окошко

        }

        
    }
}
