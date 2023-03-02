using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyGameUI : MonoBehaviour
{
    [SerializeField] GameObject CafePanel;
    
    public void OnButtonOpenCafePanel()
    {
        CafePanel.SetActive(true);
    }

    public void OnButtonCloseCafePanel()
    {
        CafePanel.SetActive(false);
    }
    public void OnButtonGotoCharacterScene()
    {
        SceneManager.LoadScene("Character");
    }

    public void OnButtonGotoShopScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void OnButtonNextStage()
    {

    }


    void Update()
    {
        
    }
}
