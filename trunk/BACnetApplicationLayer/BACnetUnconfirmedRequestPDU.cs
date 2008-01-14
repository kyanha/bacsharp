using System;
using System.Collections.Generic;
using System.Text;

namespace BACnetApplicationLayer
{
    public abstract class BACnetUnconfirmedRequestPDU : BacnetPDU
    {
        public enum BACnetServiceChoice
        {
            IAm=0,
        }

        BACnetServiceChoice serviceChoice;


        public BACnetUnconfirmedRequestPDU(BACnetServiceChoice serviceChoice)
            : base(BacnetPDU.PDUType.BACnetUnconfirmedRequestPDU)
        {
            this.serviceChoice = serviceChoice;
        }


        public override void Encode(byte[] buffer, ref UInt16 pos)
        {
            base.Encode(buffer,ref pos);
            buffer[pos++] |= (byte)(serviceChoice);
        }

         public static BacnetPDU Decode(byte[] buffer, UInt16 pos)
        {
            BACnetServiceChoice choice = (BACnetServiceChoice)(buffer[pos++]);

            BacnetPDU pdu=null;

            switch (choice)
            {
                case BACnetServiceChoice.IAm:
                    IAmRequest iam = new IAmRequest();
                    iam.Decode(buffer,ref pos);
                    pdu = iam;
                    break;
            }

            return pdu;
            
        }



    }
}
