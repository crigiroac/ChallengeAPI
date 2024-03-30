namespace ChallengeAPI.UseCases.Common
{
    public interface IOutputPort <in InteractorResposeType>
    {
        Task Handle(InteractorResposeType response);
    }
}
