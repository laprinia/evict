using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {
    private static GUIManager _instance;
    public static GUIManager instance {
        get {
            if(_instance == null) {
                GameObject go = new GameObject("GUIManager");
                go.AddComponent<GUIManager>();
            }
            return _instance;
        }
    }

    public Texture crosshair;

    private void Awake() {
        _instance = this;
    }

    private void OnGUI() {
        float x = (Screen.width - crosshair.width) / 2;
        float y = (Screen.height - crosshair.height) / 2;
        GUI.DrawTexture(new Rect(x, y, crosshair.width, crosshair.height), crosshair);
    }
}
