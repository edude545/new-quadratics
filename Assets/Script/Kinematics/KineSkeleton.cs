using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.EventSystems.EventTrigger;

public class KineSkeleton : MonoBehaviour
{
    public Material Material;
    public SegPlan[] Segments;

    [System.Serializable]
    public struct SegPlan
    {
        public string Name;
        public float Length;
        public float Width;
        public SegPlan[] Segments;
    }

    // Recursively generate GameObjects
    public void GenerateSegments(SegPlan[] segs, GameObject root)
    {
        GameObject obj;
        KineSegment ks;
        int ci;
        bool found;
        if (segs.Length >= 0)
        {
            for (int i = 0; i < segs.Length; i++)
            {
                found = false;
                for (ci = 0; ci < root.transform.childCount; ci++) {
                    if (root.transform.GetChild(ci).name == segs[i].Name) {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    ks = root.transform.GetChild(ci).GetComponent<KineSegment>();
                    ks.Length = segs[i].Length;
                    ks.Width = segs[i].Width;
                    ks.GenerateVertices();
                } else {
                    obj = new GameObject();
                    obj.name = segs[i].Name;
                    obj.transform.parent = transform;
                    ks = obj.AddComponent<KineSegment>();
                    ks.GenerateMesh();
                }
                ks.GetComponent<MeshRenderer>().material = Material;
                //GenerateSegments(segs[i].Segments, obj);
            }
        }
    }

    [CustomEditor(typeof(KineSkeleton))]
    public class KineSkeletonEditor : Editor
    {
        KineSkeleton kl;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Generate Skeleton"))
            {
                kl.GenerateSegments(kl.Segments, kl.gameObject);
            }
        }
        public void OnEnable()
        {
            kl = (KineSkeleton) target;
        }
    }

}
