using Between.Damage;
using RH.Game.Teams;

namespace Between.Damage
{
    public interface IDamagable : ITeamMember
    {
        void ApplyDamage(DamageItem damage);
    }
}