using System;
using System.Collections.Generic;
using System.Text;

namespace BACnetApplicationLayer
{
    public class BVLI
    {
        Payload payload=new Payload();

        public Payload Payloads
        {
            get { return payload; }
            set { payload = value; }
        }

        public void Encode(byte[] buffer, ref  UInt16 pos)
        {
            buffer[pos++] = 0x81; //BACnet/IP
            buffer[pos++] = 0x0b; // (Orgtinal-Broadcast-NPDU)
            buffer[pos++] = 0x00; // BVLC - length
            buffer[pos++] = 0x18; // 4 of 24 bytes packet length //TODO

            payload.Encode(buffer, ref pos);
        }

    }
}
