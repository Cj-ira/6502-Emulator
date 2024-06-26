﻿using _6502_Emulator.Internals.Insturction.Attributes;
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
        public byte A, X, Y; // accumulator, index register X, Index register Y
        byte[] PS; // Processor status.
        Memory memory; // hard coded for now.

        public Cpu()
        {
            memory = new Memory();
            PS = new byte[7];
            Reset();

            //memory.memory[0xFFFC] = (byte)InstructionCodes.INS_LDA_IM;
            //memory.memory[0xFFFD] = 0x15;
        }

        public void Reset() 
        {
            PC = 0xFFFC;
            SP = 0x0100;
            ProssesorSet(Status.C, 0);
            ProssesorSet(Status.Z, 0);
            ProssesorSet(Status.I, 0);
            ProssesorSet(Status.D, 0);
            ProssesorSet(Status.B, 0);
            ProssesorSet(Status.V, 0);
            ProssesorSet(Status.N, 0);
            A = 0; X = 0; Y = 0;
            memory.Init();
        }

        public byte GrabInstruction(TickReferenceWrapper ticker) 
        {
            byte instruction = memory.GetByte(PC++); 
            PC = PC++;
            ticker.reference = ticker.reference-1;
            return instruction;
        }

        public void Run(int tick) 
        {
            TickReferenceWrapper ticker = new TickReferenceWrapper(ref tick);
            while (ticker.reference > 0) 
            {
                byte instruction = GrabInstruction(ticker);
                MethodInfo? info = Mapper.GetInstructionMethod((InstructionCodes)instruction);
                if (info != null)
                    info.Invoke(null, new object[] { this, memory, ticker });
            }
        }

        public byte ProssesorGet(Status status) 
        {
            return PS[(int)status];
        }

        public void ProssesorSet(Status status, byte value) 
        {
            PS[(int)status] = value;
        }
    }
}
