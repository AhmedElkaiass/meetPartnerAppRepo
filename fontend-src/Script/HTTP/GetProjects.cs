using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class GetProjects : MonoBehaviour
{

    public static Data data;
    public static IEnumerator GetRequest(string uri, UnityAction playWhenDone)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                string jsonData = webRequest.downloadHandler.text;
                data = JsonUtility.FromJson<Data>("{\"projects\":" + jsonData + "}");
                Debug.Log(data.projects.Length);
                Debug.Log(jsonData);
                playWhenDone();
            }
        }
    }
}


[System.Serializable]
public class Data
{
    public Projects[] projects;

}

[System.Serializable]
public class Projects
{
    public int id;
    public string tittle;
    public string description;
    public string expectedCost;
    public string expectedProfitRatio;
    public string tag;
    public int userID;
}
