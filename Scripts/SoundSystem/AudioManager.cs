using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource coinSound, boomSound, winSound, BoostSound, GemSound, tabSound, swapSound, unlockOrBuySound,eliminateAenemy,GameOverSound;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    public void playCoinSound()
    {
        coinSound.Play();
    }
    public void playBoomSound()
    {
        boomSound.Play();
        VibrateController.instance.Buy();
    }
    public void playGemSound()
    {
        StartCoroutine(gemSoundMng());
    }
    public void playTabSound()
    {
        tabSound.Play();
    }
    public void playSwapSound()
    {
        swapSound.Play();
    }
    public void playUnlockOrBuySound()
    {
        unlockOrBuySound.Play();
    }
    public void playBoostSound()
    {
        BoostSound.Play();
    }
    public void playEliminateEnemySound()
    {
        eliminateAenemy.Play();
    }
    public void PlayGameOverSound()
    {
        GameOverSound.Play();
    }
    IEnumerator gemSoundMng()
    {
        GemSound.Play();
        yield return new WaitForSeconds(1f);
        GemSound.Stop();
    }
}
