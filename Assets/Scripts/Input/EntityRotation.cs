using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityRotation : MonoBehaviour
{
    [Header("Rotation")]
    public Vector3 mousePositionScreen;
    public Vector3 mousePositionWorld;
    public Vector3 entityOrientation;

    void Update()
    {
        mousePositionScreen = Input.mousePosition;
        mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);

        entityOrientation = new Vector3(mousePositionWorld.x - transform.position.x, mousePositionWorld.y - transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        transform.up = entityOrientation;
    }
}
