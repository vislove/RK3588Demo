using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtileFPS : MonoBehaviour
{
    private int frame = 0;
    private float time = 0;
    private float fps = 0;
    
    private Color green = new Color(0.1f, 1, 0.1f);
    private Color red = new Color(1f, 0.1f, 0.1f);
    private Color wait = new Color(0.7f, 0.3f, 0.3f);
    private Color yellow = Color.yellow;

    private void Update()
    {
        frame += 1;
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            fps = frame / time;
            frame = 0;
            time = 0;
        }
    }
    private void OnGUI()
    {
        var scale = Screen.width / 800f;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(scale, scale, 1));
        GUILayout.BeginHorizontal();
        if(fps <= 20)
            GUI.color = red;
        else if(fps > 20 && fps <= 30)
            GUI.color = yellow;
        else
            GUI.color = green;
        GUILayout.Label($"FPS: {fps:F2}", GUILayout.Width(80));
        GUI.color = Color.green;
        GUILayout.Label($" 面数:{tris}", GUILayout.Width(200));
        GUILayout.EndHorizontal();
    }
    
    /// <summary>
    /// 获取模型面数
    /// </summary>
    static int tris = 0; // 面数
    static int verts = 0; // 顶点数
    public static void GetModelTris(GameObject go)
    {
        if (null == go)
        {
            verts = 0;
            tris = 0;
            return;
        }

        MeshFilter[] meshFilters = go.GetComponentsInChildren<MeshFilter>();
        foreach (var variable in meshFilters)
        {
            //verts += variable.sharedMesh.vertexCount;
            tris += variable.sharedMesh.triangles.Length / 3;
        }
    }
}
