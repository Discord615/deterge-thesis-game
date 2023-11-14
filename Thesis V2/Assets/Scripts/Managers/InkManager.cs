using UnityEngine;
using System.Collections.Generic;
using Ink.Parsed;

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

    [Header("Sick Walking NPC Dialogue")]
    [SerializeField] private TextAsset[] walkingSickInks;

    [Header("Get DNA Samples Dialogue")]
    [SerializeField] private TextAsset[] getDNASampleDialogue;

    public TextAsset getWalkingSickInk()
    {
        return walkingSickInks[Random.Range(0, walkingSickInks.Length)];
    }


    public TextAsset getRandomInk(bool isMale)
    {
        if (isMale) return getMaleInk();
        return getFemaleInk();
    }

    private TextAsset getMaleInk()
    {
        return maleRandomInks[Random.Range(0, maleRandomInks.Length)];
    }

    private TextAsset getFemaleInk()
    {
        return femaleRandomInks[Random.Range(0, femaleRandomInks.Length)];
    }

    public TextAsset getVirusDialogue(string virusName) // TODO: Change to individual Viruses
    {
        TextAsset result = null;
        switch (virusName)
        {
            case "tuber":
                result = TuberCulosisInks[Random.Range(0, TuberCulosisInks.Length)];
                break;

            case "typhoid":
                result = TyphoidInks[Random.Range(0, TyphoidInks.Length)];
                break;

            case "dengue":
                result = DengueInks[Random.Range(0, DengueInks.Length)];
                break;

            case "flu":
                result = InfluenzaInks[Random.Range(0, InfluenzaInks.Length)];
                break;

            case "corona":
                result = CoronaInks[Random.Range(0, CoronaInks.Length)];
                break;

            case "rabies":
                result = RabiesInks[Random.Range(0, RabiesInks.Length)];
                break;
        }

        return result;
    }

    public TextAsset getDNASampleAcquisitionInk()
    {
        TextAsset result = null;

        // TODO: add inks

        return result;
    }
}