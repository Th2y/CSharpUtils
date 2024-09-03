using TMPro;
using UnityEngine;

public class VersionController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _versionText;
    [SerializeField] private VersionSettings _versionSettings;

    private void Awake()
    {
        string version = _versionSettings.VersionNumber;
        string bundleVersion = _versionSettings.BundleVersion;

        _versionText.text = _versionText.text + version + " - " + bundleVersion;
    }
}
