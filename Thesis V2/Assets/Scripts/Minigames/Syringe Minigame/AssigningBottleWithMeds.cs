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

    private void getMeds(string virus)
    {
        MedicineManager.instance.getBottleNames(virus, out mainVirusMeds, out secondVirusMeds, out thirdVirusMeds);
    }

    private void randomDosage()
    {
        dosageValue = Random.Range(10, 101);
        dosage.text = dosageValue.ToString();
    }

    public void setBottleNames(string virus)
    {
        getMeds(virus);
        randomDosage();

        List<int> medIndexes = new List<int>() { 0, 1, 2 };
        List<int> shuffledMedIndexes = ShuffleIntList(medIndexes);
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    medicineBottles[shuffledMedIndexes[0]].GetComponent<BottleBehavior>().medLabel = mainVirusMeds[Random.Range(0, mainVirusMeds.Length)];
                    break;

                case 1:
                    medicineBottles[shuffledMedIndexes[1]].GetComponent<BottleBehavior>().medLabel = secondVirusMeds[Random.Range(0, secondVirusMeds.Length)];
                    break;

                case 2:
                    medicineBottles[shuffledMedIndexes[2]].GetComponent<BottleBehavior>().medLabel = thirdVirusMeds[Random.Range(0, thirdVirusMeds.Length)];
                    break;
            }
        }
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