using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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

        return true;
    }

    private IEnumerator cannotUse(TextMeshProUGUI textOut)
    {
        textOut.color = Color.red;
        yield return new WaitForSeconds(0.4f);
        textOut.color = Color.white;
    }

    public void LoadData(GameData data)
    {
        gloveRemainingUses = data.gloveUsesData;
        alcoholRemainingUses = data.alcoholUsesData;
        maskRemainingUses = data.maskUsesData;
    }

    public void SaveData(ref GameData data)
    {
        data.gloveUsesData = gloveRemainingUses;
        data.alcoholUsesData = alcoholRemainingUses;
        data.maskUsesData = maskRemainingUses;
    }
}
