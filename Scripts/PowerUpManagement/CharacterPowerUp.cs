using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowerUp : MonoBehaviour
{
    // Start is called before the first frame update

    bool SpeedUp;
    int speedUpTime;
    Character character;
    public GameObject destroyAllParticle,speedUpParticle;
    private void Awake()
    {
        speedUpTime = 5;
        character = transform.GetComponent<Character>();
    }
    private void Update()
    {
        
     if (SpeedUp && character.player)
		{
			StartCoroutine(speedIncreaseFor5Sec());
            SpeedUp = false;
		}
	}
	IEnumerator speedIncreaseFor5Sec()
   {
        character.speed = 3f;
    yield return new WaitForSeconds(speedUpTime);
        character.speed = 1f;
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("DestroyAIPowerUp"))
        {
            CharacterArea[] allCharacterAreas = FindObjectsOfType<CharacterArea>();
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
        }
        if (other.CompareTag("CharacterSpeedUp"))
        {
            SpeedUp = true;
            StartCoroutine(playSpeedUpParticle());
            Destroy(other.gameObject);
        }
    }
    IEnumerator playDestroyEnemiesParticle()
    {
        destroyAllParticle.SetActive(true);
        yield return new WaitForSeconds(2);
        destroyAllParticle.SetActive(false);
    }
    IEnumerator playSpeedUpParticle()
    {
        speedUpParticle.SetActive(true);
        yield return new WaitForSeconds(speedUpTime);
        speedUpParticle.SetActive(false);
    }
}
