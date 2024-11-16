using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    public static SplashScreenManager Instance;
    public GameObject SplashScreen,loadingBar;
    static bool stared=false;
    private void Start()
    {
        StartCoroutine(SplashScreenShowAtStart());
    }
    // Start is called before the first frame update
    private void Awake()
    {
        
        if (Instance == null)
        {
            // If not, set this as the Instance and mark it to not be destroyed
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an Instance already exists, destroy this duplicate
            Destroy(gameObject);
        }
    }
   
    public void SplashScreenShowing()
    {
        loadingBar.SetActive(false);
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
        yield return new WaitForSeconds(2f);
        SplashScreen.SetActive(false);
    }
    IEnumerator LoadingBarSpin()
    {
        loadingBar.SetActive(true);
        yield return new WaitForSeconds(1f);
        loadingBar.SetActive(false);
    }
    public void showLoadingBar()
    {
        StartCoroutine (LoadingBarSpin());
    }
}
