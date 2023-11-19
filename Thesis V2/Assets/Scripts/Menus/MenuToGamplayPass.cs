using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToGamplayPass : MonoBehaviour
{
    public static MenuToGamplayPass instance;

    private void Awake() {
        if (instance != null){
            Destroy(instance);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() {
        Cursor.visible = true;
    }

    public bool startNewGame;
    public void createNewGame(bool shouldWeStartNewGame){
        startNewGame = shouldWeStartNewGame;
    }

    public void exit(){
        Application.Quit();
    }
}
