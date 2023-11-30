using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [Header("Data")]
    public int wave;
    public int points;

    public float bulletSpeed = 10f;
    public int bulletSpeedLevel = 1;
    public float bulletRate = 1.1f;
    public int bulletRateLevel = 1;
    public float playerSpeed = 4f;
    public int playerSpeedLevel = 1;
    public int playerHealth = 10;
    public int playerHealthLevel = 1;
}
