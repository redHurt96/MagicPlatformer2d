using RH.Game.Settings;

namespace RH.Game.Spells
{
    public static class SpellBuilder
    {
        public static Spell ProjectileTapSpell() => 
            new Spell(new Spell.IsTouchCondition(), new Spell.ProjectileFromHero(), new Spell.EmptyBehavior());

        public static Spell ProjectileDrawSpell() =>
            new Spell(new Spell.EnoughDragCondition(GameSettings.Instance.ProjectileInputLenght), new Spell.ProjectileFromDraw(), new Spell.EmptyBehavior());

        public static Spell ShieldSpell() =>
            new Spell(new Spell.EnoughDragCondition(GameSettings.Instance.ShieldInputLenght), new Spell.ShieldCastBehavior(), new Spell.EmptyBehavior());
    }
}
