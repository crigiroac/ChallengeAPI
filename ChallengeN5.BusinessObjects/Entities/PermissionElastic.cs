using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAPI.BusinessObjects.Entities
{
    public class PermissionElastic
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PermissionTypeName { get; set; }
        public bool Enable { get; set; }
    }
}
