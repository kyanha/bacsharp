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
    public class BACnetEnums
    {
        public const int BACNET_MAX_INSTANCE = 0x3FFFFF;

        public const int BACNET_PROTOCOL_VERSION = 0x1;

        public const int BACNET_UNICAST_NPDU = 0x0a;

        public const byte BACNET_BVLC_TYPE_BIP = 0x81;

        public enum BACNET_UNCONFIRMED_SERVICE
        {
            SERVICE_UNCONFIRMED_I_AM = 0,
            SERVICE_UNCONFIRMED_I_HAVE = 1,
            SERVICE_UNCONFIRMED_COV_NOTIFICATION = 2,
            SERVICE_UNCONFIRMED_EVENT_NOTIFICATION = 3,
            SERVICE_UNCONFIRMED_PRIVATE_TRANSFER = 4,
            SERVICE_UNCONFIRMED_TEXT_MESSAGE = 5,
            SERVICE_UNCONFIRMED_TIME_SYNCHRONIZATION = 6,
            SERVICE_UNCONFIRMED_WHO_HAS = 7,
            SERVICE_UNCONFIRMED_WHO_IS = 8,
            SERVICE_UNCONFIRMED_UTC_TIME_SYNCHRONIZATION = 9,
            /* Other services to be added as they are defined. */
            /* All choice values in this production are reserved */
            /* for definition by ASHRAE. */
            /* Proprietary extensions are made by using the */
            /* UnconfirmedPrivateTransfer service. See Clause 23. */
            MAX_BACNET_UNCONFIRMED_SERVICE = 10
        }

        public enum BACNET_PDU_TYPE
        {
            PDU_TYPE_CONFIRMED_SERVICE_REQUEST = 0,
            PDU_TYPE_UNCONFIRMED_SERVICE_REQUEST = 0x10,
            PDU_TYPE_SIMPLE_ACK = 0x20,
            PDU_TYPE_COMPLEX_ACK = 0x30,
            PDU_TYPE_SEGMENT_ACK = 0x40,
            PDU_TYPE_ERROR = 0x50,
            PDU_TYPE_REJECT = 0x60,
            PDU_TYPE_ABORT = 0x70
        }
    }
}
