using UnityEngine;

namespace RH.Game.Projectiles
{
    public class ProjectileSpawner
    {
        private readonly Projectile.ProjectileData _data;

        public ProjectileSpawner(Projectile.ProjectileData data)
        {
            _data = data;
        }
        
        public void Spawn(Vector3 from, Vector3 direction)
        {
            Projectile projectile = Object.Instantiate(_data.Prefab, from, Quaternion.identity);

            projectile.Init(_data);
            projectile.Launch(direction);
        }
    }
}