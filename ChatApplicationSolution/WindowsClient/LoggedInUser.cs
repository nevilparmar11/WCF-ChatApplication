using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClient
{
    public static class LoggedInUser
    {
        public static int UserId { get; set; }

        public static string Name { get; set; }

        public static string Email { get; set; }

        public static string Username { get; set; }

        public static string receiverName { get; set; }

        public static string previousReceiver { get; set; }
    }
}
