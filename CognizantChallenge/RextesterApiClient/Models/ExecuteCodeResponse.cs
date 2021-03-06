﻿using Newtonsoft.Json;

namespace CognizantChallenge.RextesterApiClient.Models
{
    public class ExecuteCodeResponse
    {
        public string Warnings { get; set; }
        public string Errors { get; set; }
        public string Result { get; set; }
        public string Stats { get; set; }
        public string Files { get; set; }
        public bool NotLoggedIn { get; set; }

        [JsonIgnore]
        public bool IsSuccess
        {
            get { return string.IsNullOrWhiteSpace(Errors);} 
        }
    }
}
