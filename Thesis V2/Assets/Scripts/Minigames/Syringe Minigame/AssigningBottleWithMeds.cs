using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class AssigningBottleWithMeds : MonoBehaviour
{
    public static AssigningBottleWithMeds instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Assigning Bottle With Meds in current scene");
        }
        instance = this;
    }

    [SerializeField] private GameObject[] medicineBottles;
    [SerializeField] private TextMeshProUGUI dosage;
    public float dosageValue;

    public string npcPatient;
    public GameObject bed;

    public string[] mainVirusMeds;
    private string[] secondVirusMeds;
    private string[] thirdVirusMeds;

    private string outputMainMed;
    Dictionary<string, int> dosageDictionary;

    private void Start()
    {
        initializeDosageDict();
    }

    private void initializeDosageDict()
    {
        dosageDictionary = new Dictionary<string, int>() {
            {"Fluoroquinolones", 500},
            {"Cephalosporins", 300},
            {"Macrolides", 500},
            {"Carbapenems", 600},
            {"Isoniazid", 300},
            {"Rifampin", 600},
            {"Pyrazinamide", 1750},
            {"Ethambutol", 1400},
            {"Streptomycin", 1050},
            {"Anti-Zoonotic", 1000},
            {"Paracetamol", 500},
            {"Molnupiravir", 800},
            {"Remdesivir", 200},
            {"Oseltamivir Phosphate", 75},
            {"Zanamivir", 10},
            {"Peramivir", 600},
            {"Baloxavir Marboxil", 40}
        };
    }

    private void getMeds(string virus)
    {
        MedicineManager.instance.getBottleNames(virus, out mainVirusMeds, out secondVirusMeds, out thirdVirusMeds);
    }

    private void setDosage()
    {
        dosageValue = dosageDictionary[outputMainMed];
        dosage.text = dosageValue.ToString();
    }

    public void setBottleNames(string virus)
    {
        getMeds(virus);

        List<int> medIndexes = new List<int>() { 0, 1, 2 };
        List<int> shuffledMedIndexes = ShuffleIntList(medIndexes);
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    outputMainMed = mainVirusMeds[Random.Range(0, mainVirusMeds.Length)];
                    medicineBottles[shuffledMedIndexes[0]].GetComponent<BottleBehavior>().medLabel = outputMainMed;
                    break;

                case 1:
                    medicineBottles[shuffledMedIndexes[1]].GetComponent<BottleBehavior>().medLabel = secondVirusMeds[Random.Range(0, secondVirusMeds.Length)];
                    break;

                case 2:
                    medicineBottles[shuffledMedIndexes[2]].GetComponent<BottleBehavior>().medLabel = thirdVirusMeds[Random.Range(0, thirdVirusMeds.Length)];
                    break;
            }
        }

        setDosage();
    }

    public List<int> ShuffleIntList(List<int> list)
    {
        List<int> newShuffledList = new List<int>();
        int listcCount = list.Count;
        for (int i = 0; i < listcCount; i++)
        {
            int randomElementInList = Random.Range(0, list.Count);
            newShuffledList.Add(list[randomElementInList]);
            list.Remove(list[randomElementInList]);
        }
        return newShuffledList;
    }
}