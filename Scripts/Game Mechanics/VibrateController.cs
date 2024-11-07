using UnityEngine;

public class VibrateController : MonoBehaviour
{
    public static VibrateController instance;

    private void Awake()
    {
        instance = this;
    }
    public void Buy()
    {
#if UNITY_ANDROID
        Vibrate(200); // 200 milliseconds = 0.2 seconds
#elif UNITY_IOS
        Handheld.Vibrate(); // iOS only supports a simple vibration
#else
        Debug.Log("Vibration not supported on this platform.");
#endif
    }

    private void Vibrate(long milliseconds)
    {
        // Only available on Android
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

        if (vibrator != null)
        {
            vibrator.Call("vibrate", milliseconds);
            vibrator.Dispose();
        }

        currentActivity.Dispose();
        unityPlayer.Dispose();
    }
}
