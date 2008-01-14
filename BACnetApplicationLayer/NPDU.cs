using System;
using System.Collections.Generic;
using System.Text;

namespace BACnetApplicationLayer
{
    public class NPDU
    {
        Payload payload=new Payload();

        public Payload Payloads
        {
            get { return payload; }
            set { payload = value; }
        }

        public void Encode(byte[] buffer, ref  UInt16 pos)
        {
            buffer[pos++] = 0x01; //version =1
            buffer[pos++] = 0x20; //control
            buffer[pos++] = 0xff; // DNA=65535
            buffer[pos++] = 0xff; //
            buffer[pos++] = 0x00; // MAC Layer Adr=00
            buffer[pos++] = 0xff; // Hop count=255   
            payload.Encode(buffer, ref pos);

        }

    }
}
