using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //To reference a Audio Mixer we need to use the Unity Engine Audio System

public class SettingsMenu : MonoBehaviour {

public AudioMixer audioMixer;

public void SetVolume (float volume)
{
audioMixer.SetFloat("Volume", volume);
}

}