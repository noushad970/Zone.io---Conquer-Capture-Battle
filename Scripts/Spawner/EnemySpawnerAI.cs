using UnityEngine;

public class EnemySpawnerAI : MonoBehaviour
{
    // Assign this in the Inspector (drag and drop the prefab you want to spawn)
    public GameObject[] Enemies;

    // Assign the empty GameObject in the Inspector
    public Transform[] SpawnPoint;
    GameObject E1,E2,E3,E4;
    bool isReadyToSpawn = false;
    public static int totalEnemiesPresent = 0;
    int randomNumber;
    bool spawnFromPoint1, spawnFromPoint2, spawnFromPoint3, spawnFromPoint4;
    void Start()
    {
        totalEnemiesPresent = 0;
        isReadyToSpawn = false;
        spawnFromPoint1 = false;
        spawnFromPoint2=false;
        spawnFromPoint3=false;
        spawnFromPoint4=false;
        if (totalEnemiesPresent >= 4)
            isReadyToSpawn = false;
        else
            isReadyToSpawn=true;
        // Check if the prefab and spawn location are assigned
        
    }
    private void Update()
    {
        spawnEnemies();
    }
    void spawnEnemies()
    {
        
        if (isReadyToSpawn)
        {
            randomNumber=Random.Range(0,Enemies.Length);

            // Instantiate the object at the spawn location's position and rotation
            if (!spawnFromPoint1)
            {

               E1= Instantiate(Enemies[randomNumber], SpawnPoint[0].position, SpawnPoint[0].rotation);
               
                spawnFromPoint1 =true;
            }
            else if (!spawnFromPoint2)
            {

               E2= Instantiate(Enemies[randomNumber], SpawnPoint[1].position, SpawnPoint[1].rotation);
              
                spawnFromPoint2 = true;
            }
            else if (!spawnFromPoint3)
            {

               E3= Instantiate(Enemies[randomNumber], SpawnPoint[2].position, SpawnPoint[2].rotation);
                
                spawnFromPoint3 = true;
            }
            else if (!spawnFromPoint4)
            {

              E4=  Instantiate(Enemies[randomNumber], SpawnPoint[3].position, SpawnPoint[3].rotation);
             
                spawnFromPoint4 = true;
            }
            totalEnemiesPresent++;
        }
        if(E1==null)
        {
            spawnFromPoint1=false;
        }
        if(E2==null) { spawnFromPoint2=false; } 
        if(E3==null) {  spawnFromPoint3=false; } 
        if (E4==null) {  spawnFromPoint4=false; }
        
    }
}
