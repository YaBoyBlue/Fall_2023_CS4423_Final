using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : MonoBehaviour
{

    [SerializeField]
    KeyHandler keyHandler;

    // Update is called once per frame
    void Update()
    {
        Vector3 vect = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space)) { vect.y = 1; keyHandler.Jump(vect);}
    }
}
