using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.Presenters;
using ChallengeAPI.UseCases.Common;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAPI.Controllers.Employee
{
    public class CreateEmployeeController(IInputPort<CreateEmployeeRequest> inputPort,
        IOutputPort<CreateEmployeeResponse> outputPort) : ApiControllerBase
    {

        [HttpPost]
        public async Task<CreateEmployeeResponse> CreateEmployee(CreateEmployeeRequest request)
        {
            await inputPort.Handle(request);
            return ((IPresenter<CreateEmployeeResponse>)outputPort).Content;
        }
    }
}
