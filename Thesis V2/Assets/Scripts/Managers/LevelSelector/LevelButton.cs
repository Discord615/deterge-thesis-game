[System.Serializable]
public class LevelButton
{
    public LevelButton(int sceneId, bool isAvailable){
        this.sceneId = sceneId;
        this.isAvailable = isAvailable;
    }

    public int sceneId;
    public bool isAvailable = false;
    public void goToScene(){
        // ! Implement
        // ! Call loadscene in loadSceneManager passing the sceneID
    }
}