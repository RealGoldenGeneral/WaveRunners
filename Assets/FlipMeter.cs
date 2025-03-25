using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipMeter : MonoBehaviour
{

    public Slider slider;

    public void Appear()
    {
        this.gameObject.SetActive(true);
    }

    public void Disappear()
    {
        this.gameObject.SetActive(false);
    }


    public void SetFlipProgress(float flip)
    {
        slider.value = flip;
    }

    public void SetFillColour(Color color)
    {
        this.gameObject.transform.Find("Fill").GetComponent<Image>().color = color;
    }
}
