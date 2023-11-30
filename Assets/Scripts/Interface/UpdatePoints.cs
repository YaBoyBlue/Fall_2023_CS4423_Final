using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatePoints : MonoBehaviour
{
    public GameData gameData;
    public TMP_Text pointsText;

    private void Update()
    {
        pointsText.text = "<sprite name=\"P\"><sprite name=\"O\"><sprite name=\"I\"><sprite name=\"N\"><sprite name=\"T\"><sprite name=\"S\"> " + Convert.IntegerToSprite(gameData.points);
    }
}
