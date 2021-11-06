using UnityEngine;
using RH.Game.Settings;
using RH.Game.Spells;

namespace RH.Game.Infrastructure
{
    public class Level
    {
        public static Transform Player;
        private readonly SpellsInitializer _spellsInitializer;

        public Level(GameSettings settings, Transform canvas, Transform player)
        {
            settings.Init();

            _spellsInitializer = new SpellsInitializer();
            _spellsInitializer.Init(canvas);

            Player = player;
        }

        public void Dispose()
        {
            _spellsInitializer.Dispose();
        }
    }
}