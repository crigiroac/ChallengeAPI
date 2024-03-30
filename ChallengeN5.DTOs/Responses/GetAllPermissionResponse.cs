using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAPI.DTOs.Responses
{
    public class GetPermissionResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string PermissionTypeName { get; init; }
        public bool Enable { get; init; }
    }

}
