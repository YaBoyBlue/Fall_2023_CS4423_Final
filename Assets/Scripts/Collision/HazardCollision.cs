using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCollision : MonoBehaviour
{
    //public HazardHitSound hazardHitSound;
    private GameData gameData;
    private EntityAttributes playerAttributes;
    private float timeStart;

    private void Start()
    {
        //hazardHitSound = Global.player.GetComponentInChildren<HazardHitSound>();
        gameData = Global.game.GetComponent<GameData>();
        playerAttributes = Global.player.GetComponent<EntityAttributes>();
        timeStart = Time.time;
    }

    private void Update()
    {
        if (Time.time - timeStart > 15) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Projectile"))
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();

            projectile.direction = projectile.direction * -1;
        }
    }
}
