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
