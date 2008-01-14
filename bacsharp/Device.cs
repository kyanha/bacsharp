using System;
using System.Collections.Generic;
using System.Text;

namespace bacsharp
{
    public class Device
    {
        #region Fields & Constants

        private int vendorId;

        private int deviceId;

        private bool segmentationSupported;

        private int maxAPDULength;

        #endregion

        #region Properties

        public int VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        public int DeviceId
        {
            get { return this.deviceId; }
            set { this.deviceId = value; }
        }

        #endregion

        public void parse(byte[] bytes)
        {
            byte[] temp = new byte[4];
            temp[0] = bytes[2];
            temp[1] = bytes[1];
            temp[2] = bytes[0];
            temp[3] = 0x00;
            this.deviceId = BitConverter.ToInt32(temp, 0);

            //bytes[17];
            temp = new byte[2];
            temp[0] = bytes[19];
            temp[1] = bytes[18];
            this.maxAPDULength = BitConverter.ToInt16(temp, 0);

            //bytes[19];
            //bytes[20];

            //bytes[21];
            this.vendorId = bytes[22];
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("*********************");
            builder.AppendLine("Vendor Id: " + this.vendorId);
            builder.AppendLine("Device id: " + this.deviceId);
            builder.AppendLine("Max APDU length: " + this.maxAPDULength);
            builder.AppendLine("Segmentation supported: " + this.segmentationSupported);
            builder.AppendLine("*********************");
            return builder.ToString();
        }
    }
}