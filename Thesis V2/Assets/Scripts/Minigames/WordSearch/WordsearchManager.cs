using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

//Some notes:
//uses a scriptable object to contain data (wordsearch grid and valid words)
//create a new one with asset menu -> New Wordsearch
//make sure you write your wordsearch grid in the New Wordsearch object in CAPS
//make sure you write valid words in CAPS
//double check to see you're not feeding it a jagged array
//wordsearchLetterObj should have the WSLetter prefab
//WSLetter is the letter tile
//container should have the Container prefab
//Container organizes WSLetters into neat rows for the word search
//wordsearchGrid should be given a GameObject with GridLayoutComponent, Fixed Row Count

public class WordsearchManager : MonoBehaviour{
    public static WordsearchManager Instance { get; private set; }
    void Awake(){
        if(Instance == null){
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public WordsearchData wordsearchData;
    [SerializeField] Color baseColor, activeColor, searchColor;
    public Color BaseColor {
        get { return baseColor; }
        set { baseColor = value; }
    }
    public Color ActiveColor {
        get { return activeColor; }
        set { activeColor = value; }
    }
    public Color SearchColor {
        get { return searchColor; }
        set { searchColor = value; }
    }

    [SerializeField] bool isDragging;
    public bool IsDragging {
        get { return isDragging; }
        set { isDragging = value; }
    }

    WordsearchLetter firstLetter, finalLetter;
    
    public WordsearchLetter FirstLetter {
        get { return firstLetter; }
        set { firstLetter = value; }
    }
    public WordsearchLetter FinalLetter {
        get { return finalLetter; }
        set { finalLetter = value; }
    }

    [SerializeField] GameObject wordsearchLetterObj;
    [SerializeField] GameObject wordsearchGrid, container;
    WordsearchLetter[,] matrix;
    public WordsearchLetter[,] Matrix {
        get { return matrix; }
    }

    List<string> validWords;
    public int totalNumOfValidWords;

    [SerializeField] float fontSize = 25f;
    [SerializeField] Vector2 cellSize = new Vector2(50f, 50f), spacing;

    //generates matrix of letters
    //NEVER feed this a jagged array EVER
    public void populateWSGrid(){ // * Call whenever wordsearchData is changed
        //loads wordsearch validWords list into manager's list
        //any alterations to this copy of the list doesn't mess with the scrip obj's data
        totalNumOfValidWords = 0;
        validWords = new List<string>();
        foreach(string s in wordsearchData.validWords){
            totalNumOfValidWords++;
            validWords.Add(s);
        }

        string[] letterRows = wordsearchData.wordsearch.Split('\n');
        char[][] letterGrid = new char[letterRows.Length][];
        for(int i = 0; i < letterGrid.GetLength(0); i++){
            letterGrid[i] = letterRows[i].ToCharArray();
        }

        wordsearchGrid.GetComponent<GridLayoutGroup>().constraintCount = letterRows.Length;  
        matrix = new WordsearchLetter[letterGrid.Length,letterGrid[0].Length];

        for(int i = 0; i < matrix.GetLength(0); i++){
            for(int j = 0; j < matrix.GetLength(1); j++){
                GameObject letter = Instantiate(wordsearchLetterObj);
                letter.name = "(" + i + ", " + j + "): " + letterGrid[i][j].ToString();
                letter.transform.SetParent(wordsearchGrid.transform);

                WordsearchLetter letterObj = letter.GetComponentInChildren<WordsearchLetter>();
                letterObj.gameObject.name = letterGrid[i][j].ToString();
                letterObj.Coords = new Vector2Int(i, j);
                letterObj.SetLetter(letterGrid[i][j]);
                matrix[i,j] = letterObj;
            }
        }

        foreach(WordsearchLetter w in matrix){
            w.AssignNeighbors();
        }

        ResizeGrid();
    }

    void Update(){
        wordsearchGrid.GetComponent<GridLayoutGroup>().cellSize = cellSize;
        wordsearchGrid.GetComponent<GridLayoutGroup>().spacing = spacing;

        if (matrix == null) return;

        foreach(WordsearchLetter letter in matrix){
            letter.GetComponent<TMPro.TMP_Text>().fontSize = fontSize;
        }
    }

    void ResizeGrid(){
        //get tile size
        var obj = Instantiate(wordsearchLetterObj);
        obj.transform.SetParent(wordsearchGrid.transform);
        float width = obj.GetComponent<RectTransform>().rect.width;
        float height = obj.GetComponent<RectTransform>().rect.height;
        Destroy(obj);

        float totalHeight = height * matrix.GetLength(0);
        float totalWidth = width * matrix.GetLength(1);

        var rt = wordsearchGrid.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(totalWidth, totalHeight);

        //!!! - CAVEMAN ANSWERS - !!!
        //scale is manually inputted in WordsearchData
        wordsearchGrid.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        //!!! - UNGA BUNGA OVER - !!!

        //more elegant solution would be getting the bounds of WSGrid post-scale
        //and lowering scale until bounds are a certain number
    }

    List<WordsearchLetter> letterList, lastSuccessfulSearch;
    //look for straight lines between starting and current letter
    public void LineSearch(){
        /*
        rules:
            -search each direction
            -add searched nodes to a list, including first
            -if the search hits an edge, clear
            -if the search hits FinalLetter, return the list
            -if the search does neither, terminate with no changes
        */
        
        letterList = new List<WordsearchLetter>();

        //search n
        if(SearchDirection(firstLetter, Dir.n)){
            return;
        }

        //search ne
        if(SearchDirection(firstLetter, Dir.ne)){
            return;
        }
        
        //search e
        if(SearchDirection(firstLetter, Dir.e)){
            return;
        }

        //search se
        if(SearchDirection(firstLetter, Dir.se)){
            return;
        }

        //search s
        if(SearchDirection(firstLetter, Dir.s)){
            return;
        }

        //search sw
        if(SearchDirection(firstLetter, Dir.sw)){
            return;
        }

        //search w
        if(SearchDirection(firstLetter, Dir.w)){
            return;
        }

        //search nw
        if(SearchDirection(firstLetter, Dir.nw)){
            return;
        }

        //finalLetter is not on a cardinal direction
        letterList = lastSuccessfulSearch;
    }

    bool SearchDirection(WordsearchLetter currentLetter, Dir direction){
        letterList.Clear();
        //return true if it finds finalLetter
        //return false otherwise
        
        //mouse is over first letter
        if(finalLetter == firstLetter){
            letterList.Add(currentLetter);
            lastSuccessfulSearch = letterList;
            ColorizeTiles(letterList);
            return true;
        }

        //starts at bound of search direction
        if(currentLetter.GetDirection(direction) == null){
            letterList.Add(currentLetter);
            if(currentLetter == finalLetter){
                lastSuccessfulSearch = letterList;
                ColorizeTiles(letterList);
                return true;
            }
            return false;
        }

        //searches until it hits a bound
        letterList.Add(firstLetter);
        while(currentLetter.GetDirection(direction) != null){
            currentLetter = currentLetter.GetDirection(direction);
            letterList.Add(currentLetter);
            if(currentLetter == finalLetter){
                lastSuccessfulSearch = letterList;
                ColorizeTiles(letterList);
                return true;
            }
        }
        return false;
    }

    public void ColorizeTiles(List<WordsearchLetter> letterList){
        //reset color
        foreach(WordsearchLetter letter in matrix){
            letter.SetColor();
        }

        foreach(WordsearchLetter letter in letterList){
            letter.ActivateTile();
        }
    }

    //you could convert this into a point system thing if you don't want to show the words list
    //just make it so EndDrag() doesn't check if the validWords list is empty
    //that you have a score variable that ++ if the validWords check goes through
    //and change the conditions or actions of CompleteWordsearch()
    public void EndDrag(){
        //Debug.Log(GetWord(letterList));
        
        //check if word is valid
        if(validWords.Contains(GetWord(letterList).ToUpper())){
            foreach(WordsearchLetter letter in letterList){
                letter.IsSearched = true;
            }
            GameEventsManager.instance.miscEvents.wordFound();
            validWords.Remove(GetWord(letterList).ToUpper());
            if(validWords.Count == 0){
                CompleteWordsearch();
            }
        }

        //reset color
        foreach(WordsearchLetter letter in matrix){
            letter.SetColor();
        }
    }

    //my brother in christ this is the exit point of the minigame
    void CompleteWordsearch(){
        GameEventsManager.instance.miscEvents.wordSearchCompleted();
    }

    string GetWord(List<WordsearchLetter> letterList){
        string s = "";
        foreach(WordsearchLetter letter in letterList){
            s += letter.Letter;
        }
        return s;
    }
}