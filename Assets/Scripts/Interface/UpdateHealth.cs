using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateHealth : MonoBehaviour
{
    public GameData gameData;
    public EntityAttributes entityAttributes;
    public TMP_Text healthText;
    public string newHealth;

    private string HealthToString(int health)
    {
        char[] healthArray = health.ToString().ToCharArray();
        string r = "";

        for (int i = 0; i < healthArray.Length; i++)
        {
            r += "<sprite name=\"" + healthArray[i].ToString() + "\">";
        }

        return r;
    }

    private void Update()
    {
        newHealth = "<sprite name=\"H\"><sprite name=\"P\"> " + Convert.IntegerToSprite(entityAttributes.health) + "<sprite name=\"ForwardSlash\">" + Convert.IntegerToSprite(gameData.playerHealth);
        healthText.text = newHealth;
    }
}
