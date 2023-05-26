using Doozy.Engine.Utils.ColorModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]Image home;
    [SerializeField]Image contact;
    [SerializeField]Image projects;
    [SerializeField]Image account;
    [SerializeField]Pages pages;


    public void Active()
    {
        
        home.color = Color.white;
        contact.color = Color.white;
        projects.color = Color.white;
        account.color = Color.white;

        pages.home.SetActive(false);
        pages.contact.SetActive(false);
        pages.projects.SetActive(false);
        pages.account.SetActive(false);

        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.yellow;
    }
}
