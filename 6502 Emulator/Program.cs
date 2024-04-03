using _6502_Emulator.Internals;
using _6502_Emulator.Internals.Insturction.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6502_Emulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            new Mapper();
            Cpu cpu = new Cpu();
            cpu.Run(2);
            Console.WriteLine("Test");
        }
    }
}
