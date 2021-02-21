using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ChatServiceLibrary.Models
{
    /// <summary>
    /// Model for one-one chat message
    /// </summary>
    [DataContract]
    public class SingleChatMessage
    {
        #region Properties

        [DataMember]
        public int MessageId { get; set; }


        [DataMember]
        public int SenderId { get; set; }


        [DataMember]
        public int ReceiveId { get; set; }

        /// <summary>
        /// Name of the ChatMessage Originator
        /// </summary>
        [DataMember]
        public string SenderName { get; set; } = "";

        /// <summary>
        /// Name of the ChatMessage Receriver
        /// </summary>
        [DataMember]
        public string ReceiverName { get; set; } = "";

        /// <summary>
        /// Timestamp of when the message was sent
        /// </summary>
        [DataMember]
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        /// <summary>
        /// Message content
        /// </summary>
        [DataMember]
        public string Message { get; set; } = "";

        #endregion Properties

        #region constructors

        // Default Constructor
        public SingleChatMessage()
        {

        }

        /// <summary>
        /// ChatMessage
        /// Parameterized Constructor
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="senderId"></param>
        /// <param name="receiveId"></param>
        /// <param name="sendername"></param>
        /// <param name="receivername"></param>
        /// <param name="message"></param>
        /// <param name="time"></param>
        public SingleChatMessage(int messageId, int senderId, int receiveId, string sendername, string receivername, string message, DateTime time)
        {
            MessageId = messageId;
            SenderName = sendername;
            ReceiverName = receivername;
            TimeStamp = time;
            Message = message;
            SenderId = senderId;
            ReceiveId = receiveId;
        } // end of constructor

        /// <summary>
        /// ChatMessage
        /// Parameterized Constructor
        /// </summary>
        /// <param name="senderId"></param>
        /// <param name="receiveId"></param>
        /// <param name="sendername"></param>
        /// <param name="receivername"></param>
        /// <param name="message"></param>
        /// <param name="time"></param>
        public SingleChatMessage(int senderId, int receiveId, string sendername, string receivername, string message, DateTime time)
        {
            SenderName = sendername;
            ReceiverName = receivername;
            TimeStamp = time;
            Message = message;
            SenderId = senderId;
            ReceiveId = receiveId;
        } // end of constructor

        #endregion constructors

        /// <summary>
        /// ToString()
        /// Overrides the ChatMessage ToString() object
        /// Time is Displayed in Local Time but Serialized in universal
        /// </summary>
        /// <returns>a formatted string</returns>
        public override string ToString()
        {
            return $"{TimeStamp.ToLocalTime()} {SenderName.PadRight(15, ' ')} : {Message}";
        }
    }
}
