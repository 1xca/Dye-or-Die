using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance = null;

    //Assign in UnityEditor
    public GameObject Prefab;
    
    public float Spawnrate = 2f;
    public int Amount = 10;

    // spawnPosition will be position of Object this script is assigned to
    private Vector3 spawnPosition; 
    private GameObject[] characterPool;
    private int currentCharacterIndex = 0;
    private float timeSinceLastSpawn = 0f;
    public int charactersAlive = 0;
    public int finishedCharacters = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Amount += GameManager.Instance.GetExtraCharacters();
        spawnPosition = gameObject.transform.position;
        characterPool = new GameObject[Amount];
        charactersAlive = Amount;

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

    /* 
        Public Actions
    */
    public void LoseCharacter(bool hasReachedFinish)
    {
        if(hasReachedFinish)
        {
            finishedCharacters += 1;
        }
        charactersAlive -= 1;
        if(charactersAlive <= 0)
        {
            GameManager.Instance.GameOver(finishedCharacters);
        }
    }
}
