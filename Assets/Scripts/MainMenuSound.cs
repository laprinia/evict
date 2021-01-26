using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSound : MonoBehaviour
{
    public Slider slider;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void ChangeVolume() {
        audioSource.volume = slider.value;
    }
}
