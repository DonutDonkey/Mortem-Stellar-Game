using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private Dropdown   resolutionDropdown;

    [SerializeField] private AudioMixer audioMixer;

    private Resolution[] resolutions;

    void Start() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach(Resolution i in resolutions) {
            string option = i.width + "x" + i.height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
    }

    public void SetResolution(int index) {
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, true);
        Debug.Log(resolutions[index].width + "x" + resolutions[index].height);
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }

}
