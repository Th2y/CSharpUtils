using UnityEngine;
using Slider = UnityEngine.UI.Slider;
using TMP_InputField = TMPro.TMP_InputField;

public class SliderTextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Slider _slider;

    [HideInInspector] public bool HasChanged = false;

    public void UpdateSliderValue(string value)
    {
        if (float.TryParse(value, out float floatValue))
        {
            HasChanged = true;

            if (floatValue <= _slider.minValue)
            {
                _slider.value = _slider.minValue;
            }
            else if (floatValue >= _slider.maxValue)
            {
                _slider.value = _slider.maxValue;
            }
            else
            {
                _slider.value = floatValue;
            }
        }
    }

    public void CheckActualInputValue()
    {
        if (float.TryParse(_inputField.text, out float floatValue))
        {
            if (floatValue < _slider.minValue)
            {
                _inputField.text = _slider.minValue.ToString();
            }
            else if (floatValue > _slider.maxValue)
            {
                _inputField.text = _slider.maxValue.ToString();
            }
        }
    }

    public void UpdateTextValue(float value)
    {
        HasChanged = true;
        _inputField.text = value.ToString();
    }

    public string ActualValue()
    {
        return _inputField.text;
    }
}
