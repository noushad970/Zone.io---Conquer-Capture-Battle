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
        Handheld.Vibrate(); // 200 milliseconds = 0.2 seconds
#elif UNITY_IOS
        Handheld.Vibrate(); // iOS only supports a simple vibration
#else
        Debug.Log("Vibration not supported on this platform.");
#endif
    }

    
}
