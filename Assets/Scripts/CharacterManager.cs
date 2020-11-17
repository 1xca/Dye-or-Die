using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    //Assign in UnityEditor
    public GameObject Prefab;
    
    public float Spawnrate = 2f;
    public int Amount = 10;

    // spawnPosition will be position of Object this script is assigned to
    private Vector3 spawnPosition; 
    private GameObject[] characterPool;
    private int currentCharacterIndex = 0;
    private float timeSinceLastSpawn = 0f;

    void Start()
    {
        spawnPosition = gameObject.transform.position;
        characterPool = new GameObject[Amount];
        
        for(int i = 0; i < Amount; i++)
        {
            GameObject newObject = Instantiate(Prefab, spawnPosition, Quaternion.identity);
            characterPool[i] = newObject;
            newObject.SetActive(false);
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= Spawnrate)
        {
            SpawnCharacter();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnCharacter()
    {
        if(currentCharacterIndex < Amount)
        {
            characterPool[currentCharacterIndex].SetActive(true);
            currentCharacterIndex += 1;
        }
    }
}
