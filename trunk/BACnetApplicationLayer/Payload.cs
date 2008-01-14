using System;
using System.Collections.Generic;
using System.Text;

namespace BACnetApplicationLayer
{
    public class Payload
    {
        byte[] data;
        UInt16 length;

        public byte[] Data            
        {
            get { return data; }
            set { data = value; }
        }

        public UInt16 Length
        {
            get { return length; }
            set { length = value; }
        }

        public void Encode(byte[] buffer, ref  UInt16 pos)
        {
            for (int i = 0; i < length; i++)
            {
                buffer[pos++] = data[i];
            }
        }


    }
}
