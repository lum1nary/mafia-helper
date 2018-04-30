using System.Collections.Generic;
using Xunit;

namespace MafiaHelper.Core.Testing
{
    public class GameCreationTests
    {
        private static MafiaGameBuilder CreateBuilder()
        {
            var factory = new TeamFactory();
            var builder = new MafiaGameBuilder(factory);
            builder.SetRules(new ClassicMafiaRules());
            return builder;
        }

        [Fact]
        public void GameCreationTest()
        {
            var builder = CreateBuilder();
        }
    }
}