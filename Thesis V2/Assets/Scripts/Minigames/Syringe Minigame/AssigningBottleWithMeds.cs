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

    private string[] mainVirusMeds;
    private string[] secondVirusMeds;
    private string[] thirdVirusMeds;

    private void getMeds(string virus)
    {
        MedicineManager.instance.getBottleNames(virus, out mainVirusMeds, out secondVirusMeds, out thirdVirusMeds);
    }

    private void randomDosage(){
        dosageValue = Random.Range(10, 101);
        dosage.text = dosageValue.ToString();
    }

    public void setBottleNames(string virus)
    {
        getMeds(virus);
        randomDosage();

        for (int i = 0; i < 3; i++)
        {
            List<int> medIndexes = new List<int>() { 0, 1, 2 };
            int medIndex = medIndexes[Random.Range(0, medIndexes.Count)];

            switch (i)
            {
                case 0:
                    medicineBottles[medIndex].GetComponent<BottleBehavior>().medLabel = mainVirusMeds[Random.Range(0, mainVirusMeds.Length)];
                    break;

                case 1:
                    medicineBottles[medIndex].GetComponent<BottleBehavior>().medLabel = secondVirusMeds[Random.Range(0, mainVirusMeds.Length)];
                    break;

                case 2:
                    medicineBottles[medIndex].GetComponent<BottleBehavior>().medLabel = thirdVirusMeds[Random.Range(0, mainVirusMeds.Length)];
                    break;
            }

            medIndexes.RemoveAt(medIndex);
        }
    }
}