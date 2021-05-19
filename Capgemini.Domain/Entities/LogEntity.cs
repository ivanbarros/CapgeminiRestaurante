using Capgemini.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.Domain.Entities
{
    public class LogEntity : BaseEntity
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        private string errorMethod;

        public string MethodName
        {
            get { return errorMethod; }
            set { errorMethod = value; }
        }

       
        public DateTime ErrorDay { get; set; }

    }
}
