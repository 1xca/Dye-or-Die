using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance = null;

    //Assign in UnityEditor
    public GameObject Prefab;
    public CameraShake CameraShake;
    
    public float Spawnrate = 2f;
    public int Amount = 10;
    public float gracePeriod = 7f;
    public TextMeshProUGUI timeText;

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
        timeText = GameObject.FindGameObjectWithTag("Timer").GetComponent<TextMeshProUGUI>();

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
        timeSinceLastSpawn += gracePeriod;
    }

    void Update()
    {
        timeSinceLastSpawn -= Time.deltaTime;
        if(gracePeriod >= 0)
        {
            gracePeriod -= Time.deltaTime;
            var ts = TimeSpan.FromSeconds(gracePeriod);
            timeText.text = "TIME  " + string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
        }
        else
        {
            timeText.text = "LEVEL  " + SceneManager.GetActiveScene().buildIndex;
        }
        if(timeSinceLastSpawn <= 0f)
        {
            SpawnCharacter();
            timeSinceLastSpawn = Spawnrate;
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
        else
        {
            StartCoroutine(CameraShake.Shake(0.15f, 0.7f));
        }
        charactersAlive -= 1;
        if(charactersAlive <= 0)
        {
            GameManager.Instance.GameOver(finishedCharacters);
        }
    }
}
