using System;
using System.Collections.Generic;

namespace SDC.WebService.Models
{
    public class StatusInfo
    {
        public StatusInfo()
        { 
        }

        public StatusInfo(bool success, List<string> messages)
        {
            Success = success;
            Messages = messages;
        }
        public bool Success { get; set; }

        public List<string> Messages { get; set; }
    }
}
