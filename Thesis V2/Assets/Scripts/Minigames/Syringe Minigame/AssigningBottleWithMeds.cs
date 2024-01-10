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
        dosageDictionary = new Dictionary<string, int>() { // ! Change to reflect the new meds
            {"Cipro", 500}, // https://reference.medscape.com/drug/cipro-xr-ciprofloxacin-342530

            {"Antibiotics", 300}, // https://www.mayoclinic.org/drugs-supplements/amoxicillin-oral-route/proper-use/drg-20075356

            {"Anti-Zoonotic", 1000}, // https://www.cdc.gov/rabies/medical_care/vaccine.html

            {"Paracetamol", 500}, // https://www.nhs.uk/medicines/paracetamol-for-adults/how-and-when-to-take-paracetamol-for-adults/

            {"Tylenol", 20}, // https://www.tylenol.com/safety-dosing/dosage-for-adults

            {"Advil", 200}, // https://www.advil.com/our-products/advil-pain/advil-tablets/

            {"Aleve", 220}, // https://www.aleve.com/products/aleve/aleve-tablets

            {"Bioflu", 500} // https://www.mims.com/philippines/drug/info/bioflu?type=full
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

    public void setBottleNames(string virus, bool Tutorial)
    {
        getMeds(virus);

        List<int> medIndexes = new List<int>() { 0, 1, 2 };
        List<int> shuffledMedIndexes = ShuffleIntList(medIndexes);
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    outputMainMed = mainVirusMeds[Tutorial ? 0 : Random.Range(0, mainVirusMeds.Length)];
                    medicineBottles[shuffledMedIndexes[0]].GetComponent<BottleBehavior>().medLabel = outputMainMed;
                    break;

                case 1:
                    while (true)
                    {
                        string medName = secondVirusMeds[Random.Range(0, secondVirusMeds.Length)];
                        medicineBottles[shuffledMedIndexes[1]].GetComponent<BottleBehavior>().medLabel = medName;
                        if (medName != outputMainMed) break;
                    }
                    break;

                case 2:
                    while (true)
                    {
                        string medName = thirdVirusMeds[Random.Range(0, thirdVirusMeds.Length)];
                        medicineBottles[shuffledMedIndexes[2]].GetComponent<BottleBehavior>().medLabel = medName;
                        if (medName != outputMainMed) break;
                    }
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