using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootSound : MonoBehaviour
{
    public void PlaySound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
