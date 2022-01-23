namespace RS.Fritz.Manager.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    
    public sealed record HostsListPathLink(IEnumerable<Uri> Link)
    {
        public string? TheString;

    }
}
