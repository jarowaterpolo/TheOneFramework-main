using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer MasterVolume;
    public TMP_Text PercentText;
    public string AudioParameter;
    public void SetVolume(float SliderValue)
    {
        MasterVolume.SetFloat(AudioParameter, Mathf.Log10(SliderValue) * 20);
        PercentText.text = Mathf.Round(SliderValue * 100) + "%";
    }
}
