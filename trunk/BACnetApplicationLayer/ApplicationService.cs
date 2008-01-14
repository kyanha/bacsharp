using System;
using System.Collections.Generic;
using System.Text;

namespace BACnetApplicationLayer
{
    public class ApplicationService
    {
        NetworkLayer network;

        public ApplicationService(NetworkLayer network)
        {
            this.network = network;
        }

        public void SendBACnetPDU(BacnetPDU pdu)
        {
            byte[] buffer = new byte[100];
            UInt16 pos = new UInt16();
            pos = 0;

            pdu.Encode(buffer, ref pos);

            NPDU npdu = new NPDU();
            npdu.Payloads.Data = buffer;
            npdu.Payloads.Length = pos;

            network.SendNPDU(npdu);
        }

        //TODO: only for test, we use a callback
        public BacnetPDU ReceiveNPDU(NPDU npdu)
        {
            BacnetPDU pdu= BacnetPDU.Decode(npdu.Payloads.Data,0);
            return pdu;


        }
        
    }
}
