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

    private void Start() {
        medsDictionary.Add("Typhoid", new string[] {
            "Fluoroquinolones",
            "Cephalosporins",
            "Macrolides",
            "Carbapenems"
        });

        medsDictionary.Add("Tuberculosis", new string[] {
            "Isoniazid",
            "Rifampin",
            "Pyrazinamide",
            "Ethambutol",
            "Streptomycin"
        });

        // ! UP FOR DISCUSSION
        // medsDictionary.Add("Rabies", new string[] {});

        medsDictionary.Add("Dengue", new string[] {
            "Paracetamol" // ? Add more?
        });

        medsDictionary.Add("Covid", new string[] {
            "molnupiravir",
            "remdesivir"
        });

        medsDictionary.Add("Influenza", new string[] {
            "Oseltamivir Phosphate",
            "Zanamivir",
            "Peramivir",
            "Baloxavir Marboxil"
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