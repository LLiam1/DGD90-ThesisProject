using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUIGenButton : MonoBehaviour
{
    public Slider slider;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ActivateGeneratorButton() {

        if(slider.value < slider.maxValue)
        {
            slider.value = slider.value + 200 * Time.deltaTime;
        }

    }


}
