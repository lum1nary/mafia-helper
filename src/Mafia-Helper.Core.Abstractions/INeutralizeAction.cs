namespace MafiaHelper.Core
{
    public interface INeutralizeAction : IChooseAction
    {
        IActionEffect NeutralizedEffect { get; }
    }
}