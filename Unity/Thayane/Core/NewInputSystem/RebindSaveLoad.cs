using UnityEngine;
using UnityEngine.InputSystem;

namespace Thayane.Core.NewInputSystem
{
    public class RebindSaveLoad : MonoBehaviour
    {
        [SerializeField] private InputActionAsset actions;

        [SerializeField] private RebindActionUI[] rebindActions;

        private void Start()
        {
            Load();

            foreach (var action in rebindActions)
            {
                action.UpdateBindingDisplay();
            }
        }

        public void Save()
        {
            var rebinds = actions.SaveBindingOverridesAsJson();

            PlayerPrefs.SetString("rebinds", rebinds);
        }

        public void Load()
        {
            var rebinds = PlayerPrefs.GetString("rebinds");

            if (!string.IsNullOrEmpty(rebinds))
                actions.LoadBindingOverridesFromJson(rebinds);
        }
    }
}
