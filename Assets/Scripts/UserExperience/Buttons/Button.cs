using System;
using UnityEngine;

namespace UserExperience
{
    [RequireComponent(typeof(Button))]
    public abstract class Button : MonoBehaviour
    {
        private void Awake()
        {
            UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();

            button.onClick.AddListener(Route);
        }

        public abstract void Route();
    }
}