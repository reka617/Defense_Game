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
        //���������� ������
        SceneManager.LoadScene("Lobby");
    }

    void OnclickedCheckButton()
    {
        RegistPanel.gameObject.SetActive(false);
    }
}
