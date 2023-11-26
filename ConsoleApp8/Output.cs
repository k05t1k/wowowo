using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Output
    { 
        public bool IsEnd = false;

        public int X = 0;
        public int Y = 1;

        public int Flag;

        public int ColoredSymbols;

        public int SymbolsPerSecond;
        public int SymbolsPerMinute;

        private string Text = "cамый распространенный язык китайский а второй по\n" +
                "распространенности испанский английскому же достается\n" +
                "почетная бронза виноград взрывается в микроволновой печи\n" +
                "первоначально кока кола была зеленой ленивцы проводят\n" +
                "большую часть жизни во сне дельфины спят с одним открытым глазом.\n";

        public void RenderText()
        {
            Thread thread = new Thread(_ =>
            {
                while (IsEnd == false)
                {
                    Thread.Sleep(5);
                    Console.SetCursorPosition(0, 1);
                    for (int i = 0; i < Text.Length; i++)
                    {
                        if (ColoredSymbols > i)
                            Console.ForegroundColor = ConsoleColor.Blue;
						else
							Console.ForegroundColor = ConsoleColor.White;

                        Console.Write(Text[i]);
                    }
                    Console.SetCursorPosition(X, Y);
                }
            });

            thread.Start();

            Thread thread1 = new Thread(_ =>
            {
                for (int i = 0; i < Text.Length; i++)
                {
					ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (Text[i] == '\n')
                    {
                        Y++;
                        X = 0;
                    }
                    else
						X++;

                    if (Text[i] == '.')
						IsEnd = true;


					ColoredSymbols++;
  				}
            });

            thread1.Start();
        }
    }
}
