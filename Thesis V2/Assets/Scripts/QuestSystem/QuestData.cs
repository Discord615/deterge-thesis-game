using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    public SerializableDictionary<string, string> displayNameData;
    public SerializableDictionary<string, QuestState> questStateData;
    public SerializableDictionary<string, int> questStepIndexData;
    public SerializableDictionary<string, string> serializedQuestStepStatesData;

    // public QuestData(string displayName, QuestState state, int questStepIndex, QuestStepState[] questStepStates){
    //     this.displayName = displayName;
    //     this.state = state;
    //     this.questStepIndex = questStepIndex;
    //     this.questStepStates = questStepStates;
    // }

    public QuestData(){
        this.displayNameData = new SerializableDictionary<string, string>();
        this.questStateData = new SerializableDictionary<string, QuestState>();
        this.questStepIndexData = new SerializableDictionary<string, int>();
        this.serializedQuestStepStatesData = new SerializableDictionary<string, string>();
    }
}
