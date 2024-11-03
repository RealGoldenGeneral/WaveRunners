using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Squares : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    private GameObject[] _sampleCube;
    public float _maxScale;
    private float _barScale;
    // Start is called before the first frame update
    void Start()
    {
        _barScale = 0.3f / (TransformAudio._samples.Length / 64);
        _sampleCube = new GameObject[TransformAudio._samples.Length];
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
        for (int i = 0; i < TransformAudio._samples.Length; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(_barScale, (TransformAudio._samples[i] * _maxScale) + 0.05f, _barScale);
            }
        }
    }
}
