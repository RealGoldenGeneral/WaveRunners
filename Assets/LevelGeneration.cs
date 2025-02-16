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
    private Mesh[] _meshes;
    private float[] _barHeights;

    // Start is called before the first frame update
    void Start()
    {
        _waveHeight = 0;
        _barHeight = 0;
        _direction = true;
        _sampleCount = -5;
        _updateCount = 0;
        _levelLength = TransformAudio._samples.Length * 4;
        _increment = 0.0000000001f;
        _barScale /= (TransformAudio._samples.Length / 64);
        _bars = new GameObject[_levelLength];
        _meshes = new Mesh[_levelLength];
        samples = new float[_levelLength];
        _barHeights =  new float[_levelLength];
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
            this.transform.position = new Vector3(i * _barScale * -1, 0, 0);
            _bar.transform.position = new Vector3(_levelLength / 2 * _barScale, -4.7f, 0);
            _bar.AddComponent<MeshCollider>();
            _bar.GetComponent<MeshCollider>().sharedMesh = _barMesh;
            _bars[i] = _bar;
            _meshes[i] = _barMesh;
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
                _meshes[i] = _meshes[i + 1];
                _bars[i].GetComponent<MeshFilter>().mesh = _meshes[i];
                _bars[i].GetComponent<MeshCollider>().sharedMesh = _meshes[i];
                _barHeights[i] = _barHeights[i + 1];
            }
            if (_sampleCount > 5)
            {
                _sampleCount = -5;
            }
            if (_waveHeight <= 0)
            {
                _waveHeight = TransformAudio._samples[TransformAudio._samples.Length / 2 + _sampleCount];
                _increment = 0.0000000001f;
            }
            if (_direction)
            {
                _barHeight += _increment;
                _increment *= 2;
                Mesh mesh = MeshGeneration.CreateUpwardsSlope(_barHeight, _barHeight + _increment);
                _meshes[_meshes.Length - 1] = mesh;
                if (_barHeight > _waveHeight)
                {
                    _direction = false;
                    _increment = 0.0000000001f;
                }
            }
            if (!_direction)
            {
                _barHeight -= _increment;
                Mesh mesh = MeshGeneration.CreateDownwardsSlope(_barHeight, _barHeight + _increment);
                _increment *= 2;
                _meshes[_meshes.Length - 1] = mesh;
                if (_barHeight < 0)
                {
                    _direction = true;
                    _waveHeight = 0;
                    _increment = 0.0000000001f;
                }
            }
            _barHeights[_barHeights.Length - 1] = _barHeight;
            _sampleCount++;
            for (int j = samples.Length - 1; j >= 0; j--)
            {
                _bars[j].transform.localScale = new Vector3(_barScale, _maxScale, 1);
            }
        }
        _updateCount++;
    }
}
