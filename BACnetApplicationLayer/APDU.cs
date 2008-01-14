using System;
using System.Collections.Generic;
using System.Text;

namespace BACnetApplicationLayer
{
    public abstract class BacnetPDU
    {
        public enum PDUType
        {
            BACnetUnconfirmedRequestPDU=1,           
        }

        PDUType pduType;

        PDUType PduType
        {
            get { return pduType; }
        }

        public BacnetPDU(PDUType pduType)
        {
            this.pduType=pduType;
        }

        public virtual void Encode(byte[] buffer,ref  UInt16 pos)
        {
            buffer[pos] |= (byte)(0xF0 & ((int)pduType*16));
            pos++;
        }

        public static BacnetPDU Decode(byte[] buffer, UInt16 pos)
        {
            PDUType pduType = (PDUType)((buffer[pos++] & 0xF0)/16);

            BacnetPDU pdu=null;

            switch (pduType)
            {
                case PDUType.BACnetUnconfirmedRequestPDU:
                    pdu = BACnetUnconfirmedRequestPDU.Decode(buffer,  pos);                    
                    break;
            }

            return pdu;
            
        }



    }
}
