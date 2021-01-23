using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        StartCoroutine(LoadAsyncScene());
        Debug.Log("new game");
    }
    public void ContinueGame()
    {
       
        Debug.Log("continue game");
    }
    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }
    
    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Ovidiu");
        

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

