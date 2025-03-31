using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    private int _levelLength;
    private GameObject[] _bars;
    private float[] samples;
    public float _maxScale;
    public float _barScale;
    private int _sampleCount;
    private float _waveHeight;
    private float _barHeight;
    private bool _direction; // 1 if upwards, 0 if downwards
    private float _increment;
    private int _updateCount;
    public Material _barMaterial;
    public Material _invisibleWallMaterial;
    private Mesh[] _meshes;
    private float[] _barHeights;

    // Start is called before the first frame update
    void Start()
    {
        // Set all values to start generation
        _waveHeight = 0;
        _barHeight = 0;
        _direction = true;
        _updateCount = 0;
        _levelLength = TransformAudio._samples.Length;
        _increment = 0.0000000001f;
        _barScale /= (TransformAudio._samples.Length / 64);
        _bars = new GameObject[_levelLength];
        _meshes = new Mesh[_levelLength];
        samples = new float[_levelLength];
        _barHeights =  new float[_levelLength];
        int waveLayer = LayerMask.NameToLayer("Waves");

        // Generate 512 bars, representing the heights of the waves
        for (int i = 0; i < _levelLength; i++)
        {
            //GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            //_instanceSampleCube.transform.position = this.transform.position;
            //_instanceSampleCube.transform.parent = this.transform;
            //_instanceSampleCube.name = "SampleCube" + i;
            //this.transform.position = new Vector3(i * _barScale * -1, 0, 0);
            //_instanceSampleCube.transform.position = new Vector3(9.9f, -4.5f, 0);
            //_sampleCube[i] = _instanceSampleCube;

            GameObject _bar = new GameObject();
            _bar.AddComponent<MeshFilter>();
            _bar.AddComponent<MeshRenderer>();
            Mesh _barMesh = MeshGeneration.CreateBars(0);
            _bar.GetComponent<MeshFilter>().mesh = _barMesh;
            _bar.GetComponent<MeshRenderer>().material = _barMaterial;
            _bar.transform.position = this.transform.position;
            _bar.transform.parent = this.transform;
            _bar.name = "Bar" + i;
            _bar.layer = waveLayer;
            this.transform.position = new Vector3(i * _barScale * -1, 0, 0);
            _bar.transform.position = new Vector3(_levelLength / 2 * _barScale, -4, 0);
            _bar.AddComponent<MeshCollider>();
            _bar.GetComponent<MeshCollider>().sharedMesh = _barMesh;
            _bars[i] = _bar;
            _meshes[i] = _barMesh;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_updateCount % 15 == 0)
        {
            // Iteratively update every bar forward
            for (int i = 0; i < samples.Length - 1; i++)
            {
                samples[i] = samples[i + 1];
                _meshes[i] = _meshes[i + 1];
                _bars[i].GetComponent<MeshFilter>().mesh = _meshes[i];
                _bars[i].GetComponent<MeshCollider>().sharedMesh = _meshes[i];
                _barHeights[i] = _barHeights[i + 1];
            }
            // Get new wave height and reset increment
            if (_waveHeight <= 0)
            {
                _waveHeight = TransformAudio._samples[Random.Range(0, TransformAudio._samples.Length - 1)];
                _increment = 0.0000000001f;
            }

            // Increment bar height and double increment
            if (_direction)
            {
                _barHeight += _increment;
                _increment *= 2;

                // Apply new mesh
                Mesh mesh = MeshGeneration.CreateUpwardsSlope(_barHeight, _barHeight + _increment);
                _meshes[_meshes.Length - 1] = mesh;

                // Direction switch and increment reset
                if (_barHeight > _waveHeight)
                {
                    _direction = false;
                    _increment = 0.0000000001f;
                }
            }

            // Decrements bar height and double decrement
            if (!_direction)
            {
                _barHeight -= _increment;
                _increment *= 2;

                // Apply new mesh
                Mesh mesh = MeshGeneration.CreateDownwardsSlope(_barHeight, _barHeight + _increment);
                _meshes[_meshes.Length - 1] = mesh;

                // Direction switch and decrement reset
                if (_barHeight < 0)
                {
                    _direction = true;
                    _waveHeight = 0;
                    _increment = 0.0000000001f;
                }
            }
            _barHeights[_barHeights.Length - 1] = _barHeight;
            _sampleCount++;

            // Transform scale of all bars
            for (int j = samples.Length - 1; j >= 0; j--)
            {
                _bars[j].transform.localScale = new Vector3(_barScale, _maxScale, 1);
            }
        }
        _updateCount++;
    }
}
