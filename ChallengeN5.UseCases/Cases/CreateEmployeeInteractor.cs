using ChallengeAPI.BusinessObjects.Entities;
using ChallengeAPI.BusinessObjects.IRepository;
using ChallengeAPI.DTOs.Requests;
using ChallengeAPI.DTOs.Responses;
using ChallengeAPI.UseCases.Common;

namespace ChallengeAPI.UseCases.Cases
{
    internal class CreateEmployeeInteractor : IInputPort<CreateEmployeeRequest>
    {
        readonly IEmployeeRepository employeeRepository;
        readonly IOutputPort<CreateEmployeeResponse> outputPort;
        readonly IUnitOfWork unitOfWork;

        public CreateEmployeeInteractor(IEmployeeRepository employeeRepository,
            IOutputPort<CreateEmployeeResponse> outputPort,
            IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.outputPort = outputPort;
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateEmployeeRequest request)
        {
            Employee newEmployee = new();
            var exists = employeeRepository.Get(e => e.Email == request.Email);
            if (exists != null)
            {
                throw new Exception("Employee exists");
                //new ExceptionsResponse()
                //{
                //    Message = "Employee exists",
                //    Timespan = DateTime.Now
                //};
            }

            newEmployee.Name = request.Name;
            newEmployee.Email = request.Email;
            newEmployee.PhoneNumber = request.PhoneNumber;
            newEmployee.LastName = request.LastName;

            employeeRepository.Add(newEmployee);


            await unitOfWork.SaveChanges();
            await outputPort.Handle(new CreateEmployeeResponse()
            {
                Id = newEmployee.Id,
                Email = newEmployee.Email
            });


        }
    }
}
