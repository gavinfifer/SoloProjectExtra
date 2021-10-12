using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    public Slider sliderInput;
    public float alphaLevel = .5f;
    
    public void brightnessChange()
    {
        alphaLevel = sliderInput.value;
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alphaLevel);
    }

    // Start is called before the first frame update
    void Start()
    {
        alphaLevel = sliderInput.value;
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alphaLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
