using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenPopupController : MonoBehaviour
{
    public Slider progressbar;

    public void ActivateGeneratorButton()
    {
        if (progressbar.value < progressbar.maxValue)
        {
            progressbar.value = progressbar.value + 800 * Time.deltaTime;
        }
    }
}
