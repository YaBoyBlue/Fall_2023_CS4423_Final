using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    [SerializeField] Movement movement;
    
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vect = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.A)) { vect.x = -5; }
        if (Input.GetKey(KeyCode.D)) { vect.x =  5; }
        if (Input.GetKey(KeyCode.W)) { vect.y =  5; }
        if (Input.GetKey(KeyCode.S)) { vect.y = -5; }

        movement.Move(vect);
    }
}
