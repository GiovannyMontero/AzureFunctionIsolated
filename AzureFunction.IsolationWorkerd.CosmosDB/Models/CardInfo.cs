using Newtonsoft.Json;

namespace AzureFunction.IsolationWorkerd.CosmosDB.Models
{
    public class CardInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("pan")]
        public string Pan { get; set; }

        [JsonProperty("expirationDate")]
        public string ExpirationDate { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }

        [JsonProperty("modifiedDate")]
        public string? ModifiedDate { get; set; }
    }
}
