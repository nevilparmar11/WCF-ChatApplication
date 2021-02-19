using ChatServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatServiceLibrary
{
    [ServiceContract]
    public interface IOneToOneChatCallback
    {
        /// <summary>
        /// SendMessageToParticularClient
        /// Sends the Client recent messages
        /// (When it is connected)
        /// The service does not want to wait on a response from the client
        /// so there is no secondary callback to the service. This is oneway
        /// to the client only. 
        /// </summary>
        /// <param name="message">a ChatMessage object</param>
        [OperationContract(IsOneWay = true)]
        void SendMessageToParticularClient(SingleChatMessage message);
    }
}
