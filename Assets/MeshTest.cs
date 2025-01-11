using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshTest : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[]
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

        triangles = new int[]
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
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
