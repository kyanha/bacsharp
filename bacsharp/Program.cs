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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Windows.Forms;

namespace bacsharp
{
    public class UdpState
    {
        public UdpClient u;
        public IPEndPoint e;
    }

    public class UDPClient
    {
        private const int UDPPort = 47808;

        private List<Byte> apduData = new List<byte>();

        private List<Byte> bacnetMsg = new List<byte>();

        private bool messageReceived = false;

        public void sendWhoIs()
        {
            sendWhoIs(-1, -1);
        }

        public void sendWhoIs(int lowLimit, int highLimit)
        {
            bacnetMsg.Clear();
            bacnetMsg.Add(BACnetEnums.BACNET_BVLC_TYPE_BIP);
            bacnetMsg.Add(BACnetEnums.BACNET_UNICAST_NPDU);
            bacnetMsg.Add(0); //Length, this is set at the end
            bacnetMsg.Add(0); //Length, this is set at the end
            bacnetMsg.Add(BACnetEnums.BACNET_PROTOCOL_VERSION);
            bacnetMsg.Add(0x20); //Control flags
            bacnetMsg.Add(0xff); // Dest. network address (65535)
            bacnetMsg.Add(0xff); // -"-
            bacnetMsg.Add(0); //Dest. MAC layer address length. 0 = Broadcast on dest. network
            bacnetMsg.Add(0xff); //Hop count = 255

            bacnetMsg.Add((Byte)BACnetEnums.BACNET_PDU_TYPE.PDU_TYPE_UNCONFIRMED_SERVICE_REQUEST);
            bacnetMsg.Add((Byte)BACnetEnums.BACNET_UNCONFIRMED_SERVICE.SERVICE_UNCONFIRMED_WHO_IS);

            if ((lowLimit >= 0) && (lowLimit <= BACnetEnums.BACNET_MAX_INSTANCE) 
                && (highLimit >= 0) && (highLimit <= BACnetEnums.BACNET_MAX_INSTANCE))
            {
            }

            Byte[] msg = new Byte[bacnetMsg.Count];
            bacnetMsg.CopyTo(msg, 0);
            msg[3] = (byte)msg.Length;
            byte[] bytes = new byte[256];

            try
            {
                //udpRecClient.Connect("192.168.3.70", UDPPort);
                //IPHostEntry remoteHostEntry = Dns.GetHostByName("localhost");
                //IPEndPoint remoteIpEndPoint = new IPEndPoint(remoteHostEntry.AddressList[0], UDPPort);
              
                //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                //socket.Bind(new IPEndPoint(IPAddress.Any, UDPPort));
                //socket.Connect(new IPEndPoint(IPAddress.Broadcast, UDPPort)); //IPAddress.Broadcast  IPAddress.Parse("192.168.3.255")
                //socket.Send(msg);
                //Console.WriteLine("Sent " + msg.Length + " bytes...");

                //int availableBytes = socket.Available;
                //Console.WriteLine("Got " + availableBytes + " available bytes...");
                //if (availableBytes > 0)
                //{
                //    byte[] buffer = new byte[availableBytes];
                //    socket.Receive(buffer, 0, availableBytes, SocketFlags.None);
                //    Console.WriteLine("Received " + buffer.Length + " bytes...");
                //}

                //socket.Close();
                //Console.WriteLine("Socket is closed...");

                /////////////////////////////////////////
                UdpClient udpRecClient = new UdpClient(UDPPort, AddressFamily.InterNetwork);
                UdpClient udpSendClient = new UdpClient();
                udpSendClient.EnableBroadcast = true;
                udpSendClient.Connect("192.168.3.255", UDPPort);
                
                IPAddress mcAddress = IPAddress.Parse("224.0.0.1");
                udpRecClient.JoinMulticastGroup(mcAddress);

                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                int nBytesSent = udpSendClient.Send(msg, msg.Length);
                Console.WriteLine(nBytesSent.ToString() + " bytes sent");

                Byte[] received = udpRecClient.Receive(ref remoteIpEndPoint);
                Console.WriteLine("dataReceived: " + received.Length + " bytes...");
                Console.WriteLine("From: " + remoteIpEndPoint);

                if (received.Length > 0)
                {
                    received = udpRecClient.Receive(ref remoteIpEndPoint);
                    Console.WriteLine("dataReceived: " + received.Length + " bytes...");
                    parse(received);

                    //received = udpRecClient.Receive(ref remoteIpEndPoint);
                    //Console.WriteLine("dataReceived: " + received.Length + " bytes...\n*****************************");
                    //if (received.Length > 0)
                    //{
                    //    parse(received);
                    //}
                }
                ///////////////////////////////////////////
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void parse(byte[] bytes)
        {
            if (bytes[0] == BACnetEnums.BACNET_BVLC_TYPE_BIP)
            {
                Console.WriteLine("Incoming BACnet/IP message");
            }
            if (bytes[1] == BACnetEnums.BACNET_UNICAST_NPDU)
            {
                Console.WriteLine("It's a Original-Unicast NPDU");
            }
            int len = bytes[2] + bytes[3];
            Console.WriteLine("Message lenght: " + len + " bytes");

            if (bytes[4] == BACnetEnums.BACNET_PROTOCOL_VERSION)
            {
                Console.WriteLine("Protocol version 1");
            }

            if (bytes[5] == 0x20)
            {
                Console.WriteLine("Control flags OK");
            }
            byte[] temp = new byte[2];
            temp[0] = bytes[7];
            temp[1] = bytes[6];
            int destNet = BitConverter.ToUInt16(temp, 0);
            Console.WriteLine("Destination network: " + destNet);

            Console.WriteLine("Dest. MAC layer address: " + bytes[8]);

            Console.WriteLine("Hop count: " + bytes[9]);

            if (bytes[10] == (byte)BACnetEnums.BACNET_PDU_TYPE.PDU_TYPE_UNCONFIRMED_SERVICE_REQUEST)
            {
                Console.WriteLine("This is an unconfirmed request");
            }

            if (bytes[11] == (byte)BACnetEnums.BACNET_UNCONFIRMED_SERVICE.SERVICE_UNCONFIRMED_I_AM)
            {
                Console.WriteLine("We have received an 'i-Am'");
            }
            
            //bytes[12];
            //bytes[13];
            //bytes[14];
            //bytes[15];
            temp = new byte[4];
            temp[0] = bytes[16];
            temp[1] = bytes[15];
            temp[2] = bytes[14];
            temp[3] = 0x00;
            int deviceId = BitConverter.ToInt32(temp, 0);
            Console.WriteLine("This is device: " + deviceId);

            //bytes[17];
            temp = new byte[2];
            temp[0] = bytes[19];
            temp[1] = bytes[18];
            //int maxAPDULen = bytes[18];
            int maxAPDULen = BitConverter.ToInt16(temp, 0);
            Console.WriteLine("Max APDU length accepted: " + maxAPDULen);

            //bytes[19];
            //bytes[20];

            //bytes[21];
            int vendorId = bytes[22];
            Console.WriteLine("VendorId: " + vendorId);
        }

        //public void SendData()
        //{
        //    try
        //    {
        //        //Create an instance of UdpClient.
        //        UdpClient udpClient = new UdpClient("192.168.3.70", UDPPort);
        //        Byte[] inputToBeSent = new Byte[] {
        //            0x81, // BACnet/IP
        //            0x0a, // Multicast 
        //            0x00, // BVLC-length
        //            0x0c, //   -"-
        //            0x01, // Protocol version 1
        //            0x20, // Control flags
        //            0xff, // Destination network address
        //            0xff, //   -"-
        //            0x00, // Destination MAC address (0=Broadcast on destination network)
        //            0xff, // Hop count
        //            0x10, // APDU-type: Unconfirmed request
        //            0x08  // Unconfirmed service choice: who-is
        //            };
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("An Exception Occurred!");
        //        Console.WriteLine(e.ToString());
        //    }
        //}

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
