using System;

namespace Capgemini.Domain.DTOs
{
    public class LogDTO
    {
        
        public string Method_Name { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ErrorDay { get; set; }
    }
}
