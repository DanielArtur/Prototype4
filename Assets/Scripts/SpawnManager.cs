using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRange = 9;
    [SerializeField] GameObject powerupPrefab;

    [Header("Settings")]
    int enemyCount = 0;
    int waveNumber = 1;

    void Start()
    {
        Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
       
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        if (enemyCount == 0)
        {
            Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        

        for (int i = 0; i < enemiesToSpawn; i++)
        {

            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);


        }
        




    }

    Vector3 GenerateRandomPosition()
    {


        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;




    }



}
