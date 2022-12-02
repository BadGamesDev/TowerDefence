using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform startTile;
   
    public GameObject enemyBasic;

    public float waveCooldownMax;
    public float waveCooldown;

    public int waveSize;

    private void Start()
    {
        startTile = GameObject.Find("StartTile(Clone)").transform;
        waveCooldown = waveCooldownMax;
        waveSize = 1;
        StartCoroutine(spawnWave());
    }
    
    private void Update()
    {
        waveCooldown -= Time.deltaTime;
    }
    
    IEnumerator spawnWave()
    {
        for (int i = 0; i < waveSize;)
        {
            spawnEnemy();
            i++;
            yield return new WaitForSeconds(0.5f);
        }        
    }
    
    void spawnEnemy()
    {
        Instantiate(enemyBasic, startTile.transform.position, transform.rotation);
    }
}
//FUCK
//Same