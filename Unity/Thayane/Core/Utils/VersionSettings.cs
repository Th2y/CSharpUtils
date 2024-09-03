#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

[CreateAssetMenu(fileName = "VersionData", menuName = "Version Data")]
public class VersionSettings : ScriptableObject, UnityEditor.Build.IPreprocessBuildWithReport
{
    public string VersionNumber;
    public string BundleVersion;

    public int callbackOrder { get { return 0; } }

    public void OnPreprocessBuild(BuildReport report)
    {
        CheckVersion();
    }

    private void OnValidate()
    {
        CheckVersion();
    }

    public void CheckVersion()
    {
        int versionSaved = int.Parse(VersionNumber.Replace(".", ""));
        int versionSettings = int.Parse(PlayerSettings.bundleVersion.Replace(".", ""));

        if (versionSaved != versionSettings)
        {
            if (versionSaved > versionSettings)
            {
                PlayerSettings.bundleVersion = VersionNumber;
            }
            else
            {
                VersionNumber = PlayerSettings.bundleVersion;
            }

            Debug.LogWarning("Changed Version Number to: " + VersionNumber);
        }

        int bundleVersionSaved = int.Parse(BundleVersion);
        int bundleVersionSettingsAndroid = PlayerSettings.Android.bundleVersionCode;
        int bundleVersionSettingsIOS = int.Parse(PlayerSettings.iOS.buildNumber);
        int maxVersion = Mathf.Max(bundleVersionSaved, bundleVersionSettingsAndroid, bundleVersionSettingsIOS);

        BundleVersion = maxVersion.ToString();
        PlayerSettings.Android.bundleVersionCode = maxVersion;
        PlayerSettings.iOS.buildNumber = BundleVersion;

        Debug.LogWarning("Changed Bundle Version to: " + BundleVersion);
    }
}
#else
using UnityEngine;

[CreateAssetMenu(fileName = "VersionData", menuName = "Version Data")]
public class VersionSettings : ScriptableObject
{
    public string VersionNumber;
    public string BundleVersion;
}
#endif
