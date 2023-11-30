using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameData gameData;
    public GameObject pauseMenu;
    public EntityAttributes playerAttributes;
    public TMP_Text bulletSpeedText;
    public TMP_Text bulletRateText;
    public TMP_Text healthText;
    public TMP_Text playerSpeedText;

    public bool menuActive;

    private void Update()
    {
        if (!Global.playing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuActive)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Start()
    {
        gameData = Global.game.GetComponent<GameData>();
        playerAttributes = Global.player.GetComponent<EntityAttributes>();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        menuActive = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        menuActive = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UpgradeBulletSpeed()
    {
        if (gameData.bulletSpeed >= 20f)
        {
            bulletSpeedText.text = Convert.StringToSprite("MAX LEVEL");
            return;
        }

        if (gameData.points >= gameData.bulletSpeedLevel * 10)
        {
            gameData.bulletSpeed += 1f;
            gameData.points -= gameData.bulletSpeedLevel * 10;
            gameData.bulletSpeedLevel++;

            bulletSpeedText.text = Convert.StringToSprite("Upgrade Bullet Speed For ") + Convert.IntegerToSprite(gameData.bulletSpeedLevel * 10) + Convert.StringToSprite("   Points");
        }
    }

    public void UpgradeBulletFireRate()
    {
        if (gameData.bulletRate <= 0.1f)
        {
            bulletRateText.text = Convert.StringToSprite("MAX LEVEL");
            return;
        }

        if (gameData.points >= gameData.bulletRateLevel * 10)
        {
            gameData.bulletRate -= 0.1f;
            gameData.points -= gameData.bulletRateLevel * 10;
            gameData.bulletRateLevel++;

            bulletRateText.text = Convert.StringToSprite("Upgrade Bullet Fire Rate For ") + Convert.IntegerToSprite(gameData.bulletRateLevel * 10) + Convert.StringToSprite("   Points");
        }
    }

    public void UpgradeMovementSpeed()
    {
        if (gameData.playerSpeed >= 10f)
        {
            playerSpeedText.text = Convert.StringToSprite("MAX LEVEL");
            return;
        }

        if (gameData.points >= gameData.playerSpeedLevel * 10)
        {
            gameData.playerSpeed += 0.25f;
            playerAttributes.speed = gameData.playerSpeed;
            gameData.points -= gameData.playerSpeedLevel * 10;
            gameData.playerSpeedLevel++;

            playerSpeedText.text = Convert.StringToSprite("Upgrade Movement Speed For ") + Convert.IntegerToSprite(gameData.playerSpeedLevel * 10) + Convert.StringToSprite("   Points");
        }
    }

    public void UpgradeHealth()
    {
        if (gameData.points >= gameData.playerHealthLevel * 10)
        {
            gameData.playerHealth += 1;
            playerAttributes.health = gameData.playerHealth;
            gameData.points -= gameData.playerHealthLevel * 10;
            gameData.playerHealthLevel++;

            healthText.text = Convert.StringToSprite("Upgrade Health For ") + Convert.IntegerToSprite(gameData.playerHealthLevel * 10) + Convert.StringToSprite("   Points");
        }
    }
}
