using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ChatServiceLibrary.Faults
{
    /// <summary>
    /// DuplicateUserFault
    /// Holds data object definition for a 
    /// duplicate user fault generated on
    /// the service sent to the client
    /// </summary>
    [DataContract]
    public class DuplicateUserFault
    {
        [DataMember]
        public string Reason { get; set; }

    } // end of class
}
