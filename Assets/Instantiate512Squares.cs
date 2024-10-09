using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Squares : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    private GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.position = new Vector3(i * 0.039f * -1, 0, 0);
            _instanceSampleCube.transform.position = new Vector3(10, -5, 100);
            _sampleCube[i] = _instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(0.039f, (FastFourierTransform._samples[i] * _maxScale) + 0.05f, 0.039f);
            }
        }
    }
}
