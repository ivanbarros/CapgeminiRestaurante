﻿using Capgemini.Domain.Entities.Base;
using System;

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

        private string controllerName;

        public string ControllerName
        {
            get { return controllerName; }
            set { controllerName = value; }
        }

        public DateTime ErrorDay { get; set; }

    }
}
