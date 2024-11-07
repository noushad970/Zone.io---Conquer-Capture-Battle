using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRearChar : MonoBehaviour
{
    public GameObject[] lockedRear;
    // Start is called before the first frame update
    void Start()
    {
        disableLockLogoFromRearChar();
    }

    // Update is called once per frame
    void Update()
    {
        disableLockLogoFromRearChar();
    }

    void disableLockLogoFromRearChar()
    {
        Debug.Log("Total Matches played: " + CloudSaveManager.instance.totalMatchPlayed);
        int x = CloudSaveManager.instance.totalMatchPlayed;
        Debug.Log("Total Matches played: " +x);
        
        if (CloudSaveManager.instance.totalMatchPlayed >= 3)
        {
            lockedRear[0].SetActive(false);
        }
         if (CloudSaveManager.instance.totalMatchPlayed >= 6)
        {
            lockedRear[1].SetActive(false);
            lockedRear[0].SetActive(false);
        }
         if (CloudSaveManager.instance.totalMatchPlayed >= 10)
        {
            lockedRear[2].SetActive(false);
            lockedRear[1].SetActive(false);
            lockedRear[0].SetActive(false);
        }
         if(CloudSaveManager.instance.totalMatchPlayed >= 15)
        {
            lockedRear[3].SetActive(false);
            lockedRear[2].SetActive(false);
            lockedRear[1].SetActive(false);
            lockedRear[0].SetActive(false);
        }
         if(CloudSaveManager.instance.totalMatchPlayed >= 20)
        {
            lockedRear[4].SetActive(false);
            lockedRear[3].SetActive(false);
            lockedRear[2].SetActive(false);
            lockedRear[1].SetActive(false);
            lockedRear[0].SetActive(false);
        }
         if (CloudSaveManager.instance.totalMatchPlayed >= 25)
        {
            lockedRear[5].SetActive(false);
            lockedRear[4].SetActive(false);
            lockedRear[3].SetActive(false);
            lockedRear[2].SetActive(false);
            lockedRear[1].SetActive(false);
            lockedRear[0].SetActive(false);
        }
         if (CloudSaveManager.instance.totalMatchPlayed >= 30)
        {
            lockedRear[6].SetActive(false);
            lockedRear[5].SetActive(false);
            lockedRear[4].SetActive(false);
            lockedRear[3].SetActive(false);
            lockedRear[2].SetActive(false);
            lockedRear[1].SetActive(false);
            lockedRear[0].SetActive(false);
        }
         if (CloudSaveManager.instance.totalMatchPlayed >= 40)
        {
            lockedRear[7].SetActive(false);
            lockedRear[6].SetActive(false);
            lockedRear[5].SetActive(false);
            lockedRear[4].SetActive(false);
            lockedRear[3].SetActive(false);
            lockedRear[2].SetActive(false);
            lockedRear[1].SetActive(false);
            lockedRear[0].SetActive(false);
        }
         if (CloudSaveManager.instance.totalMatchPlayed >= 50)
        {
            lockedRear[8].SetActive(false);
            lockedRear[7].SetActive(false);
            lockedRear[6].SetActive(false);
            lockedRear[5].SetActive(false);
            lockedRear[4].SetActive(false);
            lockedRear[3].SetActive(false);
            lockedRear[2].SetActive(false);
            lockedRear[1].SetActive(false);
            lockedRear[0].SetActive(false);
        }
    }

}
