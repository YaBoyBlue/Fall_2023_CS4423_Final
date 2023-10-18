using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rock : MonoBehaviour
{
    RockSpawner rockSpawner;

    GameObject b1;
    GameObject b2;

    Text text;

    GameObject[] rocks;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(-5.5f, 0, 0);
        //Random.Range(-3,-2)

        rockSpawner = GameObject.Find("RockSpawner").GetComponent<RockSpawner>();
        b1 = GameObject.Find("Retribution");
        b2 = GameObject.Find("Press Space To Play");
        text = GameObject.Find("Score").GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Rex Left" || other.gameObject.name == "Rex Right")
        {
            Color b1C = b1.GetComponent<Image>().color;
            Color b2C = b2.GetComponent<Image>().color;
            b1C.a = 1f;
            b2C.a = 1f;
            b1.GetComponent<Image>().color = b1C;
            b2.GetComponent<Image>().color = b2C;
            text.GetComponent<Score>().StopRoutine();
            rockSpawner.StopRoutine();

            rocks = GameObject.FindGameObjectsWithTag("RockTag");

            foreach (GameObject rock in rocks)
            {
                Destroy(rock);
            }
        }

        Destroy(this.gameObject);
    }
}
