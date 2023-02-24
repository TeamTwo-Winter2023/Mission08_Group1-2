using System;

namespace Mission08_Group1_2.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } 

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
