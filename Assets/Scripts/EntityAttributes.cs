using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttributes : MonoBehaviour
{
    [Header("Attributes")]
    public int health;
    public float speed;
    public int damageOutputOnCollision;
    public int damageInputOnCollision;

    /*public Vector3 ePosition;

    private void Update()
    {
        ePosition = gameObject.transform.position;
    }*/
}
