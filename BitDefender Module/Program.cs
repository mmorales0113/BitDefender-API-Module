using JsonRPC;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BitDefender_Module
{
    class Program
    {
        private static string key;
        private static string hostUrl;
        static void Main(string[] args)
        {
            key = "b591e790577192589ac87754f1bb030784efe16d78d03989a62d8a2e17dd8cb9";
            hostUrl = "https://digi360.us";
            SubscribeToEventTypes(key,hostUrl);
            GetPushedEventSettings();
            GetPushEventsStats();
        }
        private static string SubscribeToEventTypes(string key,string hostUrl)
        {
            string apiURL = "https://cloud.gravityzone.bitdefender.com/api/v1.0/jsonrpc/";
            Client rpcClient = new Client(apiURL + "push");
            string apiKey = key;
            string userPassString = apiKey + ":";
            string authorizationHeader = System.Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes(userPassString));
            rpcClient.Headers.Add("Authorization",
            "Basic " + authorizationHeader);

            var parameters = JObject.FromObject(new
            {
                status = 1,
                serviceType= "cef",
                serviceSettings = new
                {
                     url = hostUrl,
                    requireValidSslCertificate = false,
                     authorization = authorizationHeader
                },
                subscribeToEventTypes = new subscribeToEventTypes
                {
                    AdCloud = true,
                    AntiExploit = true,
                    Aph = true,
                    Av = true,
                    Avc = true,
                    Dp = true,
                    EndpointMoveIn = true,
                    EndpointMoveOut = true,
                    ExchangeMalware = true,
                    ExchangeUserCredentials = true,
                    Fw = true,
                    Hd = true,
                    HwidChange = true,
                    Install = true,
                    Modules = true,
                    NetworkMonitor = true,
                    NetworkSandBoxing = true,
                    NewIncident = true,
                    Registration = true,
                    SupaUpdateStatus = true,
                    Sva = true,
                    SvaLoad = true,
                    TaskStatus = true,
                    TroubleShootingActivity = true,
                    Uc = true,
                    Uninstall = true
                }

            });

            Request request = rpcClient.NewRequest(
            "setPushEventSettings", parameters);
            Response response = rpcClient.Rpc(request);
            Console.WriteLine(response.ToString());

            return response.ToString();
        }
        private static void GetPushedEventSettings()
        {
            string apiURL = "https://cloud.gravityzone.bitdefender.com/api/v1.0/jsonrpc/";
            Client rpcClient = new Client(apiURL + "push");
            string apiKey = key;
            string userPassString = apiKey + ":";
            string authorizationHeader = System.Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes(userPassString));
            rpcClient.Headers.Add("Authorization",
            "Basic " + authorizationHeader);

            JToken parameters = JToken.Parse(@"{}");
            Request request = rpcClient.NewRequest(
            "getPushEventSettings", parameters);
            Response response = rpcClient.Rpc(request);
            Console.WriteLine(response.ToString());

        }
        private static void GetPushEventsStats()
        {
            string apiURL = "https://cloud.gravityzone.bitdefender.com/api/v1.0/jsonrpc/";
            Client rpcClient = new Client(apiURL + "push");
            string apiKey = key;
            string userPassString = apiKey + ":";
            string authorizationHeader = System.Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes(userPassString));
            rpcClient.Headers.Add("Authorization",
            "Basic " + authorizationHeader);

            JToken parameters = JToken.Parse(@"{}");
            Request request = rpcClient.NewRequest(
            "getPushEventStats", parameters);
            Response response = rpcClient.Rpc(request);
            Console.WriteLine(response.ToString());

        }
    }
    public struct subscribeToEventTypes
    {
        [JsonProperty("adcloud")]
        public bool AdCloud { get; set; }
        [JsonProperty("antiexploit")]
        public bool AntiExploit { get; set; }
        [JsonProperty("aph")]
        public bool Aph { get; set; }
        [JsonProperty("av")]
        public bool Av { get; set; }
        [JsonProperty("avc")]
        public bool Avc { get; set; }
        [JsonProperty("dp")]
        public bool Dp { get; set; }
        [JsonProperty("endpoint-move-in")]
        public bool EndpointMoveIn { get; set; }
        [JsonProperty("endpoint-move-out")]
        public bool EndpointMoveOut { get; set; }
        [JsonProperty("exchange-malware")]
        public bool ExchangeMalware { get; set; }
        [JsonProperty("exchange-user-credentails")]
        public bool ExchangeUserCredentials { get; set; }
        [JsonProperty("fw")]
        public bool Fw { get; set; }
        [JsonProperty("hd")]
        public bool Hd { get; set; }
        [JsonProperty("hwid-change")]
        public bool HwidChange { get; set; }
        [JsonProperty("install")]
        public bool Install { get; set; }
        [JsonProperty("modules")]
        public bool Modules { get; set; }
        [JsonProperty("network-monitor")]
        public bool NetworkMonitor { get; set; }
        [JsonProperty("network-sandboxing")]
        public bool NetworkSandBoxing { get; set; }
        [JsonProperty("new-incident")]
        public bool NewIncident { get; set; }
        [JsonProperty("registration")]
        public bool Registration { get; set; }
        [JsonProperty("supa-update-status")]
        public bool SupaUpdateStatus { get; set; }
        [JsonProperty("sva")]
        public bool Sva { get; set; }
        [JsonProperty("sva-load")]
        public bool SvaLoad { get; set; }
        [JsonProperty("task-status")]
        public bool TaskStatus { get; set; }
        [JsonProperty("troubleshooting-activity")]
        public bool TroubleShootingActivity { get; set; }
        [JsonProperty("uc")]           
        public bool Uc { get; set; }
        [JsonProperty("uninstall")]
        public bool Uninstall { get; set; }
    }
}
