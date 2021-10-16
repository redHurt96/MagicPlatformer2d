using Between;
using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    public class MoveSpellPainterSystem : IEcsRunSystem
    {
        private EcsFilter<SpellPainter, TouchInput> _filter;

        public void Run()
        {
            foreach (int i in _filter)
                MovePainter(ref _filter.Get1(i), ref _filter.Get2(i));
        }

        private void MovePainter(ref SpellPainter spellPainter, ref TouchInput touchInput)
        {
            spellPainter.Transform.position = GameCamera.ScreenToWorldPoint(touchInput.Points[^1]);
        }
    }
}