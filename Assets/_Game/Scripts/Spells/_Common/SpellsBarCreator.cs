using System.IO;
using UnityEngine;

namespace RH.Game.Spells
{
    public class SpellsBarCreator
    {
        private GameObject _resource;
        private GameObject _instance;
        private readonly Transform _parent;

        public SpellsBarCreator(Transform parent)
        {
            _parent = parent;
        }

        public void Execute()
        {
            LoadResource();
            _instance = GameObject.Instantiate(_resource, _parent);
        }

        public void Dispose()
        {
            GameObject.Destroy(_instance);
        }

        private void LoadResource()
        {
            if (_resource == null)
                _resource = Resources.Load(Path.Combine("UI", "SpellsBar")) as GameObject;
        }
    }
}
