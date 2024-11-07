using UnityEngine;
using UnityEngine.UI;

public class SceneTimeCounter : MonoBehaviour
{
    float activeSceneTime = 0f; // Total time the scene has been active
    public static int TotalTime;
    //awake to start
    private void Start()
    {
        activeSceneTime = 0;
    }
    void Update()
    {
        // Only count time if the timescale is not zero (i.e., game is not paused)
        if (Time.timeScale > 0)
        {
            activeSceneTime += Time.unscaledDeltaTime;
        }
       // Debug.Log(activeSceneTime);
        TotalTime = (int)activeSceneTime;
    }

    // Optional: A method to retrieve the active scene time for other scripts
   
}
