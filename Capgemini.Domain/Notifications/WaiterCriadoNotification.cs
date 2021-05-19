using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capgemini.Domain.Notifications
{
    public class WaiterCriadoNotification : INotification
    {
        public string Name { get; set; }
    }
}
