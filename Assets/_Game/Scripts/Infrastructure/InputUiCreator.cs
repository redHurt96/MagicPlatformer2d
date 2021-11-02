using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace RH.Game.Infrastructure
{
    public class InputUiCreator
    {
        private readonly Transform _uiParent;

        private readonly Dictionary<InputType, string> _uiModules = new Dictionary<InputType, string>
        {
            { InputType.Buttons, "MoveButtons(default)" },
            { InputType.JoystickAndButton, "MoveJoystickWithJumpButton" },
            { InputType.Joystick, "MoveJumpJoystick" }
        };

        public InputUiCreator(Transform uiParent)
        {
            _uiParent = uiParent;
        }

        public void Execute(InputType type) => Object.Instantiate(Resources.Load(GetFullName(type)), _uiParent);

        private string GetFullName(InputType type) => Path.Combine("UI", _uiModules[type]);

        public enum InputType
        {
            Buttons = 0,
            JoystickAndButton,
            Joystick
        }
    }
}