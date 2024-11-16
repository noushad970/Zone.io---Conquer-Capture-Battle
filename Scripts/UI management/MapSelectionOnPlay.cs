using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelectionOnPlay : MonoBehaviour
{
    [SerializeField]
    GameObject mapUS, mapSinga, mapMexi, MapCana;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Map value currently is: "+CloudSaveManager.instance.mapValues);
        if (CloudSaveManager.instance.mapValues == 0)
        {
            mapUS.SetActive(true);
            mapSinga.SetActive(false);
            mapMexi.SetActive(false);
            MapCana.SetActive(false);
        }
        else if(CloudSaveManager.instance.mapValues == 1)
        {
          
                mapUS.SetActive(false);
                mapSinga.SetActive(true);
                mapMexi.SetActive(false);
                MapCana.SetActive(false);
            
        }
        else if (CloudSaveManager.instance.mapValues == 2)
        {
                mapUS.SetActive(false);
                mapSinga.SetActive(false);
                mapMexi.SetActive(true);
                MapCana.SetActive(false);
            
        }
        else if (CloudSaveManager.instance.mapValues == 3)
        {
                mapUS.SetActive(false);
                mapSinga.SetActive(false);
                mapMexi.SetActive(false);
                MapCana.SetActive(true);
           
        }
    }
}
