using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class license
    {
        public int Id { get; set; }

        public string LicenseKey { get; set; }

        public string AllowedIp { get; set; }

        public string ServerName { get; set; }

        public int Status { get; set; }

        public DateTime? ExpireDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
