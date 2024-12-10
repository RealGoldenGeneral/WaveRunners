using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TMPro;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    private GameObject[] _sampleCube;
    private float[] samples;
    public float _maxScale;
    private float _barScale;
    private float _waveHeight;
    private float _barHeight;
    private bool _direction; // 1 if upwards, 0 if downwards
    private float _increment;
    private int _updateCount;
    // Start is called before the first frame update
    void Start()
    {
        _waveHeight = 0;
        _barHeight = 0;
        _direction = true;
        _updateCount = 0;
        _increment = 0.0000000001f;
        _barScale = 0.3f / (TransformAudio._samples.Length / 64);
        _sampleCube = new GameObject[TransformAudio._samples.Length];
        samples = new float[TransformAudio._samples.Length];
        for (int i = 0; i < TransformAudio._samples.Length; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.position = new Vector3(i * _barScale * -1, 0, 0);
            _instanceSampleCube.transform.position = new Vector3(9.9f, -5, 100);
            _sampleCube[i] = _instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_updateCount % 10 == 0)
        {
            for (int i = 0; i < samples.Length - 1; i++)
            {
                samples[i] = samples[i + 1];
            }
            if (_waveHeight <= 0)
            {
                _waveHeight = TransformAudio._samples[samples.Length / 2];
                _increment = 0.0000000001f;
            }
            if (_direction)
            {
                _barHeight += _increment;
                _increment *= 2;
                if (_barHeight > _waveHeight)
                {
                    _direction = false;
                    _increment = 0.0000000001f;
                }
            }
            if (!_direction)
            {
                _barHeight -= _increment;
                _increment *= 2;
                if (_barHeight < 0)
                {
                    _direction = true;
                    _waveHeight = 0;
                    _increment = 0.0000000001f;
                }
            }
            samples[samples.Length - 1] = _barHeight;
            for (int j = samples.Length - 1; j >= 0; j--)
            {
                _sampleCube[j].transform.localScale = new Vector3(_barScale, (samples[j] * _maxScale), _barScale);
            }
        }
        _updateCount++;
    }
}
