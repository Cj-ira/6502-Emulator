using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6502_Emulator.Internals
{
    public class Memory
    {
        public static uint MAX_MEMORY = 1024 * 64;

        byte[] memory = new byte[MAX_MEMORY];

        public Memory()
        {
            
        }

        public void Init() 
        {
            for (int i = 0;  i < MAX_MEMORY; i++) 
            {
                memory[i] = 0;
            }
        }

        public byte GetByte(ushort address) 
        {
            return memory[address];
        }

    }
}
