using UnityEngine;
using System.Collections.Generic;

public class InkManager : MonoBehaviour
{
    public static InkManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Ink Manager exists in the current scene");
        }
        instance = this;
    }

    // TODO: Add more inks for quest givers

    [Header("Quest Dialogues")]
    public TextAsset[] canteenLadyQuestInks;


    [Header("Gendered Ink Dialogues")]
    [SerializeField] private TextAsset[] maleRandomInks;
    [SerializeField] private TextAsset[] femaleRandomInks;


    [Header("Virus Ink Dialogue Files")]
    [SerializeField] private TextAsset[] TyphoidInks;
    [SerializeField] private TextAsset[] TuberCulosisInks;
    [SerializeField] private TextAsset[] DengueInks;
    [SerializeField] private TextAsset[] InfluenzaInks;
    [SerializeField] private TextAsset[] CoronaInks;
    [SerializeField] private TextAsset[] RabiesInks;


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
        List<TextAsset> listOfActiveViruses = new List<TextAsset>();

        if (GameWorldStatsManager.instance.tyhpoidIsActive)
        {
            listOfActiveViruses.Add(TyphoidInks[Random.Range(0, 3)]);
        }

        if (GameWorldStatsManager.instance.tuberculosisIsActive)
        {
            listOfActiveViruses.Add(TuberCulosisInks[Random.Range(0, 3)]);
        }

        if (GameWorldStatsManager.instance.dengueIsActive)
        {
            listOfActiveViruses.Add(DengueInks[Random.Range(0, 3)]);
        }

        if (GameWorldStatsManager.instance.influenzaIsActive)
        {
            listOfActiveViruses.Add(DengueInks[Random.Range(0, 3)]);
        }

        if (GameWorldStatsManager.instance.coronaIsActive)
        {
            listOfActiveViruses.Add(CoronaInks[Random.Range(0, 3)]);
        }

        if (GameWorldStatsManager.instance.rabiesIsActive)
        {
            listOfActiveViruses.Add(RabiesInks[Random.Range(0, 3)]);
        }

        return listOfActiveViruses[Random.Range(0, listOfActiveViruses.Count)];
    }
}