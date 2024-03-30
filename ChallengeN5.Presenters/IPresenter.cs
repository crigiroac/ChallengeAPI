namespace ChallengeAPI.Presenters
{
    public interface IPresenter<out FormatDataType>
    {
        public FormatDataType Content { get; }
    }
}
