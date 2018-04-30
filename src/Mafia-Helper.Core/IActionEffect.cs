namespace MafiaHelper.Core
{
    public interface IActionEffect
    {
        string EffectName { get; }

        ActionEffectName? DefaultEffectName { get; }

        //int Duration { get; }
    }
}