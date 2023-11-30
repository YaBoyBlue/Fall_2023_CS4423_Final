using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledSound : MonoBehaviour
{
    public void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
