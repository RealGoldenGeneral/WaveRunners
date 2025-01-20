using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    private GameObject[] _bars;
    private float[] samples;
    public float _maxScale;
    private float _barScale;
    private int _sampleCount;
    private float _waveHeight;
    private float _barHeight;
    private bool _direction; // 1 if upwards, 0 if downwards
    private float _increment;
    private int _updateCount;
    public Material _barMaterial;

    void CreateMesh(Mesh mesh, float x, float y, float z, float ymax)
    {
        mesh.Clear();
        Vector3[] vertices = new Vector3[]
       {
            new Vector3 (0, 0, 0),
            new Vector3 (0, 0, 1),
            new Vector3 (1, 0, 0),
            new Vector3 (1, 0, 1),
            new Vector3 (0, 1, 0),
            new Vector3 (0, 1, 1),
            new Vector3 (1, 1, 0),
            new Vector3 (1, 1, 1)
       };

        int[] triangles = new int[]
        {
            0, 1, 2,
            2, 1, 3,
            0, 1, 5,
            5, 4, 0,
            0, 2, 6,
            6, 4, 0,
            1, 3, 7,
            7, 5, 1,
            2, 3, 7,
            7, 6, 2,
            4, 5, 6,
            6, 5, 7
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    // Start is called before the first frame update
    void Start()
    {
        _waveHeight = 0;
        _barHeight = 0;
        _direction = true;
        _sampleCount = -5;
        _updateCount = 0;
        _increment = 0.0000000001f;
        _barScale = 0.3f / (TransformAudio._samples.Length / 64);
        _bars = new GameObject[TransformAudio._samples.Length];
        samples = new float[TransformAudio._samples.Length];
        for (int i = 0; i < TransformAudio._samples.Length; i++)
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
            Mesh _barMesh = new Mesh();
            _bar.GetComponent<MeshFilter>().mesh = _barMesh;
            _bar.GetComponent<MeshRenderer>().material = _barMaterial;
            CreateMesh(_barMesh, 0, 0, 0, 0);
            _bar.transform.position = this.transform.position;
            _bar.transform.parent = this.transform;
            _bar.name = "Bar" + i;
            this.transform.position = new Vector3(i * _barScale * -1, 0, 0);
            _bar.transform.position = new Vector3(9.9f, -4.5f, 0);
            _bars[i] = _bar;
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
            if (_sampleCount > 5)
            {
                _sampleCount = -5;
            }
            if (_waveHeight <= 0)
            {
                _waveHeight = TransformAudio._samples[samples.Length / 2 + _sampleCount];
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
            _sampleCount++;
            for (int j = samples.Length - 1; j >= 0; j--)
            {
                _bars[j].transform.localScale = new Vector3(_barScale, (samples[j] * _maxScale), _barScale);
            }
        }
        _updateCount++;
    }
}
