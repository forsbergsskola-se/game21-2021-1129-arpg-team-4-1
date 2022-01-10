using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //To reference a Audio Mixer we need to use the Unity Engine Audio System
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

public AudioMixer audioMixer;

public Dropdown resolutionDropdown;

Resolution[] resolutions;

void Start ()
{
resolutions = Screen.resolutions;
resolutionDropdown.ClearOptions();

List <strings> options = new List <string>();

for (int i = 0; i < resolutions.Length; i++)
{
string option = resolutions[i].width + " x " + resolutions[i].height;
options.Add(option);
}

resolutionDropdown.AddOptions(options);
}

public void SetVolume (float volume)
{
audioMixer.SetFloat("Volume", volume);
}

public void SetQuality (int qualityIndex)
{
QualitySettings.SetQualityLevel(qualityIndex);
}

}