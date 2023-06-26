using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Text;
using System.Net;

public class Register : MonoBehaviour
{
    [SerializeField] TMP_InputField firstName;
    [SerializeField] TMP_InputField lastName;
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField password;
    [SerializeField] TMP_InputField confirmPassword;
    [SerializeField] TMP_Text error;
    [SerializeField] Pages pages;
    public bool offline = true;
    public void RegisterUser()
    {
        if (!offline)
        {
            if (password.text == confirmPassword.text)
            {
                StartCoroutine(Upload());
                error.text = "";
            }
            else error.text = "Passwords do NOT match";
        }
        else
        {
            pages.register.SetActive(false);
            pages.login.SetActive(true);
        }
    }
    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        UserRegisterData data = new UserRegisterData();

        data.email = email.text;
        data.fullName = firstName.text + " " + lastName.text;
        data.password = password.text;
        data.confirmPassord = confirmPassword.text;
        data.regionId = 1;
        using (UnityWebRequest www = UnityWebRequest.Post("http://partner007-001-site1.ftempurl.com/api/Account/Register", JsonUtility.ToJson(data)))
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

public class UserRegisterData
{
    public string fullName;
    public string email;
    public string password;
    public string confirmPassord;
    public System.Int32 regionId;
}
