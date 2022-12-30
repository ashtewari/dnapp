using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnapp.Models
{
    public class ColorModel
    {
        public ColorModel()
        {
            Color = string.Empty;
            Value = string.Empty;
        }
        public string? Color { get; set; }
        public string? Value {get; set; }
    }
}