using UnityEngine;
using System.Collections.Generic;

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

    private string[] mainVirusMeds;
    private string[] secondVirusMeds;
    private string[] thirdVirusMeds;

    public void getMeds(string virus)
    {
        MedicineManager.instance.getBottleNames(virus, out mainVirusMeds, out secondVirusMeds, out thirdVirusMeds);
    }

    private void setBottleNames(string virus)
    {
        getMeds(virus);

        for (int i = 0; i < 3; i++)
        {
            List<int> medIndexes = new List<int>() { 0, 1, 2 };
            int medIndex = medIndexes[Random.Next(0, medIndexes.Count)];

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