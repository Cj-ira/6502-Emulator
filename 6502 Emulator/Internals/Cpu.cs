using _6502_Emulator.Internals.Insturction.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static _6502_Emulator.Internals.Insturction.Instructions;

namespace _6502_Emulator.Internals
{
    public enum Status 
    {
        C,
        Z,
        I,
        D,
        B,
        V,
        N
    }

    public class Cpu 
    {
        public ushort PC, SP; // programmer counter, stack pointers
        byte A, X, Y; // accumulator, index register X, Index register Y
        BitArray PS; // Processor status.
        Memory memory; // hard coded for now.


        void Reset() 
        {
            PC = 0xFFFC;
            SP = 0x0100;
            ProssesorSet(Status.C, false);
            ProssesorSet(Status.Z, false);
            ProssesorSet(Status.I, false);
            ProssesorSet(Status.D, false);
            ProssesorSet(Status.B, false);
            ProssesorSet(Status.V, false);
            ProssesorSet(Status.N, false);
            A = 0; X = 0; Y = 0;
            memory.Init();
        }

        byte GrabInstruction(ref int ticker) 
        {
            byte instruction = memory.GetByte(PC++); 
            PC = PC++;
            ticker = ticker--;
            return instruction;
        }

        void Run(int tick) 
        {
            while (tick > 0) 
            {
                byte instruction = GrabInstruction(ref tick);
                MethodInfo info = Mapper.GetInstructionMethod((InstructionCodes)instruction);
                tick =- (int)info.Invoke(null, new object[] { this, memory });
            }
        }

        bool ProssesorGet(Status status) 
        {
            return PS.Get((int)status);
        }

        void ProssesorSet(Status status, bool value) 
        {
            PS.Set((int)status, value);
        }
    }
}
