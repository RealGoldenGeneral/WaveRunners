using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class TransformAudio : MonoBehaviour
{
    public int _numberOfSamples;
    AudioSource _audioSource;
    public static float[] _samples;
    // Start is called before the first frame update
    void Start()
    {
        //if  (_numberOfSamples < 64 || _numberOfSamples > 8192)
        //{
        //    _samples = new float[512];
        //}
        //else
        //{
        //    _samples = new float[_numberOfSamples];
        //}
        //_audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        //GetSpectrumAudioSource();   
    }

    //void GetSpectrumAudioSource()
    //{
    //    _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    //}
}
