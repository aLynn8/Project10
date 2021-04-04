using System;

//Aubrey Farnbach (Wright) Section 2 Group 1

namespace SharpenTheSaw.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
