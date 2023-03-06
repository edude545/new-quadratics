using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class KinematicLimb : MonoBehaviour
{
    public Material Material;

    public Segment[] Segments;

    [System.Serializable]
    public struct Segment
    {
        public Vector3 EndPos;
        public Quaternion Rotation;
        public float Length;
    }

    public float Width;

    private void OnValidate()
    {
        GenerateVertices();
    }

    // Should be called when a segment's properties have changed, but the number of segments have not.
    // Moves verties without regenerating triangles.
    public void GenerateVertices()
    {

    }

    // Should be called whenever the number of segments changes.
    // Fully regenerates all vertices and triangles.
    public void GenerateTriangles()
    {

    }

    public void GenerateMesh()
    {
        if (GetComponent<MeshFilter>().sharedMesh == null)
        {
            GetComponent<MeshFilter>().sharedMesh = new Mesh();
        } 
        GenerateVertices();
        GenerateTriangles();
    }

    [CustomEditor(typeof(KinematicLimb))]
    public class KinematicLinkEditor : Editor
    {
        KinematicLimb kl;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Fully Regenerate Mesh"))
            {
                kl.GenerateMesh();
            }
        }
        public void OnEnable()
        {
            kl = (KinematicLimb) target;
        }
    }

}
