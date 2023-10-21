using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TextMeshProUGUI gloveText;
    [SerializeField] private TextMeshProUGUI alcoholText;
    [SerializeField] private TextMeshProUGUI maskText;
    private int gloveRemainingUses;
    private int alcoholRemainingUses;
    private int maskRemainingUses;

    private void Update() {
        updateAllUsesText();

        if (InputManager.getInstance().getAlcoholPressed()){
            useAlcohol();
        }

        if (InputManager.getInstance().getGlovePressed()){
            toggleGlove();
        }

        if (InputManager.getInstance().getMaskPressed()){
            toggleMask();
        }
    }

    private void updateAllUsesText(){
        gloveText.text = String.Format("{0} / 3", gloveRemainingUses);
        alcoholText.text = String.Format("{0} / 2", alcoholRemainingUses);
        maskText.text = String.Format("{0} / 3", maskRemainingUses);
    }

    private void toggleGlove(){
        if (gloveRemainingUses <= 0){
            gloveRemainingUses = 0;
            StartCoroutine(cannotUse(gloveText));
            return;
        }
        // TODO
    }

    private void toggleMask(){
        if (maskRemainingUses <= 0){
            maskRemainingUses = 0;
            StartCoroutine(cannotUse(maskText));
            return;
        }
        // TODO
    }

    private void useAlcohol(){
        if (alcoholRemainingUses <= 0){
            alcoholRemainingUses = 0;
            StartCoroutine(cannotUse(alcoholText));
            return;
        }

        alcoholRemainingUses--;
        // TODO
    }

    private IEnumerator cannotUse(TextMeshProUGUI textOut){
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
