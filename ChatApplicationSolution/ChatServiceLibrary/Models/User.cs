using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ChatServiceLibrary.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }
        
        [DataMember]
        public string Username {get; set;}

        [DataMember]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DataMember]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
