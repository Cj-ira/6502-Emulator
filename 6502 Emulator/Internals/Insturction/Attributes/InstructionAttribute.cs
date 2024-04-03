using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _6502_Emulator.Internals.Insturction.Instructions;

namespace _6502_Emulator.Internals.Insturction.Attributes
{
    public class InstructionAttribute : Attribute
    {
        public InstructionCodes InstructionCodes;

        public InstructionAttribute()
        {
        }

        public InstructionAttribute(InstructionCodes code)
        {
            InstructionCodes = code;
        }
    }
}
