using UnityEngine;
using System.Collections;
using UnityEditor;

public class GoerVRTools : EditorWindow
{
    //Create MenuItem
    [MenuItem("GoerVR/Add GoerVR System Object", false, 10)]
    static void AddOvrvisionProCamera()
    {
        if (GameObject.Find("GoerVRSystem") == null)
        {
            Object obj = Instantiate(Resources.Load("Prefabs/GoerVRSystem"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            obj.name = "GoerVRSystem";

            //Force Virtual mode.
            PlayerSettings.apiCompatibilityLevel = ApiCompatibilityLevel.NET_2_0;
        }
        else
        {
            UnityEditor.EditorUtility.DisplayDialog("Error!", "追加失败！场景中存在GoerVRSystem", "OK");
        }
    }
}