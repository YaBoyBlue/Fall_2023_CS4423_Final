using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitSound : MonoBehaviour
{
    public void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
