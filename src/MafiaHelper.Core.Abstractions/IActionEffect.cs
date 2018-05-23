namespace MafiaHelper.Core
{
    public interface IActionEffect
    {
        string EffectName { get; }

        bool IsBlocking { get; }

        bool IsNeutralized { get; set; }

        //int Duration { get; }
    }
}