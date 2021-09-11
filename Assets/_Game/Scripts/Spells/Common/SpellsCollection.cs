using RH.Utilities.SingletonAccess;

namespace RH.Game.Spells
{
    public class SpellsCollection : Singleton<SpellsCollection>
    {
        public SpellType CurrentSpellType { get; private set; }
        
        public void SelectSpell(int number)
        {
            CurrentSpellType = (SpellType) number;
        }
    }
}