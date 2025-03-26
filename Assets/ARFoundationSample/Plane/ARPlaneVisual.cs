using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlaneVisual : MonoBehaviour
{
    public Mesh mesh { get; private set; }
    private ARPlane m_Plane;

    void Awake()
    {
        mesh = new Mesh();
        m_Plane = GetComponent<ARPlane>();
        m_Plane.boundaryChanged += OnBoundaryChanged;
    }
    void OnBoundaryChanged(ARPlaneBoundaryChangedEventArgs eventArgs)
    {
        var boundary = m_Plane.boundary;
        GenerateMesh(mesh, boundary);

        var lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = boundary.Length;
            for (int i = 0; i < boundary.Length; ++i)
            {
                var point2 = boundary[i];
                lineRenderer.SetPosition(i, new Vector3(point2.x, 0, point2.y));
            }
        }

        var meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
            meshFilter.mesh = mesh;

        var meshCollider = GetComponent<MeshCollider>();
        if (meshCollider != null)
            meshCollider.sharedMesh = mesh;
    }

    private void GenerateMesh(Mesh mesh, NativeArray<Vector2> planeVertices)
    {
        mesh.Clear();
        Vector3[] vertices = new Vector3[planeVertices.Length];
        for (int i = 0; i < planeVertices.Length; i++)
        {
            vertices[i] = new Vector3(planeVertices[i].x, 0, planeVertices[i].y);
        }

        mesh.vertices = vertices;
        var indices = GetIndices(vertices);
        mesh.SetIndices(indices,MeshTopology.Triangles, 0);
        mesh.RecalculateBounds();
    }

    private int[] GetIndices(Vector3[] vertices)
    {
        int[] triangles = new int[(vertices.Length - 2) * 3];
        for (int i = 0; i < vertices.Length - 2; i++) {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        return triangles;
    }

}
