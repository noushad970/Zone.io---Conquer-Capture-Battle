using UnityEngine;

public class ContinousRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust this for faster or slower rotation

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
