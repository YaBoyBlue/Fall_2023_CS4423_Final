using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDropSound : MonoBehaviour
{
    public void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
