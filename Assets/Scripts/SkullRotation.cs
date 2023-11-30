using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullRotation : MonoBehaviour
{
    public GameObject player;
    public Vector3 skullOrientation;

    void Start()
    {
        player = Global.player;
    }

    void Update()
    {
        skullOrientation = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (transform.position.x < player.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        transform.up = skullOrientation;
    }
}
