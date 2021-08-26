using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI.Models
{
    public class TestAccountModel
    {
        [JsonProperty("TestAccountModel")]

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
