using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wordsearch", menuName = "New Wordsearch")]
public class WordsearchData : ScriptableObject{
    [TextArea(10,10)]
    public string wordsearch;
    public List<string> validWords;
    //public Vector3 gridScale = new Vector3(1,1,1);
}