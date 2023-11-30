using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public CoinCollectSound coinCollectSound;
    private GameData gameData;
    private float timeStart;

    private void Start()
    {
        coinCollectSound = Global.player.GetComponentInChildren<CoinCollectSound>();
        gameData = Global.game.GetComponent<GameData>();
        timeStart = Time.time;
    }

    private void Update()
    {
        if (Time.time - timeStart > 20) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameData.points += 10;
        coinCollectSound.PlaySound();
        Destroy(gameObject);
    }
}
