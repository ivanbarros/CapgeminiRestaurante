using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.Domain.DTOs
{
    public class LogDTO
    {
        
        public string Method_Name { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ErrorDay { get; set; }
    }
}
