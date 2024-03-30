using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAPI.Presenters.Employee
{
    internal class CreateEmployeePresenter : IOutputPort<CreateEmployeeResponse>,
        IPresenter<CreateEmployeeResponse>
    {
        public CreateEmployeeResponse Content { get; private set; }

        public Task Handle(CreateEmployeeResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }        
    }
}
