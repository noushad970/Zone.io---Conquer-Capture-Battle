using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GemAndCoinCounter : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text gemText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text=CloudSaveManager.instance.totalCoin.ToString();
        gemText.text = CloudSaveManager.instance.totalGem.ToString();

    }
}
