using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.EventSystems.EventTrigger;

public static class OldMeshGenerator
{
    /*public static void GenerateVertices(KineSkeleton kl, Mesh mesh)
    {

        // Each segment adds 4 new vertices, and we need an extra 4 for the base.
        Vector3[] v = new Vector3[kl.Segments.Length * 4 + 4];

        Vector3 a = new Vector3(1, 0, 1);
        Vector3 b = new Vector3(-1, 0, 1);

        // Base vertices
        v[0] = -a * kl.Width;
        v[1] = -b * kl.Width;
        v[2] = b * kl.Width;
        v[3] = a * kl.Width;

        Vector3 jointPos = new Vector3(0,0,0);
        float len;
        Quaternion rot = Quaternion.identity; // Cascaded rotation
        Vector3 offsetA;
        Vector3 offsetB;
        
        for (int i = 0; i < kl.Segments.Length; i++)
        {
            len = kl.Segments[i].Length;
            rot *= kl.Segments[i].Rotation;
            offsetA = rot * a * kl.Width;
            offsetB = rot * b * kl.Width;
            jointPos += rot * Vector3.up * len;
            v[4 + i * 4] = jointPos - offsetA;
            v[5 + i * 4] = jointPos - offsetB;
            v[6 + i * 4] = jointPos + offsetB;
            v[7 + i * 4] = jointPos + offsetA;
        }

        mesh.vertices = v;


        // Colliders
        *//*BoxCollider bc = GetComponent<BoxCollider>();
        bc.size = new Vector3(Width * 2, LinkLength, Width * 2);
        bc.center = new Vector3(0, LinkLength / 2f, 0);*//*
    }

    // Should be called whenever the number of segments changes.
    // Fully regenerates all vertices and triangles.
    public static void GenerateTriangles(KineSkeleton kl, Mesh mesh)
    {
        GenerateVertices(kl, mesh);

        // Each segment adds 8 triangles, and the top and bottom faces have 4.
        int[] t = new int[(kl.Segments.Length*8 + 4) * 3];
        int ti;
        int vi;

        // Bottom face 012 321
        t[0] = 0; t[1] = 1; t[2] = 2;
        t[3] = 3; t[4] = 2; t[5] = 1;

        for (int i = 0; i < kl.Segments.Length; i++)
        {
            ti =  i * 24 + 6; // Number of indices in the list so far
            vi = i * 4; // First vertex index 
            t[ti   ] = vi  ; t[ti+ 1] = vi+4; t[ti+ 2] = vi+1;
            t[ti+ 3] = vi+4; t[ti+ 4] = vi+5; t[ti+ 5] = vi+1;

            t[ti+ 6] = vi+1; t[ti+ 7] = vi+5; t[ti+ 8] = vi+3;
            t[ti+ 9] = vi+5; t[ti+10] = vi+7; t[ti+11] = vi+3;

            t[ti+12] = vi+2; t[ti+13] = vi+6; t[ti+14] = vi  ;
            t[ti+15] = vi+6; t[ti+16] = vi+4; t[ti+17] = vi  ;

            t[ti+18] = vi+3; t[ti+19] = vi+7; t[ti+20] = vi+2;
            t[ti+21] = vi+7; t[ti+22] = vi+6; t[ti+23] = vi+2;
        }

        // Top face 210 123
        ti = kl.Segments.Length * 24 + 6;
        vi = kl.Segments.Length * 4; // Total number of triangles at this point is Length*8+2.
        t[ti  ] = vi+2; t[ti+1] = vi+1; t[ti+2] = vi  ;
        t[ti+3] = vi+1; t[ti+4] = vi+2; t[ti+5] = vi+3;

        string s = "";
        foreach(var g in mesh.triangles)
        {
            s += g + ", ";
        }
        Debug.Log(s);
        mesh.triangles = t;
        
    }*/

}
