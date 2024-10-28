using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryboxManagement : MonoBehaviour
{
     float targetAngle = -120f; // The angle we want to reach
     float rotationSpeed = 90f; // Speed of rotation

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
