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
        public enum InstructionCodes : Byte
        {
            INS_LDA_IM = 0xA9,
        }

        // C# has ficky controls when moving stuff through invokes via reference, so I decided to make a wrapper instead.
        public class TickReferenceWrapper 
        {
            public int reference;

            public TickReferenceWrapper(ref int tick)
            {
                reference = tick;
            }
        }

        [InstructionAttribute(InstructionCodes.INS_LDA_IM)]
        public static void LDA_IM(Cpu cpu, Memory mem, TickReferenceWrapper ticker) 
        {
            byte val = cpu.GrabInstruction(ref ticker.reference);
            cpu.A = val;
            cpu.ProssesorSet(Status.Z, (cpu.A == 0) ? (byte)0 : (byte)1);
            cpu.ProssesorSet(Status.N, (cpu.A & 0b10000000) > 0 ? (byte)0 : (byte)1);
        }
    }
}
