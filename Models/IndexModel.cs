using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnapp.Models
{
    public class IndexModel
    {
        public IndexModel()
        {
            HostName = string.Empty;
            IpAddress = string.Empty;
        }
        public string? HostName { get; set; }
        public string? IpAddress {get; set; }
    }
}