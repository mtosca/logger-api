using System;
using System.Collections.Generic;

namespace loggerapi.Models
{
    public class LogDocument
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string Stacktrace { get; set; }
        public string ClassName { get; set; }
    }
}
