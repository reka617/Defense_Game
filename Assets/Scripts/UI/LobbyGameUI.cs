using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyGameUI : MonoBehaviour
{
    
    public void OnButtonGotoCafeScene()
    {
        SceneManager.LoadScene("Cafe");
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
