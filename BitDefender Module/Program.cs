using JsonRPC;
using Newtonsoft.Json.Linq;
using System;

namespace BitDefender_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiURL = "https://cloud.gravityzone.bitdefender.com/api/v1.0/jsonrpc/";
            Client rpcClient = new Client(apiURL + "push");
            string apiKey = "<<Insertbitdefederkey>>";
            string userPassString = apiKey + ":";
            string authorizationHeader = System.Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes(userPassString));
            rpcClient.Headers.Add("Authorization",
            "Basic " + authorizationHeader);

            JToken parameters = JToken.Parse(@"{
                'status':1,
                'serviceType':'cef',
                'serviceSettings': {
                    'url':'<<HOST-URL>>',
                    'requireValidSslCertificate': false,
                    'authorization': '<<BASE64ENCODED>>'


                 },
                'subscribeToEventTypes': {
                    'adcloud': true,
                    'antiexploit': true,
                    'aph': true,
                    'av': true,
                    'avc': true,
                    'dp': true,
                    'endpoint-moved-in': true,
                    'endpoint-moved-out': true,
                    'exchange-malware': true,
                    'exchange-user-credentials': true,
                    'fw': true,
                    'hd': true,
                    'hwid-change': true,
                    'install': true,
                    'modules': true,
                    'network-monitor': true,
                    'network-sandboxing': true,
                    'new-incident': true,
                    'registration': true,
                    'supa-update-status': true,
                    'sva': true,
                    'sva-load': true,
                    'task-status': true,
                    'troubleshooting-activity': true,
                    'uc': true,
                    'uninstall': true
                }

            }");
            Request request = rpcClient.NewRequest(
            "setPushEventSettings", parameters);
            Response response = rpcClient.Rpc(request);
           
                //JToken result = response.Result;
               Console.WriteLine(response.ToString());
            

        }
    }
}
