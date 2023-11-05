using UnityEngine;
using System.Collections.Generic;

public class MedicineManager : MonoBehaviour {
    public static MedicineManager instance { get; private set; }

    private void Awake() {
        if (instance != null) {
            Debug.LogError("More than one instance of Medicine Manager in current scene");
        }
        instance = this;
    }

    private IDictionary<string, string[]> medsDictionary = new IDictionary<string, string[]>();

    medsDictionary.Add("Typhoid", new string[] {/* TODO: Insert Meds */})
}