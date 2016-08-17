using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenAoB
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class ArrayOfBytes
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private dynamic[] ba; // internal byte[] representation
        private string sr; // internal AoBString representation e.g '99 AA BB CC'

        // Define a class or struct for 'tokens' instead of dynamic objects?
        public dynamic[] ByteArray
        {
            get
            {
                return ba;
            }
        }

        public String AoBString
        {
            get
            {
                return sr;
            }
        }

        public ArrayOfBytes(byte[] ar)
        {
            ba = new dynamic[ar.Length];
            for(int i = 0; i < ar.Length; i++)
            {
                ba[i] = new { valueOf = ar[i].ToString("X2") };
            }
            Array.ForEach<byte>(ar, byteToFF);            
        }

        public ArrayOfBytes(String source)
        {
            string[] tokens = source.Split(' ');
            ba = new dynamic[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                ba[i] = new { valueOf = tokens[i] };
            }
        }

        private void byteToFF(byte obj)
        {
            if (sr != null) sr += ' ';
            sr += obj.ToString("X2");
        }

        public override bool Equals(object obj)
        {
            // If this and obj do not refer to the same type, then they are not equal.
            if (obj.GetType() != this.GetType()) return false;

            ArrayOfBytes other = (ArrayOfBytes)obj;

            for ( int i = 0; i < other.ByteArray.Length; i++)
            {
                if (ba[i].valueOf != other.ByteArray[i].valueOf) return false;
            }
            return true;
        }

        // can't handle wildcards well yet
        public byte[] toByteArray()
        {
            byte[] converted = new byte[ba.Length];
            for( int i = 0; i < converted.Length; i++)
            {
                converted[i] = int.Parse(ba[i].valueOf, System.Globalization.NumberStyles.HexNumber);
            }
            return converted;
        }
    }
}
