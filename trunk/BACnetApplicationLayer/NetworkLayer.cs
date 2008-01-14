using System;
using System.Collections.Generic;
using System.Text;

namespace BACnetApplicationLayer
{
    public class NetworkLayer
    {
        LinkLayer link;

        public NetworkLayer(LinkLayer link)
        {
            this.link = link;    
        }

        public void SendNPDU(NPDU pdu)
        {
            byte[] buffer = new byte[100];
            UInt16 pos = new UInt16();
            pos = 0;

            pdu.Encode(buffer, ref pos);

            BVLI bvli = new BVLI();
            bvli.Payloads.Data = buffer;
            bvli.Payloads.Length = pos;

            link.SendBVLI(bvli);
        }
    }
}
