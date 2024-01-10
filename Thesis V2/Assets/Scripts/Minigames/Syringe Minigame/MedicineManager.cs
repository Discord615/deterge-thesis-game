using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MedicineManager : MonoBehaviour
{
    public static MedicineManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Medicine Manager in current scene");
        }
        instance = this;
    }

    private Dictionary<string, string[]> medsDictionary = new Dictionary<string, string[]>();

    private void Start()
    {
        medsDictionary.Add("typhoid", new string[] {
            "Cipro"
        });

        medsDictionary.Add("tuber", new string[] {
            "Antibiotics"
        });

        medsDictionary.Add("rabies", new string[] {
            "Anti-Zoonotic"
        });

        medsDictionary.Add("dengue", new string[] {
            "Paracetamol",
            "Tylenol"
        });

        medsDictionary.Add("covid", new string[] {
            "Advil",
            "Aleve",
            "Tylenol",
            "Paracetamol"
        });

        medsDictionary.Add("flu", new string[] {
            "Tylenol",
            "Advil",
            "Bioflu",
            "Paracetamol"
        });
    }

    public void getBottleNames(string mainVirus, out string[] mainVirusMeds, out string[] secondVirusMeds, out string[] thirdVirusMeds)
    {

        mainVirusMeds = medsDictionary[mainVirus];

        while (true)
        {
            int dictionaryIndex = Random.Range(0, medsDictionary.Count);

            if (mainVirus.Equals(medsDictionary.ElementAt(dictionaryIndex).Key)) continue;

            secondVirusMeds = medsDictionary.ElementAt(dictionaryIndex).Value;
            break;
        }

        while (true)
        {
            int dictionaryIndex = Random.Range(0, medsDictionary.Count);

            if (mainVirus.Equals(medsDictionary.ElementAt(dictionaryIndex).Key)) continue;

            thirdVirusMeds = medsDictionary.ElementAt(dictionaryIndex).Value;
            break;
        }
    }
}