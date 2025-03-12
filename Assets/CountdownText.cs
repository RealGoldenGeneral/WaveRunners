using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountdownText : MonoBehaviour
{
    private TMP_Text m_Text;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_Text = GetComponent<TMP_Text>();
        Countdown();
    }

    public async void Countdown()
    {
        m_Text.text = "3";

        await Task.Delay(1000);

        m_Text.text = "2";

        await Task.Delay(1000);

        m_Text.text = "1";

        await Task.Delay(1000);

        m_Text.text = "GO!";

        await Task.Delay(100);

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            this.gameObject.SetActive(true);
            m_Text.text = $"{GameState.positions[0].name} Wins!";
        }
    }
}
