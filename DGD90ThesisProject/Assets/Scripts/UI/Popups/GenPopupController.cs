using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenPopupController : MonoBehaviour
{
    public Slider progressbar;

    public void Update()
    {
        if(progressbar.value >= progressbar.maxValue)
        {
            GetComponentInParent<GeneratorController>().isGeneratorActive = true;
        }
    }


    public void ActivateGeneratorButton()
    {
        if (progressbar.value < progressbar.maxValue)
        {
            progressbar.value = progressbar.value + 200 * Time.deltaTime;
        }
    }
}
