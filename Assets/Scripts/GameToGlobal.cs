using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToGlobal : MonoBehaviour
{
    private void Awake()
    {
        Global.game = gameObject;
    }
}
