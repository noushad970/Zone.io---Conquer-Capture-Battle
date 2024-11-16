using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter1Second : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(des());
    }

    IEnumerator des()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
