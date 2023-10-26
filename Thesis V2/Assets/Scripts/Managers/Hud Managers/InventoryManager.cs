using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor.Experimental.GraphView;

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    public static InventoryManager instance { get; private set; }

    [SerializeField] private TextMeshProUGUI gloveText;
    [SerializeField] private TextMeshProUGUI alcoholText;
    [SerializeField] private TextMeshProUGUI maskText;
    public int gloveRemainingUses;
    public int alcoholRemainingUses;
    public int maskRemainingUses;

    public bool glovesInUse = false;
    public bool maskInUse = false;

    public bool itemsAreAvailable = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Inventory Manager exists in the current scene");
        }
        instance = this;
    }

    private void Update()
    {
        updateAllUsesText();

        if (gloveRemainingUses <= 0 && glovesInUse)
        {
            glovesInUse = false;
            StartCoroutine(cannotUse(gloveText));
        }

        if (maskRemainingUses <= 0 && maskInUse)
        {
            maskInUse = false;
            StartCoroutine(cannotUse(maskText));
        }
    }

    private void updateAllUsesText()
    {
        gloveText.text = String.Format("{0} / 3", gloveRemainingUses <= 0 && !itemsAreAvailable ? "--" : gloveRemainingUses);

        alcoholText.text = String.Format("{0} / 2", alcoholRemainingUses <= 0 && !itemsAreAvailable ? "--" : alcoholRemainingUses);

        maskText.text = String.Format("{0} / 3", maskRemainingUses <= 0 && !itemsAreAvailable ? "--" : maskRemainingUses);
    }

    public void toggleGlove()
    {
        if (gloveRemainingUses <= 0)
        {
            gloveRemainingUses = 0;
            StartCoroutine(cannotUse(gloveText));
            return;
        }

        glovesInUse = glovesInUse ? false : true;

        gloveText.color = glovesInUse ? Color.black : Color.white;

        StartCoroutine(itemUsed(gloveText));
    }

    public void toggleMask()
    {
        if (maskRemainingUses <= 0)
        {
            maskRemainingUses = 0;
            StartCoroutine(cannotUse(maskText));
            return;
        }

        maskInUse = maskInUse ? false : true;

        maskText.color = maskInUse ? Color.black : Color.white;

        StartCoroutine(itemUsed(maskText));
    }

    public bool useAlcohol()
    {
        if (alcoholRemainingUses <= 0)
        {
            alcoholRemainingUses = 0;
            StartCoroutine(cannotUse(alcoholText));
            return false;
        }

        // TODO
        alcoholRemainingUses--;
        StartCoroutine(itemUsed(alcoholText));

        return true;
    }

    private IEnumerator cannotUse(TextMeshProUGUI textOut)
    {
        Color prevColor = textOut.color;
        textOut.color = Color.red;
        yield return new WaitForSeconds(0.4f);
        textOut.color = prevColor;
    }

    private IEnumerator itemUsed(TextMeshProUGUI textOut){
        Color prevColor = textOut.color;
        textOut.color = Color.green;
        yield return new WaitForSeconds(0.4f);
        if (prevColor.Equals(Color.green)) prevColor = Color.black;
        textOut.color = prevColor;
    }

    public void LoadData(GameData data)
    {
        itemsAreAvailable = data.itemsAreAvailableData;
        gloveRemainingUses = data.gloveUsesData;
        alcoholRemainingUses = data.alcoholUsesData;
        maskRemainingUses = data.maskUsesData;
    }

    public void SaveData(ref GameData data)
    {
        data.itemsAreAvailableData = itemsAreAvailable;
        data.gloveUsesData = gloveRemainingUses;
        data.alcoholUsesData = alcoholRemainingUses;
        data.maskUsesData = maskRemainingUses;
    }
}
