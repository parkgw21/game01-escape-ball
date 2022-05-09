using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleUIController : MonoBehaviour
{
    [SerializeField] GameObject stageSelect;
    [SerializeField] GameObject settings;
    [SerializeField] SFXAudioSetting sfxSetting;

    void Start()
    {
        stageSelect.SetActive(false);    
        settings.SetActive(false);
    }

    public void ToggleStageSelect(){
        sfxSetting.PlaySFX();
        if(stageSelect.activeInHierarchy == false){
            stageSelect.SetActive(true);
        }else{
            stageSelect.SetActive(false);
        }
    }

    public void LoadGame(){
        sfxSetting.PlaySFX();
        string btnName = EventSystem.current.currentSelectedGameObject.name;
        StartCoroutine(LoadAsyncScene(btnName));
    }

    IEnumerator LoadAsyncScene(string sceneName){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while(!asyncLoad.isDone){
            yield return null;
        }
    }
    public void ToggleSettings(){
        sfxSetting.PlaySFX();
        if(settings.activeInHierarchy == false){
            settings.SetActive(true);
        }else{
            settings.SetActive(false);
        }
    }
}
