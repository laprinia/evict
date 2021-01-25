using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMenu : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject createPortal;
    public GameObject fpsController;

    private void Start() {
        this.gameObject.GetComponentInParent<PauseMenu>().enabled = false;
        mainCamera.GetComponent<GUIManager>().enabled = false;
        createPortal.GetComponent<CreatePortal>().enabled = false;
        fpsController.GetComponent<FPSController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MainMenu() {
        Application.LoadLevel(0);
    }

    public void RestartLevel() {
        Application.LoadLevel(Application.loadedLevel);
    }
}
