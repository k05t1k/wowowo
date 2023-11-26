using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Timer
    {
        public int Minutes;
        public int Seconds;

		public Output Output;

		public Timer(int minutes, int seconds, Output output) 
        { 
            Minutes = minutes;
            Seconds = seconds;
			Output = output;
		}
        public void StartTimer()
        {
            while (Output.IsEnd == false)
            {
                if (Seconds < 0)
                {
                    Minutes--;
                    Seconds = 59;
                }

                PrintTime();
                Thread.Sleep(1000);
                Console.Clear();
                Seconds--;
            }

            // ending here
			Console.WriteLine("Хотите ли вы продолжить? да/нет");
            string answer = Console.ReadLine();

			if (answer == "да")
            {
                Console.Clear();
				Program.Main();
			}
		}
        public void PrintTime()
        {
            string? Time = Seconds == 0 ? 
                $"Time: {Minutes}:{Seconds}0" : 
                $"Time: {Minutes}:{Seconds}";

            Console.WriteLine(Time);
        }
    }
}
