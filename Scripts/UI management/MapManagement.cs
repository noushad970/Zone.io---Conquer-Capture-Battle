using UnityEngine;
using UnityEngine.UI;

public class MapManagement : MonoBehaviour
{
    public Button mapSelectionButton;
    public Button mapUSButton, mapSingaporeButton, MapCanadaButton, MapMexicoButton;
    public Button mapPanelBackButton;
    public GameObject mapPanel;
    // Start is called before the first frame update
    void Start()
    {
        mapPanel.SetActive(false);
        mapSelectionButton.onClick.AddListener(onClickMapSelection);
        mapUSButton.onClick.AddListener(onClickUSMap);
        mapSingaporeButton.onClick.AddListener(onClickSingaporeMap);
        MapMexicoButton.onClick.AddListener(onClickMexicoMap);
        MapCanadaButton.onClick.AddListener(onClickCanadaMap);
        mapPanelBackButton.onClick.AddListener(onClickBackMap);
    }

    // Update is called once per frame
    
    void onClickMapSelection()
    {
        mapPanel.SetActive(true);
    }
    void onClickUSMap()
    {
        StaticData.mapVal = 0;
        StaticData.SaveMapVal = true;
        mapPanel.SetActive(false);
        DownBarButtonManagement.Instance.OnclickPlay();
    }
    void onClickSingaporeMap()
    {
        StaticData.mapVal = 1;
        StaticData.SaveMapVal = true;
        mapPanel.SetActive(false);
        DownBarButtonManagement.Instance.OnclickPlay();
    }
    void onClickMexicoMap()
    {
        StaticData.mapVal = 2;
        StaticData.SaveMapVal = true;
        mapPanel.SetActive(false);
        DownBarButtonManagement.Instance.OnclickPlay();
    }
    void onClickCanadaMap()
    {
        StaticData.mapVal = 3;
        StaticData.SaveMapVal = true;
        mapPanel.SetActive(false);
        DownBarButtonManagement.Instance.OnclickPlay();
    }
    void onClickBackMap()
    {
        mapPanel.SetActive(false);
        DownBarButtonManagement.Instance.OnclickPlay();
    }
}
