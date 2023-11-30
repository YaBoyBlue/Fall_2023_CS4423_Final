using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollision : MonoBehaviour
{
    public HeartCollectSound heartCollectSound;
    private GameData gameData;
    private EntityAttributes playerAttributes;
    private float timeStart;

    private void Start()
    {
        heartCollectSound = Global.player.GetComponentInChildren<HeartCollectSound>();
        gameData = Global.game.GetComponent<GameData>();
        playerAttributes = Global.player.GetComponent<EntityAttributes>();
        timeStart = Time.time;
    }

    private void Update()
    {
        if (Time.time - timeStart > 20) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerAttributes.health + 1 <= gameData.playerHealth)
        {
            playerAttributes.health++;
            heartCollectSound.PlaySound();
            Destroy(gameObject);
        }
    }
}
