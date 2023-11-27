using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WordsearchLetter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler{
    [SerializeField] char letter;

    public char Letter {
        get { return letter; }
        set { letter = value; }
    }

    [SerializeField] Vector2Int coords;
    public Vector2Int Coords{
        get { return coords; }
        set { coords = value; }
    }

    bool isSelected, isSearched;
    
    public bool IsSelected {
        get { return isSelected; }
        set { isSelected = value; }
    }
    public bool IsSearched {
        get { return isSearched; }
        set { isSearched = value; }
    }

    [SerializeField] WordsearchLetter n, ne, e, se, s, sw, w, nw;
    public WordsearchLetter GetDirection(Dir direction){
        switch(direction){
            case Dir.n: return n;
            case Dir.ne: return ne;
            case Dir.e: return e;
            case Dir.se: return se;
            case Dir.s: return s;
            case Dir.sw: return sw;
            case Dir.w: return w;
            case Dir.nw: return nw;
            default: return null;
        }
    }

    Image letterBg;
    public Image LetterBg {
        get { return letterBg; }
        set { letterBg = value; }
    }

    void Awake(){
        letterBg = transform.parent.GetComponent<Image>();
    }

    public void AssignNeighbors(){
        var matrix = WordsearchManager.Instance.Matrix;
        //0 = row, 1 = col
        int maxX = matrix.GetLength(0) - 1;
        int maxY = matrix.GetLength(1) - 1;

        n = coords.x > 0 ? matrix[coords.x - 1, coords.y] : null;
        ne = coords.x > 0 && coords.y < maxY ? matrix[coords.x - 1, coords.y + 1] : null;
        e = coords.y < maxY ? matrix[coords.x, coords.y + 1] : null;
        se = coords.x < maxX && coords.y < maxY ? matrix[coords.x + 1, coords.y + 1] : null;
        s = coords.x < maxX ? matrix[coords.x + 1, coords.y] : null;
        sw = coords.x < maxX && coords.y > 0 ? matrix[coords.x + 1, coords.y - 1] : null;
        w = coords.y > 0 ? matrix[coords.x, coords.y - 1] : null;
        nw = coords.x > 0 && coords.y > 0 ? matrix[coords.x - 1, coords.y - 1] : null;
    }

    //changes letterBg color based on whether or not letter is part of a word
    public void SetColor(){
        if(isSearched){
            letterBg.color = WordsearchManager.Instance.SearchColor;
        } else {
            letterBg.color = WordsearchManager.Instance.BaseColor;
        }
    }

    public void ActivateTile(){
        letterBg.color = WordsearchManager.Instance.ActiveColor;
    }
    
    //changes letter shown on tile
    public void SetLetter(char letter){
        this.letter = letter;

        var letterText = GetComponent<TMPro.TMP_Text>();
        letterText.text = this.letter.ToString().ToUpper();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData){
        if(WordsearchManager.Instance.IsDragging){
            WordsearchManager.Instance.FinalLetter = this;

            //fire linesearcher
            WordsearchManager.Instance.LineSearch();
            
            return;
        }

        //change color to activecolor
        letterBg.color = WordsearchManager.Instance.ActiveColor;
    }

    public void OnPointerExit(PointerEventData eventData){
        if(WordsearchManager.Instance.IsDragging){
            return;
        }

        //change color to basecolor
        //or searchcolor if isSearched is true
        if(isSearched){
            letterBg.color = WordsearchManager.Instance.SearchColor; 
        } else {
            letterBg.color = WordsearchManager.Instance.BaseColor;
        }
    }

    public void OnBeginDrag(PointerEventData eventData){
        isSelected = true;

        WordsearchManager.Instance.IsDragging = true;
        WordsearchManager.Instance.FirstLetter = this;
    }

    public void OnEndDrag(PointerEventData eventData){
        WordsearchManager.Instance.IsDragging = false;
        
        WordsearchManager.Instance.EndDrag();
    }

    public void OnDrag(PointerEventData eventData){
        //does nothing for now
        //TODO: draw a line with LineRenderer
    }
}

public enum Dir{
    n, ne, e, se, s, sw, w, nw
}