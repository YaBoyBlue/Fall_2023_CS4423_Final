using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHandler : MonoBehaviour
{
    [Header("Position")]
    public Vector3 positionScreen;
    public Vector3 positionWorld;

    [Header("Input")]
    public Bind mRight = new Bind(BindCode.Mouse1);

    [Header("Objects")]
    public LayerMask layerMaskInterface;
    public LayerMask layerMaskWorld;

    public HashSet<GameObject> hitGameObjects;

    public bool dragging;

    void Update()
    {
        FetchPositionScreen();
        FetchPositionWorld();

        FetchBindHovering(mRight);
        FetchBindPressing(mRight);
        FetchBindHolding(mRight);
        FetchBindDragging(mRight);
    }

    void FixedUpdate()
    {
        FetchMouseObjects();
    }

    private void FetchPositionScreen()
    {
        positionScreen = Input.mousePosition;
    }

    private void FetchPositionWorld()
    {
        positionWorld = Camera.main.ScreenToWorldPoint(positionScreen);
    }

    private void FetchBindHovering(Bind bind)
    {
        if (bind.pressing) { return; }

        bool hovering = hitGameObjects.Count > 0;

        if (bind.hovering == hovering)
        {
            return;
        }

        if (hovering)
        {
            bind.hovering = true;
        }
        else
        {
            bind.hovering = false;
        }
    }

    private void FetchBindPressing(Bind bind)
    {
        float time = Time.time;
        bool pressing = Input.GetMouseButton((int)bind.code);

        if (bind.pressing == pressing)
        {
            return;
        }

        if (pressing)
        {
            bind.pressing = pressing;
            bind.lastPressingPositionScreen = positionScreen;
            bind.lastPressingPositionWorld = positionWorld;
            bind.lastPressingTime = time;
        }
        else
        {
            bind.pressing = false;
            bind.lastReleasingPositionScreen = positionScreen;
            bind.lastReleasingPositionWorld = positionWorld;
            bind.lastReleasingTime = time;
        }
    }

    private void FetchBindHolding(Bind bind)
    {
        if (!bind.hovering || !bind.pressing || bind.lastPressingPositionScreen != positionScreen)
        {
            bind.holding = false;
            return;
        }

        float time = Time.time;
        bool holding = time - bind.lastPressingTime > 0.35;

        if (bind.holding == holding)
        {
            return;
        }

        if (holding)
        {
            bind.holding = true;
            bind.lastHoldingTime = time;
        }
    }

    private void FetchBindDragging(Bind bind)
    {
        if (!bind.hovering || !bind.pressing)
        {
            bind.dragging = false;
            return;
        }

        float time = Time.time;
        bool dragging = bind.lastPressingPositionScreen != positionScreen;

        if (bind.dragging == dragging)
        {
            return;
        }

        if (dragging)
        {
            bind.dragging = true;
            bind.lastDraggingTime = Time.time;
            return;
        }
    }

    private void FetchMouseObjects()
    {
        hitGameObjects = new HashSet<GameObject>();

        foreach (RaycastHit2D hit in Physics2D.RaycastAll(positionWorld, Vector3.forward, Mathf.Infinity, layerMaskInterface))
        {
            hitGameObjects.Add(hit.collider.gameObject);
        }

        foreach (RaycastHit2D hit in Physics2D.RaycastAll(positionWorld, Vector3.forward, Mathf.Infinity, layerMaskWorld))
        {
            hitGameObjects.Add(hit.collider.gameObject);
        }
    }

    public bool HasMouseObject(GameObject gameObject)
    {
        if (hitGameObjects.Count == 0) { return false; }

        if (hitGameObjects.Contains(gameObject))
        {
            return true;
        }

        return false;
    }
}
