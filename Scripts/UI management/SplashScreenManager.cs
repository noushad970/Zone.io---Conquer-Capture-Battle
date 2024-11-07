using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    public static SplashScreenManager instance;
    public GameObject SplashScreen;
    static bool stared=false;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(SplashScreenShowAtStart());
        instance = this;
    }
   
    public void SplashScreenShowing()
    {
        
        StartCoroutine(SplashScreenShow());
    }
    IEnumerator SplashScreenShowAtStart()
    {
        SplashScreen.SetActive(true);
        yield return new WaitForSeconds(6f);
        SplashScreen.SetActive(false); 
    }
    IEnumerator SplashScreenShow()
    {
        SplashScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        SplashScreen.SetActive(false);
    }
}
