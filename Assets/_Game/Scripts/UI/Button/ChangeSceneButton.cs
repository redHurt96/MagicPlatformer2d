using RH.Utilities.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RH.Game.UI
{
    public class ChangeSceneButton : BaseActionButton
    {
        [SerializeField] private int _sceneBuildIndex;

        protected override void PerformOnClick()
        {
            SceneManager.LoadScene(_sceneBuildIndex);
        }
    }
}