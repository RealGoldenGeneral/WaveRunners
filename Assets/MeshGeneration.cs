using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneration : MonoBehaviour
{
    // Bars before wave generation
    public static Mesh CreateBars(float y)
    {
        Mesh mesh = new Mesh();
        mesh.Clear();
        Vector3[] vertices = new Vector3[]
        {
            // Vertices 1-23, Inital cube
            new Vector3 (1, 0, 1), // 0
            new Vector3 (0, 0, 1), // 1
            new Vector3 (1, y, 1), // 2
            new Vector3 (0, y, 1), // 3
            new Vector3 (1, y, 0), // 4
            new Vector3 (0, y, 0), // 5
            new Vector3 (1, 0, 0), // 6
            new Vector3 (0, 0, 0), // 7
            new Vector3 (1, y, 1), // 8
            new Vector3 (0, y, 1), // 9
            new Vector3 (1, y, 0), // 10
            new Vector3 (0, y, 0), // 11
            new Vector3 (1, 0, 0), // 12
            new Vector3 (1, 0, 1), // 13
            new Vector3 (0, 0, 1), // 14
            new Vector3 (0, 0, 0), // 15
            new Vector3 (0, 0, 1), // 16
            new Vector3 (0, y, 1), // 17
            new Vector3 (0, y, 0), // 18
            new Vector3 (0, 0, 0), // 19
            new Vector3 (1, 0, 0), // 20
            new Vector3 (1, y, 0), // 21
            new Vector3 (1, y, 1), // 22
            new Vector3 (1, 0, 1), // 23
        };

        int[] triangles = new int[]
        {
            // Initial Cube
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
            20, 22, 23,
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        mesh.name = "Bar Mesh";

        return mesh;
    }

    // Upwards slope
    public static Mesh CreateUpwardsSlope(float y, float ymax)
    {
        Mesh mesh = new Mesh();
        mesh.Clear();
        Vector3[] vertices = new Vector3[]
        {
            // Vertices 1-23, Inital cube
            new Vector3 (1, 0, 1), // 0
            new Vector3 (0, 0, 1), // 1
            new Vector3 (1, y, 1), // 2
            new Vector3 (0, y, 1), // 3
            new Vector3 (1, y, 0), // 4
            new Vector3 (0, y, 0), // 5
            new Vector3 (1, 0, 0), // 6
            new Vector3 (0, 0, 0), // 7
            new Vector3 (1, y, 1), // 8
            new Vector3 (0, y, 1), // 9
            new Vector3 (1, y, 0), // 10
            new Vector3 (0, y, 0), // 11
            new Vector3 (1, 0, 0), // 12
            new Vector3 (1, 0, 1), // 13
            new Vector3 (0, 0, 1), // 14
            new Vector3 (0, 0, 0), // 15
            new Vector3 (0, 0, 1), // 16
            new Vector3 (0, y, 1), // 17
            new Vector3 (0, y, 0), // 18
            new Vector3 (0, 0, 0), // 19
            new Vector3 (1, 0, 0), // 20
            new Vector3 (1, y, 0), // 21
            new Vector3 (1, y, 1), // 22
            new Vector3 (1, 0, 1), // 23

            // Vertices 24-37, upwards slope
            new Vector3 (1, y, 1), // 24
            new Vector3 (1, ymax, 1), // 25
            new Vector3 (0, y, 1), // 26
            new Vector3 (1, ymax, 0), // 27
            new Vector3 (1, y, 0), // 28
            new Vector3 (0, y, 0), // 29
            new Vector3 (1, y, 0), // 30
            new Vector3 (1, ymax, 0), // 31
            new Vector3 (1, ymax, 1), // 32
            new Vector3 (1, y, 1), // 33
            new Vector3 (1, ymax, 0), // 34
            new Vector3 (0, y, 0), // 35
            new Vector3 (1, ymax, 1), // 36
            new Vector3 (0, y, 1), // 37
        };

        int[] triangles = new int[]
        {
            // Initial Cube
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
            20, 22, 23,

            // Upwards Slope
            24, 25, 26,
            27, 28, 29,
            30, 31, 32,
            30, 32, 33,
            36, 34, 35,
            36, 35, 37
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        mesh.name = "Upwards Mesh";

        return mesh;
    }


    // Downwards Slope
    public static Mesh CreateDownwardsSlope(float y, float ymax)
    {
        Mesh mesh = new Mesh();
        mesh.Clear();
        Vector3[] vertices = new Vector3[]
        {

            // Vertices 1-23, Inital cube
            new Vector3 (1, 0, 1), // 0
            new Vector3 (0, 0, 1), // 1
            new Vector3 (1, y, 1), // 2
            new Vector3 (0, y, 1), // 3
            new Vector3 (1, y, 0), // 4
            new Vector3 (0, y, 0), // 5
            new Vector3 (1, 0, 0), // 6
            new Vector3 (0, 0, 0), // 7
            new Vector3 (1, y, 1), // 8
            new Vector3 (0, y, 1), // 9
            new Vector3 (1, y, 0), // 10
            new Vector3 (0, y, 0), // 11
            new Vector3 (1, 0, 0), // 12
            new Vector3 (1, 0, 1), // 13
            new Vector3 (0, 0, 1), // 14
            new Vector3 (0, 0, 0), // 15
            new Vector3 (0, 0, 1), // 16
            new Vector3 (0, y, 1), // 17
            new Vector3 (0, y, 0), // 18
            new Vector3 (0, 0, 0), // 19
            new Vector3 (1, 0, 0), // 20
            new Vector3 (1, y, 0), // 21
            new Vector3 (1, y, 1), // 22
            new Vector3 (1, 0, 1), // 23

            // Vertices 24-37, downwards slope
            new Vector3 (0, y, 1), // 24
            new Vector3 (0, ymax, 1), // 25
            new Vector3 (1, y, 1), // 26
            new Vector3 (0, ymax, 0), // 27
            new Vector3 (0, y, 0), // 28
            new Vector3 (1, y, 0), // 29
            new Vector3 (0, y, 0), // 30
            new Vector3 (0, ymax, 0), // 31
            new Vector3 (0, ymax, 1), // 32
            new Vector3 (0, y, 1), // 33
            new Vector3 (0, ymax, 0), // 34
            new Vector3 (1, y, 0), // 35
            new Vector3 (0, ymax, 1), // 36
            new Vector3 (1, y, 1), // 37
        };

        int[] triangles = new int[]
        {

            // Initial Cube
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
            20, 22, 23,

            // Downwards Slope
            24, 25, 26,
            27, 28, 29,
            30, 31, 32,
            30, 32, 33,
            36, 34, 35,
            36, 35, 37
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        mesh.name = "Downwards Mesh";

        return mesh;
    }
}
