namespace ChallengeAPI.UseCases.Common
{
    public interface IInputPort<in InteInteractorRequestType>
    {
        Task Handle(InteInteractorRequestType request);
    }
}
