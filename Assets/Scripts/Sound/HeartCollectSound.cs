using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectSound : MonoBehaviour
{
    public void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
