using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject gameClearScereen;
    [SerializeField] GameObject gameOverScereen;
    [SerializeField] Image[] hearts;
    [SerializeField] GameObject levels;
    [SerializeField] GameObject player;
    [SerializeField] GameBGMManager gameBGMManager;
    [SerializeField] GameSFXManager gameSFXManager;

    private int heartNumber = 0;

    private void Start() {
        gameClearScereen.SetActive(false);
        gameOverScereen.SetActive(false);
    }   

    public void ActivateGameClearScreen(){
        gameClearScereen.SetActive(true);
        gameBGMManager.PlayBGM("ClearBGM");
        Destroy(levels);
        Destroy(player);
    }

    public void ActivateGameOverScreen(){
        gameOverScereen.SetActive(true);
        gameBGMManager.PlayBGM("GameoverBGM");
        Destroy(levels);
        Destroy(player);
    }

    public void LoadTitle(){
        gameSFXManager.PlaySFX("SFXClickButton");
        StartCoroutine(LoadAsyncScene("TitleScene"));
    }

    public void Replay(){
        gameSFXManager.PlaySFX("SFXClickButton");
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "GameSceneEasy"){
            StartCoroutine(LoadAsyncScene("GameSceneEasy"));
        }
        else if(scene.name == "GameSceneNormal"){
            StartCoroutine(LoadAsyncScene("GameSceneNormal"));
        }
        else if(scene.name == "GameSceneHard"){
            StartCoroutine(LoadAsyncScene("GameSceneHard"));
        }
    }

    public void LoadNextStage(){
        gameSFXManager.PlaySFX("SFXClickButton");
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "GameSceneEasy"){
            StartCoroutine(LoadAsyncScene("GameSceneNormal"));
        }
        else if(scene.name == "GameSceneNormal"){
            StartCoroutine(LoadAsyncScene("GameSceneHard"));
        }
    }

    IEnumerator LoadAsyncScene(string sceneName){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while(!asyncLoad.isDone){
            yield return null;
        }
    }
    
    public void breakHearts(){
        Destroy(hearts[heartNumber]);
        if(heartNumber < hearts.Length-1){
            heartNumber += 1;
        }else{
            ActivateGameOverScreen();
        }
    }
}
