using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 瑞芯微RK3588 性能测试
/// </summary>
public class GameFace : MonoBehaviour
{
    public GameObject prefab;
    public GameObject animModel;

    private int offset = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        UtileFPS.GetModelTris(animModel);
    }

    private void OnGUI()
    {
        var scale = Screen.width / 1000f;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(scale, scale, 1));
        GUILayout.BeginHorizontal();
        if (GUI.Button(new Rect(0, offset, 150, 100),"清空"))
        {
            Clear();
        }
        
        if (GUI.Button(new Rect(0, offset + 100, 150, 100),"同屏增加2万面"))
        {
            AddGameObject(1667);
        }
        if (GUI.Button(new Rect(0, offset + 200, 150, 100),"同屏增加4万面"))
        {
            AddGameObject(3334);
        }
        if (GUI.Button(new Rect(0, offset + 300, 150, 100),"同屏增加6万面"))
        {
            AddGameObject(5001);
        }
        if (GUI.Button(new Rect(150, offset, 150, 100),"同屏增加8万面"))
        {
            AddGameObject(6668);
        }
        if (GUI.Button(new Rect(150, offset + 100, 150, 100),"同屏增加10万面"))
        {
            AddGameObject(8335);
        }
        if (GUI.Button(new Rect(150, offset + 200, 150, 100),"同屏增加14万面"))
        {
            AddGameObject(11669);
        }
        if (GUI.Button(new Rect(150, offset + 300, 150, 100),"同屏增加20万面"))
        {
            AddGameObject(16670);
        }
        GUILayout.EndHorizontal();
    }

    private void AddGameObject(int count)
    {
        Clear();
        
        // int width = count + 1;
        // int height = count + 1;
        //
        // List<Vector3Int> list = new List<Vector3Int>();
        // for (var y = 0; y < height; y++)
        // {
        //     for (var x = 0; x < width; x++)
        //     {
        //         list.Add(new Vector3Int(x, 0, y));
        //     }
        // }

        while (count > 0)
        {
            // var index = Random.Range(0, list.Count);
            // var pos = list[index];
            GameObject go = Instantiate(prefab,transform);
            go.transform.position = Vector3.zero;
            UtileFPS.GetModelTris(go); 
            //list.RemoveAt(index);
            count--;
        }
    }

    private void Clear()
    {
        int count = transform.childCount - 1;

        while (count >= 0)
        {
            DestroyImmediate(transform.GetChild(count).gameObject);
            count--;
        }
        UtileFPS.GetModelTris(null); 
        UtileFPS.GetModelTris(animModel); 
    }
}
