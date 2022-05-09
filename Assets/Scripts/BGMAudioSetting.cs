using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMAudioSetting : MonoBehaviour
{
    [SerializeField] Slider bgmSlider;
    [SerializeField] AudioSource bgmAudio;
    private float bgmVolume = 1.0f;

    private void Start() {
        GetBgmVolumeGet();
    }

    // private void Update() {
    //     BgmVolumeSetting();    
    // }

    public void BgmVolumeSetting(){
        bgmAudio.volume = bgmSlider.value;
        bgmVolume = bgmSlider.value;
        PlayerPrefs.SetFloat("bgmvolume", bgmVolume);
    }

    public void GetBgmVolumeGet(){
        bgmVolume = PlayerPrefs.GetFloat("bgmvolume", 1.0f);
        bgmSlider.value = bgmVolume;
        bgmAudio.volume = bgmSlider.value;
    }
}
