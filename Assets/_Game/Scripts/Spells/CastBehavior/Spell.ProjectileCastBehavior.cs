using RH.Game.Projectiles;
using RH.Game.Settings;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public abstract class ProjectileCastBehavior : CastBehavior
        {
            protected readonly ProjectileSpawner _spawner;

            public ProjectileCastBehavior()
            {
                _spawner = new ProjectileSpawner(GameSettings.Instance.ProjectileData);
            }
        }
    }
}
