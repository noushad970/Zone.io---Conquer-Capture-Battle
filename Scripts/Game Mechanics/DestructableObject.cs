using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to a character
        Character character = other.GetComponent<Character>();
        if (character)
        {
            // Destroy the object
            Destroy(gameObject);
            // Call a method to convert the line to territory
        }
    }
}
