using _6502_Emulator.Internals.Insturction.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6502_Emulator.Internals.Insturction
{
    public static class Instructions
    {
        // A bit hard coded, but what ever.
        public enum InstructionCodes
        {
            INS_LDA_IM = 0xA9,
        }

        [InstructionAttribute(InstructionCodes.INS_LDA_IM)]
        public static void LDA_IM() 
        {
        }
    }
}
