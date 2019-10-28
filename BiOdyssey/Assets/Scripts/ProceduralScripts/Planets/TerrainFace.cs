using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace {

    ShapeGenerator shapeGenerator;
    Mesh mesh;
    int resolution;
    Vector3 localUp;
    Vector3 axisA;
    Vector3 axisB;

    public TerrainFace(ShapeGenerator shapeGenerator, Mesh mesh, int resolution, Vector3 localUp) {
        this.shapeGenerator = shapeGenerator;
        this.mesh = mesh;
        this.localUp = localUp;
        this.resolution = resolution;

        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);
    }

    public void CreateMesh() {
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 2 * 3];
        Vector2[] uvHeight = (mesh.uv.Length == vertices.Length)? mesh.uv : new Vector2[vertices.Length];
        Vector2[] uvTex = (mesh.uv2.Length == vertices.Length) ? mesh.uv2 : new Vector2[vertices.Length];

        for (int vertIndex = 0, triIndex = 0, y = 0; y < resolution; y++) {
            for (int x = 0; x < resolution; x++) {
                Vector2 percent = new Vector2(x, y) / (resolution - 1);
                uvTex[vertIndex] = percent;

                //Una unidad en el eje y   Percent pasa de 0-1 a -1-1 y lo multiplicamos por la unidad del eje x y eje z
                Vector3 pointOnUnitCube = localUp + (percent.x - .5f) * 2 * axisA + (percent.y - .5f) * 2 * axisB;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                float unscaledElevation = shapeGenerator.CalculateUnscaledElevation(pointOnUnitSphere);
                vertices[vertIndex] = pointOnUnitSphere * shapeGenerator.GetScaledElevation(unscaledElevation);
                uvHeight[vertIndex].y = unscaledElevation;

                if (x != (resolution - 1) && y != (resolution - 1)) {
                    triangles[triIndex] = vertIndex;
                    triangles[triIndex + 1] = vertIndex + resolution + 1;
                    triangles[triIndex + 2] = vertIndex + resolution;

                    triangles[triIndex + 3] = vertIndex;
                    triangles[triIndex + 4] = vertIndex + 1;
                    triangles[triIndex + 5] = vertIndex + resolution + 1;

                    triIndex += 6;
                }

                vertIndex++;
            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.uv = uvHeight;
        mesh.uv2 = uvTex;
    }
}
