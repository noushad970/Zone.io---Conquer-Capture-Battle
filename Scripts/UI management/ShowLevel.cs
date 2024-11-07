using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowLevel : MonoBehaviour
{
    public TMP_Text level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level.text="Match Played: "+CloudSaveManager.instance.totalMatchPlayed.ToString();
    }
}
