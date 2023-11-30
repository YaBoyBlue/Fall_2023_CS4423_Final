using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("References")]
    public GameData gameData;
    private EntityMovement entityMovement;

    [Header("Properties")]
    [SerializeField]
    public Vector3 positionStart;
    [SerializeField]
    public Vector3 positionEnd;

    [SerializeField]
    private float timeStart;
    [SerializeField]
    private float timeAlive;
    [SerializeField]
    private float timeEnd;

    [SerializeField]
    private Vector3 heading;
    [SerializeField]
    private float distance;
    [SerializeField]
    public Vector3 direction;

    void Awake()
    {
        gameData = Global.game.GetComponent<GameData>();
        entityMovement = GetComponent<EntityMovement>();
        timeStart = Time.time;

        gameObject.GetComponent<EntityAttributes>().speed = gameData.bulletSpeed;
    }

    void Start()
    {
        direction = positionEnd - positionStart;
        direction.z = 0;
        direction.Normalize();

        
    }

    void Update()
    {
        FetchTimeAlive();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void FetchTimeAlive()
    {
        timeAlive = Time.time - timeStart;
    }

    private void Move()
    {
        if (timeAlive > 5)
        {
            Destroy(gameObject);
            return;
        }

        entityMovement.Move(direction);
    }
}
