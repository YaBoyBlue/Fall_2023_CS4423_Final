using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityInput : MonoBehaviour
{
    EntityMovement entityMovement;

    [Header("Input")]
    [SerializeField]
    private bool inputW;
    [SerializeField]
    private bool inputA;
    [SerializeField]
    private bool inputS;
    [SerializeField]
    private bool inputD;

    // Start is called before the first frame update
    void Start()
    {
        entityMovement = gameObject.AddComponent<EntityMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        FetchInput();
    }

    private void FixedUpdate()
    {
        entityMovement.Move(entityMovement.ConvertWASD(inputW, inputA, inputS, inputD));
    }

    private void FetchInput()
    {
        if (!Global.playing)
        {
            return;
        }

        inputW = Input.GetKey(KeyCode.W);
        inputA = Input.GetKey(KeyCode.A);
        inputS = Input.GetKey(KeyCode.S);
        inputD = Input.GetKey(KeyCode.D);
    }
}
