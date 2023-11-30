using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [Header("References")]
    public Spawner spawner;

    [Header("Properties")]
    public int wave = 1;
    public int enemiesRemaining;

    [Header("Wave Properties")]
    public float enemiesInWave;
    public float enemiesInCycle;
    public float timeBetweenCycle;

    private void Awake()
    {
        FetchWaveProperties();
    }

    public void FetchWaveProperties()
    {
        enemiesInWave = wave * 10;
        enemiesInCycle = wave;
        timeBetweenCycle = enemiesInCycle / 5;
    }
}
