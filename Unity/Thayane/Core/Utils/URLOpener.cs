using UnityEngine;
using TMPro;

public class URLOpener : MonoBehaviour
{
    [SerializeField] private string _urlTo = "";
    [SerializeField] private TextMeshProUGUI _textToChangeColor;
    [SerializeField] private string _hexColor;

    public void OpenURL()
    {
        if (_textToChangeColor != null)
        {
            _textToChangeColor.color = Utils.hexToColor(_hexColor);
        }

        OpenURL(_urlTo);
    }

    public void OpenURL(string url)
    {
#if UNITY_IOS
        SFSafariView.LaunchUrl(url);     
#else
        Application.OpenURL(url);
#endif
    }
}
