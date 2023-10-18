using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] GameObject rock;

    [SerializeField] bool spawn = false;

    public void StartRoutine()
    {
        spawn = true;
        StartCoroutine(SpawnRoutine());
    }

    public void StopRoutine()
    {
        spawn = false;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (spawn)
        {
            Instantiate(rock, new Vector3(12, 0.263f, -0.5f), Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
        
        yield return null;
    }
}
