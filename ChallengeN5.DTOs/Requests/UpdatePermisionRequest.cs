using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAPI.DTOs.Requests
{
    public class UpdatePermisionRequest
    {
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string PermissionTypeName { get; init; }
        public bool Enable { get; init; }

    }
}
