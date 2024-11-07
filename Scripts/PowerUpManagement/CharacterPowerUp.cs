using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> cloneEnemies;
    bool SpeedUp,enemySpeedDown;
    Character character;
    public GameObject destroyAllParticle,speedUpParticle,poisonParticle;
    public static float SpeedUpDuration,PoisonEffectDuration;
    public static bool activespeedDown,BoomSoundPlay;
    private void Start()
    {
        
        character = transform.GetComponent<Character>();
        
    }
    private void Update()
    {
        
        if (SpeedUp && character.player)
        {
            VibrateController.instance.Buy();
            AudioManager.instance.playBoostSound();
            StartCoroutine(speedIncreaseFor5Sec());
            SpeedUp = false;
		}
        if (enemySpeedDown)
        {
            Debug.Log("Enemy");
            enemySpeedDown = false;
            AudioManager.instance.playBoostSound();
            VibrateController.instance.Buy();
            StartCoroutine(EnemySpeedDownFor5Sec());
            
        }
    }
    
    IEnumerator speedIncreaseFor5Sec()
   {
        character.speed = 3.5f;
        yield return new WaitForSeconds(SpeedUpDuration);
        character.speed = 2f;
    }
    IEnumerator EnemySpeedDownFor5Sec()
    {
        activespeedDown = true;
        yield return new WaitForSeconds(PoisonEffectDuration);
        activespeedDown = false;
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("DestroyAIPowerUp"))
        {
            CameraShake cameraShake = Camera.main.GetComponent<CameraShake>();
            cameraShake.TriggerShake(.2f, .5f);

            BoomSoundPlay = true;
            CharacterArea[] allCharacterAreas = FindObjectsOfType<CharacterArea>();
            if(destroyAllParticle!=null)
            StartCoroutine(playDestroyEnemiesParticle());
            // Iterate through each found GameObject
            foreach (CharacterArea characterAreas in allCharacterAreas)
            {
                // Skip the current GameObject (the one this script is attached to)
                if (characterAreas.gameObject != this.gameObject && !characterAreas.character.player)
                {
                    characterAreas.character.Die();
                    
                }
            }
           
            Destroy(other.gameObject);
            PowerupObjectSpawner.totalSpawned--;
        }
        if (other.CompareTag("CharacterSpeedUp"))
        {
           
            SpeedUp = true;
            if(speedUpParticle!=null)
            StartCoroutine(playSpeedUpParticle());
            Destroy(other.gameObject);
            PowerupObjectSpawner.totalSpawned--;
        }
        if (other.CompareTag("PoisonSpeedDown"))
        {
            enemySpeedDown = true;
            if(poisonParticle != null)
            StartCoroutine(playPoisonSpeedDownParticle());
            Destroy(other.gameObject);
            PowerupObjectSpawner.totalSpawned--;
        }
    }
    IEnumerator playDestroyEnemiesParticle()
    {
        destroyAllParticle.SetActive(true);
        yield return new WaitForSeconds(3f);
        destroyAllParticle.SetActive(false);
    }
    IEnumerator playSpeedUpParticle()
    {
        speedUpParticle.SetActive(true);
        yield return new WaitForSeconds(SpeedUpDuration);
        speedUpParticle.SetActive(false);
    }
    IEnumerator playPoisonSpeedDownParticle()
    {
        poisonParticle.SetActive(true);
        yield return new WaitForSeconds(PoisonEffectDuration);
        poisonParticle.SetActive(false);
    }
    
}
