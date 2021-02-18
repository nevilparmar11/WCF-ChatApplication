﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ChatServiceLibrary.Models
{
    /// <summary>
    /// ChatMessage
    /// Describes an object that stores information 
    /// about a chat message (single)
    /// </summary>
    [DataContract]
    public class ChatMessage
    {
        #region Properties

        /// <summary>
        /// Name of the ChatMessage Originator
        /// </summary>
        [DataMember]
        public string Name { get; set; } = "";

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
        public ChatMessage()
        {

        }

        /// <summary>
        /// ChatMessage
        /// Paramterized constructor
        /// </summary>
        /// <param name="name">Name of the message sender (string)</param>
        /// <param name="time">TimeStamp (DateTime universal) of the sender</param>
        /// <param name="message">Message of the sender (string)</param>
        public ChatMessage(string name, DateTime time, string message)
        {
            Name = name;
            TimeStamp = time;
            Message = message;

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
            return $"{TimeStamp.ToLocalTime()} {Name.PadRight(15, ' ')} : {Message}";
        }

    } // end of ChatMessage Object
} // end of namespace
