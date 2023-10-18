using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHandler : MonoBehaviour
{
    public bool busy = false;

    [SerializeField]
    float vel = 1f;

    [SerializeField]
    float wait = 1.6f;

    [SerializeField] RockSpawner rockSpawner;

    [SerializeField]
    GameObject r1;
    [SerializeField]
    GameObject r2;

    [SerializeField]
    GameObject b1;
    [SerializeField]
    GameObject b2;

    [SerializeField]
    Text text;

    public void Jump(Vector3 vect)
    {
        Color b1C = b1.GetComponent<Image>().color;
        Color b2C = b2.GetComponent<Image>().color;

        if (vect.y == 1 && b1C.a == 1f)
        {
            b1C.a = 0f;
            b2C.a = 0f;
            b1.GetComponent<Image>().color = b1C;
            b2.GetComponent<Image>().color = b2C;
            text.GetComponent<Score>().StartRoutine();
            rockSpawner.StartRoutine();
        }


        if (!busy && vect.y == 1)
        {
            StartCoroutine(JumpRoutine());
        }

        IEnumerator JumpRoutine()
        {
            busy = true;

            GetComponent<Rigidbody2D>().velocity = vect * vel;
            r1.GetComponent<Rigidbody2D>().velocity = vect * vel;
            r2.GetComponent<Rigidbody2D>().velocity = vect * vel;

            yield return new WaitForSeconds(wait);

            busy = false;
            yield return null;
        }
    }
}
