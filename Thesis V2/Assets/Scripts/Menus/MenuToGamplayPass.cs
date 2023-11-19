using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToGamplayPass : MonoBehaviour
{
    public static MenuToGamplayPass instance;

    private void Awake() {
        if (instance != null){
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public bool startNewGame;
    public void createNewGame(bool shouldWeStartNewGame){
        startNewGame = shouldWeStartNewGame;
    }

    public void exit(){
        Application.Quit();
    }
}
