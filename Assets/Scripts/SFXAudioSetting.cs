using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXAudioSetting : MonoBehaviour
{
    [SerializeField] Slider sfxSlider;
    [SerializeField] AudioSource sfxAudio;
    private float sfxVolume = 1.0f;
    private bool switchPlay = false;

    private void Start() {
        SfxBgmVolumeGet();
    }

    // private void Update() {
    //     SfxVolumeSetting();
    // }

    public void SfxVolumeSetting(){
        float beforeVolume = sfxVolume;
        sfxAudio.volume = sfxSlider.value;
        sfxVolume = sfxSlider.value;
        PlayerPrefs.SetFloat("sfxvolume", sfxVolume);

        if(switchPlay == true){
            sfxAudio.Play();
        }
        switchPlay = true;
    }

    public void SfxBgmVolumeGet(){
        sfxVolume = PlayerPrefs.GetFloat("sfxvolume", 1.0f);
        sfxSlider.value = sfxVolume;
        sfxAudio.volume = sfxSlider.value;
    }

    public void PlaySFX(){
        sfxAudio.Play();
    }
}
