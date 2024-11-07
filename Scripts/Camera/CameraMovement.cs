using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Transform[] common,rear,epic,special;
	Transform target;
	private Vector3 startOffset;
    private void Start()
    {
        initialize();
    }
   

	private void Update()
	{
        if(target != null)
        {
            transform.position = target.position + startOffset;
        }
	}
	void initialize()
	{
        if (CloudSaveManager.instance.selectedCharValue == 100)
        {
            setActiveFalse();
            common[0].gameObject.SetActive(true);
            target = common[0];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 101)
        {
            setActiveFalse();
            common[1].gameObject.SetActive(true);
            target = common[1];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 102)
        {
            setActiveFalse();
            common[2].gameObject.SetActive(true);
            target = common[2];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 103)
        {
            setActiveFalse();
            common[3].gameObject.SetActive(true);
            target = common[3];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 104)
        {
            setActiveFalse();
            common[4].gameObject.SetActive(true);
            target = common[4];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 105)
        {
            setActiveFalse();
            common[5].gameObject.SetActive(true);
            target = common[5];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 106)
        {
            setActiveFalse();
            common[6].gameObject.SetActive(true);
            target = common[6];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 107)
        {
            setActiveFalse();
            common[7].gameObject.SetActive(true);
            target = common[7];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 108)
        {
            setActiveFalse();
            common[8].gameObject.SetActive(true);
            target = common[8];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 200)
        {
            setActiveFalse();
            rear[0].gameObject.SetActive(true);
            target = rear[0];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 201)
        {
            setActiveFalse();
            rear[1].gameObject.SetActive(true);
            target = rear[1];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 202)
        {
            setActiveFalse();
            rear[2].gameObject.SetActive(true);
            target = rear[2];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 203)
        {
            setActiveFalse();
            rear[3].gameObject.SetActive(true);
            target = rear[3];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 204)
        {
            setActiveFalse();
            rear[4].gameObject.SetActive(true);
            target = rear[4];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 205)
        {
            setActiveFalse();
            rear[5].gameObject.SetActive(true);
            target = rear[5];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 206)
        {
            setActiveFalse();
            rear[6].gameObject.SetActive(true);
            target = rear[6];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 207)
        {
            setActiveFalse();
            rear[7].gameObject.SetActive(true);
            target = rear[7];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 208)
        {
            setActiveFalse();
            rear[8].gameObject.SetActive(true);
            target = rear[8];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 300)
        {
            setActiveFalse();
            epic[0].gameObject.SetActive(true);
            target = epic[0];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 301)
        {
            setActiveFalse();
            epic[1].gameObject.SetActive(true);
            target = epic[1];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 302)
        {
            setActiveFalse();
            epic[2].gameObject.SetActive(true);
            target = epic[2];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 303)
        {
            setActiveFalse();
            epic[3].gameObject.SetActive(true);
            target = epic[3];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 304)
        {
            setActiveFalse();
            epic[4].gameObject.SetActive(true);
            target = epic[4];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 305)
        {
            setActiveFalse();
            epic[5].gameObject.SetActive(true);
            target = epic[5];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 306)
        {
            setActiveFalse();
            epic[6].gameObject.SetActive(true);
            target = epic[6];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 400)
        {
            setActiveFalse();
            special[0].gameObject.SetActive(true);
            target = special[0];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 401)
        {
            setActiveFalse();
            special[1].gameObject.SetActive(true);
            target = special[1];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 402)
        {
            setActiveFalse();
            special[2].gameObject.SetActive(true);
            target = special[2];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 403)
        {
            setActiveFalse();
            special[3].gameObject.SetActive(true);
            target = special[3];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 404)
        {
            setActiveFalse();
            special[4].gameObject.SetActive(true);
            target = special[4];
        }
        else if (CloudSaveManager.instance.selectedCharValue == 405)
        {
            setActiveFalse();
            special[5].gameObject.SetActive(true);
            target = special[5];
        }
        startOffset = transform.position - target.position;
    }
    void setActiveFalse()
    {
        for(int i = 0; i < rear.Length; i++)
        {
            rear[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < common.Length; i++)
        {
            common[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < epic.Length; i++)
        {
            epic[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < special.Length; i++)
        {
            special[i].gameObject.SetActive(false);
        }
    }
}