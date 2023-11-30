using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public GameObject playingCanvas;
    public GameObject startingCanvas;

    // Update is called once per frame
    void Update()
    {
        if (!Global.playing && Input.GetKeyDown(KeyCode.Space))
        {
            startingCanvas.SetActive(false);
            playingCanvas.SetActive(true);
            
            Global.playing = true;
        }

        if (!Global.playing && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
