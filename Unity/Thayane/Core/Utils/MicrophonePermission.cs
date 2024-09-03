using System.Collections;
using UnityEngine;
#if UNITY_ANDROID && !UNITY_EDITOR
using UnityEngine.Android;
#elif UNITY_IOS && !UNITY_EDITOR
using UnityEngine.iOS;
#endif

public class MicrophonePermission : MonoBehaviour
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static MicrophonePermission Instance;

    private void Awake()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            PlayerPrefs.SetString(PlayerPrefsNames.MICROPHONE_PERMISSION, PlayerPrefsNames.MICROPHONE_GRANTED);
            Destroy(gameObject);
        }
        else
        {
            if (PlayerPrefs.HasKey(PlayerPrefsNames.MICROPHONE_PERMISSION))
            {
                if (PlayerPrefs.GetString(PlayerPrefsNames.MICROPHONE_PERMISSION) != PlayerPrefsNames.MICROPHONE_DONT_ASK_AGAIN)
                {
                    RequestPermission();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                RequestPermission();
            }
        }
    }

    public void RequestPermission()
    {
        PermissionCallbacks callbacks = new();
        callbacks.PermissionDenied += OnPermissionDenied;
        callbacks.PermissionGranted += OnPermissionGranted;
        callbacks.PermissionDeniedAndDontAskAgain += OnPermissionDeniedAndDontAskAgain;

        Permission.RequestUserPermission(Permission.Microphone, callbacks);
    }

    private void OnPermissionDeniedAndDontAskAgain(string obj)
    {
        PlayerPrefs.SetString(PlayerPrefsNames.MICROPHONE_PERMISSION, PlayerPrefsNames.MICROPHONE_DONT_ASK_AGAIN);
        Destroy(gameObject);
    }

    private void OnPermissionGranted(string obj)
    {
        PlayerPrefs.SetString(PlayerPrefsNames.MICROPHONE_PERMISSION, PlayerPrefsNames.MICROPHONE_GRANTED);
        Destroy(gameObject);
    }

    private void OnPermissionDenied(string obj)
    {
        PlayerPrefs.SetString(PlayerPrefsNames.MICROPHONE_PERMISSION, PlayerPrefsNames.MICROPHONE_DENIED);

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

#elif UNITY_IOS && !UNITY_EDITOR
    public static MicrophonePermission Instance;

    private void Awake()
    {
        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            PlayerPrefs.SetString(PlayerPrefsNames.MICROPHONE_PERMISSION, PlayerPrefsNames.MICROPHONE_GRANTED);
            Destroy(gameObject);
        }
        else
        {
            RequestPermission();
        }
    }

    public void RequestPermission()
    {
        StartCoroutine(DoRequestPermission());
    }

    private IEnumerator DoRequestPermission()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            PlayerPrefs.SetString(PlayerPrefsNames.MICROPHONE_PERMISSION, PlayerPrefsNames.MICROPHONE_GRANTED);
            Destroy(gameObject);
        }
        else
        {
            PlayerPrefs.SetString(PlayerPrefsNames.MICROPHONE_PERMISSION, PlayerPrefsNames.MICROPHONE_DENIED);

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
#endif
}
