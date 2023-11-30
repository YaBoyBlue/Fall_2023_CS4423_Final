using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToGlobal : MonoBehaviour
{
    private void Awake()
    {
        Global.player = gameObject;
    }
}
