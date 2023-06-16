using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MyWorker
{
    public class NetworkConnectivityCheck
    {
        public static bool ServerStatusBy(string url)
        {
            Ping pingSender = new Ping();
            try
            {
                PingReply reply = pingSender.Send(url);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch (PingException)
            {
                // Ping fejla
            }
            return false;
        }
    }
}
