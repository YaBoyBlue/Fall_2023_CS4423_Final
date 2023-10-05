using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void Move(Vector3 vect)
    {
        transform.position += vect * Time.deltaTime;
    }
}
