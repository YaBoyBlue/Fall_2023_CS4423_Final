using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    [Header("Mouse")]
    public MouseHandler mouseHandler;

    [Header("Dragable")]
    public string dragableName;
    public bool dragging;

    [Header("Information")]
    public float offsX;
    public float offsY;

    // Start is called before the first frame update
    void Start()
    {
        dragableName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDragging();
    }

    void FixedUpdate()
    {
        Drag();

    }

    private void CheckForDragging()
    {
        if (mouseHandler.dragging && mouseHandler.mRight.dragging) { return; }

        if (mouseHandler.mRight.dragging && mouseHandler.HasMouseObject(gameObject))
        {
            dragging = true;
            mouseHandler.dragging = true;

            offsX = mouseHandler.positionWorld.x - gameObject.GetComponent<Transform>().position.x;
            offsY = mouseHandler.positionWorld.y - gameObject.GetComponent<Transform>().position.y;
        }
        else
        {
            dragging = false;
            mouseHandler.dragging = false;
        }
    }

    private void Drag()
    {
        if (dragging)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(mouseHandler.positionWorld.x - offsX, mouseHandler.positionWorld.y - offsY, 0);
        }
    }
}
