/*####COPYRIGHTBEGIN####
 -------------------------------------------
 Copyright (C) 2007 Anders Ågren

 This program is free software; you can redistribute it and/or
 modify it under the terms of the GNU General Public License
 as published by the Free Software Foundation; either version 2
 of the License, or (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program; if not, write to:
 The Free Software Foundation, Inc.
 59 Temple Place - Suite 330
 Boston, MA  02111-1307, USA.

 As a special exception, if other files instantiate templates or
 use macros or inline functions from this file, or you compile
 this file and link it with other works to produce a work based
 on this file, this file does not by itself cause the resulting
 work to be covered by the GNU General Public License. However
 the source code for this file must still be made available in
 accordance with section (3) of the GNU General Public License.

 This exception does not invalidate any other reasons why a work
 based on this file might be covered by the GNU General Public
 License.
 -------------------------------------------
####COPYRIGHTEND####*/

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