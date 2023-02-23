using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LoginGameUI : MonoBehaviour
{
    [SerializeField] GameObject RegistPanel;
    public void OnClickedRegistButton()
    {
        RegistPanel.gameObject.SetActive(true);
    }

    public void OnClickedLoginButton()
    {
        //���������� ������
        SceneManager.LoadScene("Lobby");
    }

    public void OnclickedCheckButton()
    {
        RegistPanel.gameObject.SetActive(false);
    }
}
