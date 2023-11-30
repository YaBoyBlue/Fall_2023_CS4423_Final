using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BindCode
{
    // Mouse

    Mouse0, Mouse1, Mouse2,

    // Alphabet

    A, B, C, D, E, F, G, H, I, J, K, L, M,
    N, O, P, Q, R, S, T, U, V, W, X, Y, Z,

    // Function

    Esc,

    // Modifier

    Shift, Ctrl, Alt
}

[Serializable]
public class Bind
{
    // Information

    public BindCode code;

    // State

    public bool empty;
    public bool hovering;
    public bool pressing;
    public bool holding;
    public bool dragging;

    // Position

    public Vector3 lastPressingPositionScreen;
    public Vector3 lastReleasingPositionScreen;
    public Vector3 lastPressingPositionWorld;
    public Vector3 lastReleasingPositionWorld;

    // Time

    public float lastPressingTime;
    public float lastHoldingTime;
    public float lastDraggingTime;
    public float lastReleasingTime;

    // Construction

    public Bind(BindCode code)
    {
        this.code = code;
    }
}
