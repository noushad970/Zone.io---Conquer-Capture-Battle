using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenuUIManagement : MonoBehaviour
{
    public Button noAdsButton, SettingButton;
    public GameObject setting;
    // Start is called before the first frame update
    void Start()
    {
        SettingButton.onClick.AddListener(OnclickSetting);
    }

    // Update is called once per frame
    void OnclickSetting()
    {
        AudioManager.instance.playSwapSound();
        setting.SetActive(true);
    }
}
