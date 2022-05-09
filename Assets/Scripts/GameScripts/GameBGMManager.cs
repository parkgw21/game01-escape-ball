using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBGMManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudio;
    [SerializeField] AudioClip[] bgmClips;
    private float bgmVolume = 1.0f;

    private void Start() {
        GetBgmVolumeGet();
    }

    void GetBgmVolumeGet(){
        bgmVolume = PlayerPrefs.GetFloat("bgmvolume", 1.0f);
        bgmAudio.volume = bgmVolume;
    }

    public void PlayBGM(string clipToPlay){
        for (int i = 0; i < bgmClips.Length; i++)
        {
            if(clipToPlay == bgmClips[i].ToString().Substring(0, clipToPlay.Length)){
                bgmAudio.clip = bgmClips[i];
            }
        }
        bgmAudio.Play();
    }
}
