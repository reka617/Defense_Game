using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyGameUI : MonoBehaviour
{
    [SerializeField] GameObject CafePanel;

    public void Update()
    {
        CloseCafePanel();
    }
    public void OnButtonOpenCafePanel()
    {
        CafePanel.SetActive(true);
    }

    public void CloseCafePanel()
    {
        
    }


}
