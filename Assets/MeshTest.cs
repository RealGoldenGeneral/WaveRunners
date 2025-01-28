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
            // Vertices 1-23, Inital cube
            //new Vector3 (1, 0, 1), // 0
            //new Vector3 (0, 0, 1), // 1
            //new Vector3 (1, 0.8f, 1), // 2
            //new Vector3 (0, 0.8f, 1), // 3
            //new Vector3 (1, 0.8f, 0), // 4
            //new Vector3 (0, 0.8f, 0), // 5
            //new Vector3 (1, 0, 0), // 6
            //new Vector3 (0, 0, 0), // 7
            //new Vector3 (1, 0.8f, 1), // 8
            //new Vector3 (0, 0.8f, 1), // 9
            //new Vector3 (1, 0.8f, 0), // 10
            //new Vector3 (0, 0.8f, 0), // 11
            //new Vector3 (1, 0, 0), // 12
            //new Vector3 (1, 0, 1), // 13
            //new Vector3 (0, 0, 1), // 14
            //new Vector3 (0, 0, 0), // 15
            //new Vector3 (0, 0, 1), // 16
            //new Vector3 (0, 0.8f, 1), // 17
            //new Vector3 (0, 0.8f, 0), // 18
            //new Vector3 (0, 0, 0), // 19
            //new Vector3 (1, 0, 0), // 20
            //new Vector3 (1, 0.8f, 0), // 21
            //new Vector3 (1, 0.8f, 1), // 22
            //new Vector3 (1, 0, 1), // 23

            // Vertices 0-13, upwards slope
            new Vector3 (1, 0, 1), // 0
            new Vector3 (1, 1, 1), // 1
            new Vector3 (0, 0, 1), // 2
            new Vector3 (1, 1, 0), // 3
            new Vector3 (1, 0, 0), // 4
            new Vector3 (0, 0, 0), // 5
            new Vector3 (1, 0, 0), // 6
            new Vector3 (1, 1, 0), // 7
            new Vector3 (1, 1, 1), // 8
            new Vector3 (1, 0, 1), // 9
            new Vector3 (1, 1, 0), // 10
            new Vector3 (0, 0, 0), // 11
            new Vector3 (1, 1, 1), // 12
            new Vector3 (0, 0, 1), // 13
        };

        triangles = new int[]
        {
            // Initial Cube
            //0, 2, 3,
            //0, 3, 1,
            //8, 4, 5,
            //8, 5, 9,
            //10, 6, 7,
            //10, 7, 11,
            //12, 13, 14,
            //12, 14, 15,
            //16, 17, 18,
            //16, 18, 19,
            //20, 21, 22,
            //20, 22, 23,

            // Upwards Slope
            0, 1, 2,
            3, 4, 5,
            6, 7, 8,
            6, 8, 9,
            12, 10, 11,
            12, 11, 13
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
