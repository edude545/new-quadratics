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
    public KineSegment Parent;
    public float Length = 1;
    public float Width = 0.2f;

    // A KineSegment's mesh is a tetrahedron with a base radius equal to Width and height equal to Length.
    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();
        float x = -Mathf.Sin(Mathf.PI/6) * Width;
        float z = Mathf.Cos(Mathf.PI / 6) * Width;
        mesh.vertices = new Vector3[4] {
            new Vector3(0,Length*7/8,0),
            new Vector3(Width,Length/8,0),
            new Vector3(x,Length/8,-z),
            new Vector3(x,Length/8,z)
        };
        mesh.triangles = new int[12] { 0, 1, 2, 0, 2, 3, 0, 3, 1, 3, 2, 1 };
        GetComponent<MeshFilter>().sharedMesh = mesh;
        Transform t = transform.parent;
        while (t.parent != null)
        {
            t = t.parent;
        }
        GetComponent<MeshRenderer>().material = t.gameObject.GetComponent<KineSkeleton>().Material;
    }

    [CustomEditor(typeof(KineSegment))]
    public class KineSegmentEditor : Editor
    {
        KineSegment kl;
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            base.OnInspectorGUI();
            if (EditorGUI.EndChangeCheck()) { kl.GenerateMesh(); }

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
