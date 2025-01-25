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
            new Vector3 (1, 0, 1),
            new Vector3 (0, 0, 1),
            new Vector3 (1, 1, 1),
            new Vector3 (0, 1, 1),
            new Vector3 (1, 1, 0),
            new Vector3 (0, 1, 0),
            new Vector3 (1, 0, 0),
            new Vector3 (0, 0, 0),
            new Vector3 (1, 1, 1),
            new Vector3 (0, 1, 1),
            new Vector3 (1, 1, 0),
            new Vector3 (0, 1, 0),
            new Vector3 (1, 0, 0),
            new Vector3 (1, 0, 1),
            new Vector3 (0, 0, 1),
            new Vector3 (0, 0, 0),
            new Vector3 (0, 0, 1),
            new Vector3 (0, 1, 1),
            new Vector3 (0, 1, 0),
            new Vector3 (0, 0, 0),
            new Vector3 (1, 0, 0),
            new Vector3 (1, 1, 0),
            new Vector3 (1, 1, 1),
            new Vector3 (1, 0, 1),
        };

        triangles = new int[]
        {
            0, 2, 3,
            0, 3, 1,
            8, 4, 5,
            8, 5, 9,
            10, 6, 7,
            10, 7, 11,
            12, 13, 14,
            12, 14, 15,
            16, 17, 18,
            16, 18, 19,
            20, 21, 22,
            20, 22, 23
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
