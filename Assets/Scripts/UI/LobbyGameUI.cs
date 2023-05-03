using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyGameUI : MonoBehaviour
{
    [SerializeField] GameObject CafePanel;
    [SerializeField] TextMeshPro _textTime;
    float _accTime;

    public void OnButtonOpenCafePanel()
    {
        CafePanel.SetActive(true);
    }

    public void CloseCafePanel()
    {
        CafePanel.SetActive(false); 
    }


   


}
