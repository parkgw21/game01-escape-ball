using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSFXManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxAudio;
    [SerializeField] AudioClip[] sfxClips;
    private float sfxVolume = 1.0f;

    private void Start() {
        GetSfxVolumeGet();
    }

    void GetSfxVolumeGet(){
        sfxVolume = PlayerPrefs.GetFloat("sfxvolume", 1.0f);
        sfxAudio.volume = sfxVolume;
    }

    public void PlaySFX(string clipToPlay){
        for (int i = 0; i < sfxClips.Length; i++)
        {
            if(clipToPlay == sfxClips[i].ToString().Substring(0, clipToPlay.Length)){
                sfxAudio.clip = sfxClips[i];
            }
        }
        sfxAudio.Play();
    }
}
