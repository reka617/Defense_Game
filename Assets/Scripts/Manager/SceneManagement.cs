using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Lobby");

    }
    public void OnButtonGotoCharacterScene()
    {
        SceneManager.LoadScene("Character");
    }

    public void OnButtonGotoShopScene()
    {
        SceneManager.LoadScene("Shop");
    }

    public void GotoStageScene()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void GotoStageSelectScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void GotoLobbyScene()
    {
        SceneManager.LoadScene("Lobby");
    }

    
}
