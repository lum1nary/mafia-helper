using System.Collections.Generic;

namespace MafiaHelper.Core
{
    public class MafiaLoopExample
    {
        public MafiaLoopExample()
        {
            IMafiaGame game = null;
            int counter = 0;

            IMafiaRoundResult roundResult = null;
            do
            {
                roundResult = game.PlayNextRound(null); //round)

            } while(!roundResult.IsGameComplete);

            //DisplaySummary(roundResult)
        }
    }
}