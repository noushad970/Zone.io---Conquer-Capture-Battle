using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryboxManagement : MonoBehaviour
{
     public float targetAngle = -90; // The angle we want to reach
     public float rotationSpeed = 45; // Speed of rotation

    private float currentAngle = 0f;
    bool x=false;
    void Update()
    {
        
     StartCoroutine(waitFor2Sec());   
    }
    IEnumerator waitFor2Sec()
    {
        yield return new WaitForSeconds(2f);
        MoveTo90Degree();
        yield return new WaitForSeconds(2.1f);
        transform.rotation = Quaternion.Euler(0, -180, 0);

    }
    void MoveTo90Degree()
    {
        if (currentAngle > targetAngle)
        {
            // Calculate the rotation step for this frame
            float rotationStep = rotationSpeed * Time.deltaTime;
            currentAngle -= rotationStep;

            // Clamp to make sure it doesn't exceed the target angle
            if (currentAngle < targetAngle)
            {
                currentAngle = targetAngle;
            }

            // Apply the rotation
            transform.rotation = Quaternion.Euler(currentAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

    }
}
