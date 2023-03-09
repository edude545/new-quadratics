using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class KineSegment : MonoBehaviour
{
    public float Length = 1;
    public float Width = 0.2f;

    private void OnValidate()
    {
        GenerateVertices();
    }

    // A KineSegment's mesh is a tetrahedron with a base radius equal to Width and height equal to Length.
    // Called every frame. Moves verties without regenerating triangles.
    public void GenerateVertices()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        if (mesh == null)
        {
            Debug.Log("PROBLEM!!!");
        }
        float x = -Mathf.Sin(Mathf.PI/6) * Width;
        float z = Mathf.Cos(Mathf.PI / 6) * Width;
        mesh.vertices = new Vector3[4] {
            new Vector3(0,Length,0),
            new Vector3(Width,0,0),
            new Vector3(x,Length/8,-z),
            new Vector3(x,Length/8,z)
        };
    }

    // Generates mesh's triangles. Should only be called when the mesh is initialized.
    public void GenerateMesh()
    {
        if (GetComponent<MeshFilter>().sharedMesh == null)
        {
            GetComponent<MeshFilter>().sharedMesh = new Mesh();
        }
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        GenerateVertices();
        mesh.triangles = new int[12] { 0,1,2, 0,2,3, 0,3,1, 3,2,1 };
    }

    [CustomEditor(typeof(KineSegment))]
    public class KineSegmentEditor : Editor
    {
        KineSegment kl;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Regenerate Mesh"))
            {
                kl.GenerateMesh();
            }
        }
        public void OnEnable()
        {
            kl = (KineSegment) target;
        }
    }

}
