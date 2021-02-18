using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChatServiceLibrary.Models;

namespace ChatServiceLibrary
{

    [ServiceContract(CallbackContract = typeof(IChatServiceCallback))]
    public interface IChatService
    {
      
        [OperationContract]
        [FaultContract(typeof(DuplicateUserFault))]
        bool AddMeToServer(string userName);

       
        [OperationContract]
        bool LeaveServer(string userName);

      
        [OperationContract]
        bool LogInState(string userName);

       
        [OperationContract(IsOneWay = false)]
        void SendMessage(string userName, string message);

       
        [OperationContract]
        List<ChatMessage> GetMessageHistory();

    } // end of interface

} // end of namespace
