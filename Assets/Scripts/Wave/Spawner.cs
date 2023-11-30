using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    public WaveNextSound waveNextSound;
    public GameObject player;
    public Wave wave;
    public GameObject enemy;

    [Header("Variables")]
    public Vector3 playerPosition;
    public float cameraOrthographicSize;

    [Header("Properties")]
    public float enemiesSpawned;
    public float enemiesKilled;
    public float lastZone;
    public float timeSinceSpawn;

    [Header("Bounds")]
    public float bN;
    public float bS;
    public float bE;
    public float bW;

    private void Awake()
    {
        timeSinceSpawn = Time.time;
    }

    private void Start()
    {
        waveNextSound = Global.player.GetComponentInChildren<WaveNextSound>();
    }

    private void Update()
    {
        FetchBounds();
        Spawn();
    }

    private void FetchBounds()
    {
        playerPosition = player.transform.position;
        cameraOrthographicSize = Camera.main.orthographicSize;

        bN = playerPosition.y + cameraOrthographicSize;
        bS = playerPosition.y - cameraOrthographicSize;
        bE = playerPosition.x + (cameraOrthographicSize * ((float)Screen.width / (float)Screen.height));
        bW = playerPosition.x - (cameraOrthographicSize * ((float)Screen.width / (float)Screen.height));
    }

    private void Spawn()
    {
        if (!Global.playing)
        {
            return;
        }

        if (enemiesKilled == wave.enemiesInWave)
        {
            wave.wave++;
            wave.FetchWaveProperties();
            enemiesSpawned = 0;
            enemiesKilled = 0;
            timeSinceSpawn = Time.time;
            waveNextSound.PlaySound();
        }

        if (enemiesSpawned >= wave.enemiesInWave || Time.time - timeSinceSpawn < wave.timeBetweenCycle) { return; }

        for (int i = 0; i < wave.enemiesInCycle; i++)
        {
            SpawnEnemy();
        }

        timeSinceSpawn = Time.time;
    }

    private void SpawnEnemy()
    {
        if (lastZone == 0)
        {
            Instantiate(enemy, new Vector3(Random.Range(bW,bE), bN + 1, 0), Quaternion.identity);

            enemiesSpawned++;
            lastZone = 1;
            return;
        }

        if (lastZone == 1)
        {
            Instantiate(enemy, new Vector3(Random.Range(bW, bE), bS - 1, 0), Quaternion.identity);

            enemiesSpawned++;
            lastZone = 2;
            return;
        }

        if (lastZone == 2)
        {
            Instantiate(enemy, new Vector3(bE + 1, Random.Range(bN, bS), 0), Quaternion.identity);

            enemiesSpawned++;
            lastZone = 3;
            return;
        }

        if (lastZone == 3)
        {
            Instantiate(enemy, new Vector3(bW - 1, Random.Range(bN, bS), 0), Quaternion.identity);

            enemiesSpawned++;
            lastZone = 0;
            return;
        }
    }
}
