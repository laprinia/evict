using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject playerComponent;
    public static bool GameIsPaused = false;
    public GameObject saveMenuUI;
    public GameObject pauseMenuUI;
    public GameObject mainCamera;
    public GameObject createPortal;
    public GameObject fpsController;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        } 
    }

    public void Resume()
    {
        saveMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        mainCamera.GetComponent<GUIManager>().enabled = true;
        createPortal.GetComponent<CreatePortal>().enabled = true;
        fpsController.GetComponent<FPSController>().enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        mainCamera.GetComponent<GUIManager>().enabled = false;
        createPortal.GetComponent<CreatePortal>().enabled = false;
        fpsController.GetComponent<FPSController>().enabled = false;
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SaveGame()
    {
        Debug.Log(playerComponent.name);
        playerComponent.GetComponent<SavablePlayer>().SaveCharacter();
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayerData();
        playerComponent.GetComponent<SavablePlayer>().LoadCharacter(data);
    }
}
