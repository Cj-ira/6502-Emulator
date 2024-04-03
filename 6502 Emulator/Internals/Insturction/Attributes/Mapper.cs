using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static _6502_Emulator.Internals.Insturction.Instructions;

namespace _6502_Emulator.Internals.Insturction.Attributes
{
    public  class Mapper
    {
        internal static Dictionary<InstructionCodes, MethodInfo> Instructions;

        public Mapper()
        {
            var methods = Assembly.GetExecutingAssembly().GetTypes()
                .SelectMany(x => x.GetMethods()).Where(y => y.GetCustomAttributes().OfType<InstructionAttribute>().Any())
                .ToDictionary(x => x.GetCustomAttribute<InstructionAttribute>().InstructionCodes);
            Instructions = methods;
        }

        public static MethodInfo GetInstructionMethod(InstructionCodes code) 
        {
            return Instructions[code];
        }
    }
}
