using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EntityMovement : MonoBehaviour
{
    [Header("References")]
    Rigidbody2D rigidBody2D;
    BoxCollider2D boxCollider2D;
    private EntityAttributes entityAttributes;

    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        entityAttributes = gameObject.GetComponent<EntityAttributes>();
    }

    public Vector3 ConvertWASD(bool w, bool a, bool s, bool d)
    {
        float inputH = 0;
        float inputV = 0;

        if (w) { inputV++; }
        if (a) { inputH--; }
        if (s) { inputV--; }
        if (d) { inputH++; }

        return new Vector3(inputH, inputV, 0).normalized;
    }

    public void Move(Vector3 direction)
    {
        if (direction == null) { return; }

        rigidBody2D.velocity = direction * (float)entityAttributes.speed;
    }
}
