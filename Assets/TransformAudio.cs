using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class TransformAudio : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _samples;
    float[] temp;
    Complex[] _samples2;
    // Start is called before the first frame update
    void Start()
    {
        _samples = new float[512];
        temp = new float[512];
        _samples2 = new Complex[512];
        _audioSource = GetComponent<AudioSource> ();
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.GetOutputData(temp, 0);

        for (int i = 0; i < temp.Length; i++)
        {
            _samples2[i] = new Complex(temp[i], 0);
        }

        FastFourierTransform.FFT(_samples2);

        for (int j = 0; j < _samples2.Length; j++)
        {
            _samples[j] = (float) _samples2[j].Real;
        }
    }
}
