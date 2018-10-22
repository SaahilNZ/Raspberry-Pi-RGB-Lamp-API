using System;
using Newtonsoft.Json;

namespace LampWebApi
{
    public class LampResponse
    {
        [JsonProperty]
        public int Red;
        [JsonProperty]
        public int Green;
        [JsonProperty]
        public int Blue;
    }
}