using UnityEngine;

public class InkManager : MonoBehaviour
{
    public InkManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Ink Manager exists in the current scene");
        }
        instance = this;
    }

    // TODO: Add more jsons for each virus convo for patients

    public TextAsset[] canteenLadyQuestInks;

    private TextAsset[] maleRandomInks;
    private TextAsset[] femaleRandomInks;

    public TextAsset[] virusInks;   // * 0 = Typhoid
                                    // * 1 = Tuberculosis
                                    // * and so on..


    public TextAsset getRandomInk(bool isMale)
    {
        TextAsset output;
        if (isMale) output = getMaleInk();
        else output = getFemaleInk();

        return output;
    }

    private TextAsset getMaleInk()
    {
        return maleRandomInks[Random.Range(0, maleRandomInks.Length)];
    }

    private TextAsset getFemaleInk()
    {
        return femaleRandomInks[Random.Range(0, femaleRandomInks.Length)];
    }

    public TextAsset getVirusDialogue()
    {
        TextAsset output = null;

        List<TextAsset> listOfActiveViruses = new List<TextAsset>();

        if (GameWorldStatsManager.instance.tyhpoidIsActive)
        {
            listOfActiveViruses.Add(virusInks[0]);
        }

        if (GameWorldStatsManager.instance.tuberculosisIsActive)
        {
            listOfActiveViruses.Add(virusInks[1]);
        }

        // ! add the other viruses

        return listOfActiveViruses[Random.Range(0, listOfActiveViruses.Length)];
    }
}