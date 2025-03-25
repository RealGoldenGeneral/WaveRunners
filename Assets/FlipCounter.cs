using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlipCounter : MonoBehaviour
{
    public TMP_Text text;

    public void Appear()
    {
        this.gameObject.SetActive(true);
    }

    public void Disappear()
    {
        this.gameObject.SetActive(false);
    }

    public void SetCounter(int value)
    {
        text.text = $"{value}x";
    }
}
