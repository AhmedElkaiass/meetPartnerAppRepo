using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{

    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField password;

    [SerializeField] TMP_Text error;
    [SerializeField] Pages pages;
    public bool offline = true;
    public void DoLogin()
    {

        if (email.text == ""|| password.text == "")
        {
            error.text = "please  fill the empty fields";
        }
        else{
            StartCoroutine(Upload());
        }
        
    }
    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        LoginData data = new LoginData();

        data.email = email.text;
        data.password = password.text;

        using (UnityWebRequest www = UnityWebRequest.Post("http://partner007-001-site1.ftempurl.com/api/Account/Login", JsonUtility.ToJson(data)))
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
                pages.register.SetActive(false);
                pages.login.SetActive(true);
            }
        }
    }
}

