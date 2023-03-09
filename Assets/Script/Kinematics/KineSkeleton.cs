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

    [CustomEditor(typeof(KineSkeleton))]
    public class KineSkeletonEditor : Editor
    {
        KineSkeleton kl;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
        public void OnEnable()
        {
            kl = (KineSkeleton) target;
        }
    }

}
