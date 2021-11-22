using RH.Game.Settings;
using System.Collections.Generic;
using static RH.Game.Spells.Spell;

namespace RH.Game.Spells
{
    public static class SpellBuilder
    {
        public static Spell ProjectileTapSpell() =>
            new Spell(new TapCondition(), new ProjectileFromHero(), new EmptyBehavior());

        public static Spell ProjectileDrawSpell() =>
            new Spell(new EnoughDragCondition(GameSettings.Instance.ProjectileInputLenght), new ProjectileFromDraw(), new EmptyBehavior());

        public static Spell ProjectileArrowSpell() =>
            new Spell(new DrawArrowCondition(), new ProjectileByArrow(), new EmptyBehavior());


        public static Spell ShieldSpell() =>
            new Spell(new EnoughDragCondition(GameSettings.Instance.ShieldInputLenght), new Shield(), new EmptyBehavior());

        public static Spell ShieldByLine() =>
            new Spell(
                new List<CastCondition> { new DrawLineCondition(), new EnoughDragCondition(GameSettings.Instance.ShieldInputLenght) },
                new Shield(),
                new EmptyBehavior());

        public static Spell ShieldByLineInEmptySpace() =>
            new Spell(
                new List<CastCondition> { new DrawLineCondition(), new EnoughDragCondition(GameSettings.Instance.ShieldInputLenght), new DrawInEmptySpace() },
                new Shield(),
                new EmptyBehavior());


        public static Spell TransparentShield() =>
            new Spell(new EnoughDragCondition(GameSettings.Instance.ShieldInputLenght), new Shield(isTransparent: true), new EmptyBehavior());

        public static Spell SwordHit() =>
            new Spell(new TapCondition(), new SwordHitCast(), new CooldownBehavior(.5f));

        public static Spell Push() =>
            new Spell(new DrawArrowCondition(), new Push(), new EmptyBehavior());

        public static Spell DeathLine() =>
            new Spell(new DrawOverEnemy(), new HitAllInDraw(), new EmptyBehavior());
    }
}
