using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.UseCases.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAPI.Controllers.Permission
{
    public class UpdatePermissionController(IInputPort<UpdatePermisionRequest> inputPort) :ApiControllerBase
    {
        [HttpPut]
        public async Task UpdatePermission(UpdatePermisionRequest request) {
            await inputPort.Handle(request);
        }
    }
}
