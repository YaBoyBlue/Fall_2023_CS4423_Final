using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileCollision : MonoBehaviour
{
    public GameData gameData;
    public CoinDropSound coinDropSound;
    public HeartDropSound heartDropSound;
    private Spawner spawner;
    public GameObject coin;
    public GameObject heart;
    public GameObject hazard;
    private float timeStart;

    private void Start()
    {
        gameData = Global.game.GetComponent<GameData>();
        coinDropSound = Global.player.GetComponentInChildren<CoinDropSound>();
        heartDropSound = Global.player.GetComponentInChildren<HeartDropSound>();
        spawner = Global.game.GetComponent<Spawner>();
        coin = Prefabs.singleton.coin;
        heart = Prefabs.singleton.heart;
        hazard = Prefabs.singleton.hazard;
        
        timeStart = Time.time;
    }

    private void Update()
    {
        if (Time.time - timeStart > 10) { Destroy(gameObject); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Hazard")) { return; }

        EntityAttributes thisAttributes = gameObject.GetComponent<EntityAttributes>();
        EntityAttributes thatAttributes = collision.gameObject.GetComponent<EntityAttributes>();

        thisAttributes.health -= thatAttributes.damageOutputOnCollision;
        thatAttributes.health -= thisAttributes.damageOutputOnCollision;

        if (thisAttributes.health < 1) { Destroy(gameObject); }
        if (thatAttributes.health < 1) 
        { 
            spawner.enemiesKilled++;


            Vector3 position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);

            if (Random.Range(0, 2) == 0)
            {
                Instantiate(coin, position, Quaternion.identity);
                coinDropSound.PlaySound();
            }
            else if (Random.Range(0,4) == 0)
            {
                Instantiate(heart, position, Quaternion.identity);
                heartDropSound.PlaySound();
            }
            else if (Random.Range(0, 2) == 0)
            {
                Instantiate(hazard, position, Quaternion.identity);
            }

            gameData.points++;
        }
    }
}
