using System;
using ZenAoB;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "args: " + args);
            ArrayOfBytes aob = new ArrayOfBytes(new byte[] { 0xfe, 0x90 });
            Console.WriteLine(aob.AoBString);
            Console.WriteLine(string.Join(",", aob.ByteArray));
            Console.ReadKey();

            ArrayOfBytes aob2 = new ArrayOfBytes("FF ??");
            Console.WriteLine(aob2.AoBString);
            Console.WriteLine(string.Join(",", aob2.ByteArray));
            Console.ReadKey();
            Console.WriteLine(aob.Equals(aob2));
            Console.ReadKey();
            Console.WriteLine(aob2.Equals(aob2));
            Console.ReadKey();
        }
    }
}
