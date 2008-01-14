using System;
using System.Collections.Generic;
using System.Text;

namespace BACnetApplicationLayer
{
    public class LinkLayer
    {
        public void SendBVLI(BVLI pdu)
        {
            byte[] buffer = new byte[100];
            UInt16 pos = new UInt16();
            pos = 0;

            pdu.Encode(buffer, ref pos);

            ShowData(buffer, pos);
        }

        private void ShowData(byte[] buffer, UInt16 pos)
        {
            for (uint i = 0; i < pos; i++)
            {
                Console.Write(" 0x{0:X}", buffer[i]);
            }

            Console.WriteLine();
        }
    }
}
