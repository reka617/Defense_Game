using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LoginGameUI : MonoBehaviour
{
    [SerializeField] GameObject RegistPanel;
    void OnClickedRegistButton()
    {
        RegistPanel.gameObject.SetActive(true);
    }

    void OnClickedLoginButton()
    {
        //유저정보가 있을때
        SceneManager.LoadScene("Lobby");
    }

    void OnclickedCheckButton()
    {
        RegistPanel.gameObject.SetActive(false);
    }
}
