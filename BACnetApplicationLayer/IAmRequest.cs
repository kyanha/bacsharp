using System;
using System.Collections.Generic;
using System.Text;

namespace BACnetApplicationLayer
{
    public class IAmRequest : BACnetUnconfirmedRequestPDU
    {
        
        public class BACnetSegmentation
        {

            public void Encode(byte[] buffer, ref UInt16 pos)
            {
                buffer[pos++] = 0x91;
                buffer[pos++] = 0x03;
            }

            public void Decode(byte[] buffer, ref UInt16 pos)
            {
                pos+=2;
            }
        }

        public class Unsigned
        {
            uint value;

            public Unsigned(uint value)
            {
                this.value=value;
            }

            public uint Value
            {
                get{ return this.value; }
                set{ this.value=value; }
            }

            public void Encode(byte[] buffer,ref UInt16 pos)
            {
                if (value <= 0xff)
                {
                    buffer[pos++] = 0x21;
                    buffer[pos++] = (byte)(value & 0xFF);     
                    return;
                }

                if (value > 0xff)
                {
                    buffer[pos++] = 0x22;
                    buffer[pos++] = (byte)(value / 0xFF & 0xFF);
                    buffer[pos++] = (byte)(value & 0xFF);                    
                    return;
                }                
            }


            public void Decode(byte[] buffer, ref UInt16 pos)
            {
                byte tag=buffer[pos++];
                if (tag == 0x21)
                {
                    value=buffer[pos++];
                }
                if (tag == 0x22)
                {
                    value = (uint)buffer[pos++] + (uint)buffer[pos++] * 0xff;
                }
                
            }
        }


        public class BACnetObjectIdentifier
        {
            //byte objectType;
            UInt16 objectId;

            public BACnetObjectIdentifier()
            {
            }

            public UInt16 ObjectId
            {
                get{ return objectId; }
                set{ objectId=value; }
            }

            public void Encode(byte[] buffer,ref UInt16 pos)
            {
                buffer[pos++] = 0xC4;
                buffer[pos++] = 0x02;
                buffer[pos++] = 0;
                buffer[pos++] = 0;
                buffer[pos++] = (byte)(objectId & 0xFF);     
            }


            public void Decode(byte[] buffer, ref UInt16 pos)
            {
                pos+=5;
            }
        }



        BACnetObjectIdentifier iAmDeviceIdentifier;
        Unsigned maxAPDULengthAccepted;
        BACnetSegmentation segmentationSupported;
        Unsigned vendorID;        

        public IAmRequest()
            : base(BACnetServiceChoice.IAm)
        {
            vendorID = new Unsigned(0);
            iAmDeviceIdentifier = new BACnetObjectIdentifier();
            segmentationSupported = new BACnetSegmentation();
            maxAPDULengthAccepted = new Unsigned(0);
        }

        public override void Encode(byte[] buffer, ref UInt16 pos)
        {
            base.Encode(buffer, ref pos);
            iAmDeviceIdentifier.Encode(buffer, ref pos);
            maxAPDULengthAccepted.Encode(buffer, ref pos);
            segmentationSupported.Encode(buffer, ref pos);
            vendorID.Encode(buffer, ref pos);           
        }

        public new void Decode(byte[] buffer,ref UInt16 pos)
        {
            iAmDeviceIdentifier.Decode(buffer, ref pos);
            maxAPDULengthAccepted.Decode(buffer, ref pos);
            segmentationSupported.Decode(buffer, ref pos);
            vendorID.Decode(buffer, ref pos);           
        }

        public Unsigned VendorID
        {
            get { return vendorID; }
            set { vendorID = value; }
        }

        public Unsigned MaxAPDULengthAccepted
        {
            get { return maxAPDULengthAccepted; }
            set { maxAPDULengthAccepted = value; }
        }

        public UInt16 DeviceIdentifier
        {
            get { return iAmDeviceIdentifier.ObjectId; }
            set { iAmDeviceIdentifier.ObjectId = value; }
        }






    }
}
