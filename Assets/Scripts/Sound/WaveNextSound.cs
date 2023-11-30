using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveNextSound : MonoBehaviour
{
    public void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
