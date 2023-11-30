using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPathing : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private EntityMovement entityMovement;

    [Header("Pathing")]
    [SerializeField]
    private Vector3 heading;
    [SerializeField]
    private float distance;
    [SerializeField]
    private Vector3 direction;

    void Start()
    {
        player = Global.player;

        entityMovement = gameObject.AddComponent<EntityMovement>();
    }

    void Update()
    {
        FetchPathing();
    }

    void FixedUpdate()
    {
        entityMovement.Move(direction);
    }

    private void FetchPathing()
    {
        heading = player.transform.position - gameObject.transform.position;
        distance = heading.magnitude;
        direction = heading / distance;
    }
}
