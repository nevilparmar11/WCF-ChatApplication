using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChatServiceLibrary.Models;

namespace ChatServiceLibrary
{
    /// <summary>
    /// IChatServiceCallback
    /// Interface for the chat service callback
    /// </summary>
    [ServiceContract]
    public interface IChatServiceCallback
    {
        /// <summary>
        /// SendClientMessage
        /// Sends the Client recent messages
        /// (When it is connected)
        /// The service does not want to wait on a response from the client
        /// so there is no secondary callback to the service. This is oneway
        /// to the client only. 
        /// </summary>
        /// <param name="message">a ChatMessage object</param>
        [OperationContract(IsOneWay = true)]
        void SendClientMessage(ChatMessage message);

    } // end of interface

} // end of namespace
