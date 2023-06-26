using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class UploadProjects : MonoBehaviour
{
    [SerializeField] TMP_InputField tittle;
    [SerializeField] TMP_InputField description;
    [SerializeField] TMP_InputField expectedCost;
    [SerializeField] TMP_InputField expectedProfitRatio;
    [SerializeField] TMP_InputField tags;
    [SerializeField] TMP_Text error;
    [SerializeField] Pages pages;
    public bool offline = true;
  
    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        Projects data = new Projects();

        data.tittle = tittle.text;
        data.description = description.text;
        data.expectedCost = expectedCost.text;
        data.expectedProfitRatio = expectedProfitRatio.text;
        data.tag = tags.text;

        using (UnityWebRequest www = UnityWebRequest.Post("URL", JsonUtility.ToJson(data)))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();
            Debug.Log(www.result);
            if (www.responseCode != 200)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}

