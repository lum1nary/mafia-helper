namespace MafiaHelper.Core.Testing
{
    public class ClassicGameBuilderFixture
    {
        public MafiaGameBuilder GameBuilder { get; }

        public ClassicGameBuilderFixture()
        {
            var teamFactory = new TeamFactory();
            GameBuilder = new MafiaGameBuilder(teamFactory);
            GameBuilder.SetRules(new ClassicMafiaRules());
        }
    }
}