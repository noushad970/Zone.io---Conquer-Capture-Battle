using System.Collections;
using UnityEngine;

public class PowerupObjectSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // Array of prefabs to spawn
    public int spawnCount = 3;   // Number of objects to spawn
        // Counter to track the total number of spawned objects
    bool readyToSpawn;
    public static int totalSpawned;
    void Start()
    {
        SpawnObjects();
        readyToSpawn=true;
        totalSpawned = 0;
        // Call to display the count after spawning
    }
    private void Awake()
    {
       
    }
    private void Update()
    {
        Debug.Log("Total Spawn:" + totalSpawned);
        if (readyToSpawn && totalSpawned<=3)
        {
            StartCoroutine(SpawnObjects());
        }
        if (CharacterPowerUp.BoomSoundPlay)
        {
            CharacterPowerUp.BoomSoundPlay = false;
            AudioManager.instance.playBoomSound();
        }
    }
    IEnumerator SpawnObjects()
    {
        totalSpawned = 0; // Initialize the counter
        readyToSpawn = false;
        
            // Random position between -45 and 45 for both X and Z, and 0.65 fixed for Y
            Vector3 randomPosition = new Vector3(
                Random.Range(-35f, 35f), // X-axis range
                0.65f,                   // Y position fixed at 0.65
                Random.Range(-35f, 35f)  // Z-axis range
            );

            // Randomly select a prefab from the array
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

            // Instantiate the selected prefab at the random position with no rotation
            Instantiate(prefab, randomPosition, Quaternion.identity);

            // Increment the counter each time an object is spawned
            totalSpawned++;
        
        yield return new WaitForSeconds(10f);
        readyToSpawn=true;
    }

    void DisplaySpawnCount()
    {
        Debug.Log("Total Objects Spawned: " + totalSpawned);
    }
}
