using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Enums;
using RH.Game.Services;
using RH.Game.UnityComponents;
using RH.Game.UnityComponents.UI;

namespace RH.Game.Systems
{
    public class SelectSpellSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private readonly EcsWorld _world;
        private readonly SceneData _sceneData;
        private readonly StaticData _staticData;

        private EcsFilter<CurrentSpell> _filter;

        public void Init()
        {
            CreateDefaultComponent();
            AttachButtonsListener();
        }
        
        public void Destroy()
        {
            DetachButtonsListeners();
        }

        private void CreateDefaultComponent()
        {
            _world.NewEntity().Get<CurrentSpell>().Type = _staticData.DefaultSpell;
        }
        
        private void AttachButtonsListener()
        {
            foreach (SpellButton button in _sceneData.SpellButtons)
                button.SpellTypeChanged += SelectCurrentSpell;
        }

        private void SelectCurrentSpell(SpellType type)
        {
            foreach (int i in _filter)
            {
                ref var currentSpell = ref _filter.Get1(i);
                currentSpell.Type = type;
            }
        }

        private void DetachButtonsListeners()
        {
            foreach (SpellButton button in _sceneData.SpellButtons)
                button.SpellTypeChanged -= SelectCurrentSpell;
        }
    }
}