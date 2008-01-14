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
