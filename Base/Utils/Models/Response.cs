using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace BufaloCargo.Utils.Models
{
    public class Response
    {
        public HttpStatusCode status { get; set; }
        public string response_code { get; set; }
        public string message { get; set; }

        [Display(Name = "length")]
        [JsonProperty("length")]
        public int cantidad { get; set; }
        public int pagina { get; set; }

        public object data = new object();

        public List<object> error = new List<object>();
    }
}
