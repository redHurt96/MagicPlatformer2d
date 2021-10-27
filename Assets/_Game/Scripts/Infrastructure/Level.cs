using RH.Game.Settings;
using RH.Game.Spells;

namespace RH.Game.Infrastructure
{
    public class Level
    {
        private readonly SpellsInitializer _spellsInitializer;

        public Level(GameSettings settings)
        {
            settings.Init();

            _spellsInitializer = new SpellsInitializer();
            _spellsInitializer.Init();
        }

        public void Dispose()
        {
            _spellsInitializer.Dispose();
        }
    }
}