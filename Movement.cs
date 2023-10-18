using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] float vel = 1f;

    public void Move(Vector3 vect)
    {
        //transform.position += vect * Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = vect * vel;
    }
}
