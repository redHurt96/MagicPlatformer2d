using System;
using Between.Damage;
using Sirenix.OdinInspector;

namespace RH.Game.Projectiles
{
    public partial class Projectile
    {
        [Serializable]
        public class ProjectileData
        {
            public float Speed;
            public DamageItem Damage;
            
            [AssetsOnly, Required("Required")]
            public Projectile Prefab;
        }
    }
}