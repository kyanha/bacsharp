/*####COPYRIGHTBEGIN####
 -------------------------------------------
 Copyright (C) 2007 Andreas Kahl

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
using BACnetApplicationLayer;

namespace AppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program app = new Program();
            app.DoCompleteTest1();            
        }


        private void DoCompleteTest1()
        {

            byte[] buffer = new byte[20];
            UInt16 pos = new UInt16();
            pos = 0;


            IAmRequest request = new IAmRequest();
            request.DeviceIdentifier = 200;
            request.MaxAPDULengthAccepted.Value = 1024;
            request.VendorID.Value = 15;

            
            request.Encode(buffer,ref pos);
            BacnetPDU pdu=BacnetPDU.Decode(buffer, 0);
        }


        private void DoCompleteTest()
        {
            IAmRequest request = new IAmRequest();
            request.DeviceIdentifier = 200;
            request.MaxAPDULengthAccepted.Value = 1024;
            request.VendorID.Value = 15;

            ApplicationService appService = new ApplicationService( new NetworkLayer(new LinkLayer() ) );
            appService.SendBACnetPDU(request);

        }

        private void DoTests()
        {
           
            byte[] buffer = new byte[20];
            UInt16 pos = new UInt16();
            pos = 0;

            //DoTestVendor(buffer, ref pos);
            DoIAM(buffer, ref pos);
            ShowBuffer(buffer, pos);
        }

        private void DoIAM(byte[] buffer, ref UInt16 pos)
        {
            pos = 0;

            IAmRequest request = new IAmRequest();
            request.DeviceIdentifier = 200;
            request.MaxAPDULengthAccepted.Value = 1024;
            request.VendorID.Value = 15;

            request.Encode(buffer, ref pos);
        }


        private void DoTestVendor(byte[] buffer,ref UInt16 pos)
        {
            pos = 0;

            IAmRequest.Unsigned u = new IAmRequest.Unsigned(15);
            u.Encode(buffer, ref pos);

        }


        private void ShowBuffer(byte[] buffer, UInt16 pos)
        {
            for (uint i = 0; i < pos; i++)
            {
                Console.Write(" 0x{0:X}", buffer[i]);
            }

            Console.WriteLine();
        }


        

    }
}
