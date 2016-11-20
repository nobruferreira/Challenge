using Challenge.SharedKernel.Events.Contracts;
using System;

namespace Challenge.SharedKernel
{
    public class DomainNotification : IDomainEvent
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime DateOcurred { get; set; }

        public DomainNotification(string key, string value)
        {
            this.Key = key;
            this.Value = value;
            this.DateOcurred = DateTime.Now;
        }
    }
}
