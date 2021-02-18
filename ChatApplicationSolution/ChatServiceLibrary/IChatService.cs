using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChatServiceLibrary.Models;

namespace ChatServiceLibrary
{
    /// <summary>
    /// IChatService
    /// Interface definition for the Chat Service
    /// There is a callback contract to the client for one
    /// service operation (see notes and the callback 
    /// interface definition)
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IChatServiceCallback))]
    public interface IChatService
    {
        /// <summary>
        /// Login
        /// Logins the user and client and also registers a callback
        /// to this user/client to receive the messages
        /// </summary>
        /// <param name="userName">the user name to login (string)</param>
        [OperationContract]
        [FaultContract(typeof(DuplicateUserFault))]
        void Login(string userName);

        /// <summary>
        /// Logoff
        /// Logs off the user/client from the service and unregisters
        /// it to receive callbacks
        /// </summary>
        /// <param name="userName">the user name to log off (string)</param>
        [OperationContract]
        void Logoff(string userName);

        /// <summary>
        /// LogInState
        /// Returns the loggedin/connection state of the user
        /// </summary>
        /// <param name="userName">string user name</param>
        /// <returns></returns>
        [OperationContract]
        bool LogInState(string userName);

        // After the client sends a message to the service it EXPECTS
        // a callback from this operation with the ChatMessage object that is
        // created on the Service from it's request. 
        [OperationContract(IsOneWay = false)]
        void SendMessage(string userName, string message);

        /// <summary>
        /// GetMessageHistory
        /// Returns the chat message history as a list
        /// Limited to Last X (defined on the service) Chat Messages
        /// This is stored as a Queue on the Service
        /// </summary>
        /// <param name="messages">a list (string) of formatted messages</param>
        [OperationContract]
        List<ChatMessage> GetMessageHistory();


        [OperationContract]
        String DoWork();

    } // end of interface

} // end of namespace
