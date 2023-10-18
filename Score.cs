using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    public int seconds = 0;
    bool loop = true;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void StartRoutine()
    {
        loop = true;
        StartCoroutine(ScoreRoutine());
    }

    public void StopRoutine()
    {   
        loop = false;
        StopCoroutine(ScoreRoutine());
        seconds = 0;
        text.text = "0";
    }

    IEnumerator ScoreRoutine()
    {
        while (loop)
        {
            seconds += 1;
            text.text = seconds.ToString();
            yield return new WaitForSeconds(1);
        }

        yield return null;
    }
}
