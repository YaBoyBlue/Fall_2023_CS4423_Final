using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateWave : MonoBehaviour
{
    public Wave waveComponent;
    public TMP_Text waveText;

    private void Update()
    {
        waveText.text = "<sprite name=\"W\"><sprite name=\"A\"><sprite name=\"V\"><sprite name=\"E\"> " + Convert.IntegerToSprite(waveComponent.wave);
    }
}
