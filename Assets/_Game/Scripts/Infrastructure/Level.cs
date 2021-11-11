using UnityEngine;
using RH.Game.Settings;
using RH.Game.Spells;

namespace RH.Game.Infrastructure
{
    public class Level
    {
        public static Transform Player;

        public Level(GameSettings settings, Transform player)
        {
            settings.Init();

            new SpellsInitializer();
            SpellsInitializer.Instance.Init(settings.DefaultCastType);

            Player = player;
        }

        public void Dispose()
        {
            SpellsInitializer.DestroyInstance();
        }
    }
}