using System.IO;
using UnityEngine;
using UnityEditor;

public class Export : MonoBehaviour
{
    [MenuItem("Custom/Export Level")]
    static void ExportThing()
    {
        string path = Application.dataPath + "/Export.txt";
        File.WriteAllText(path, "");


        Debug.Log("hello world");
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Exported"))
        {
            File.AppendAllText(path, o.name 
                + "|" + o.transform.localPosition.x
                + "|" + o.transform.localPosition.y 
                + "|" + o.transform.localPosition.z
                + "|" + o.transform.localScale.x
                + "|" + o.transform.localScale.y
                + "|" + o.transform.localScale.z
                + "|" + o.transform.localRotation.x
                + "|" + o.transform.localRotation.y
                + "|" + o.transform.localRotation.z
                + "\n");
        }
    }
}
