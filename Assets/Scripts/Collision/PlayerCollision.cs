using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public PlayerHitSound playerHitSound;
    private Spawner spawner;
    public GameObject coin;
    public GameObject heart;

    private void Start()
    {
        playerHitSound = Global.player.GetComponentInChildren<PlayerHitSound>();
        spawner = Global.game.GetComponent<Spawner>();
        coin = Prefabs.singleton.coin;
        heart = Prefabs.singleton.heart;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Hazard") || collision.gameObject.name.Contains("Wall") || collision.gameObject.name.Contains("Heart") || collision.gameObject.name.Contains("Coin")) { return; }

        EntityAttributes thisAttributes = gameObject.GetComponent<EntityAttributes>();
        EntityAttributes thatAttributes = collision.gameObject.GetComponent<EntityAttributes>();

        thisAttributes.health -= thatAttributes.damageOutputOnCollision;
        thatAttributes.health -= thisAttributes.damageOutputOnCollision;

        if (thisAttributes.health < 1)
        {
            Global.playing = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            Destroy(gameObject);
        }
        if (thatAttributes.health < 1)
        {
            spawner.enemiesKilled++;
            if (Random.Range(0, 5) == 0)
            {
                Instantiate(coin, collision.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(collision.gameObject);
        }

        playerHitSound.PlaySound();
    }
}
