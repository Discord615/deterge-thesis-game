using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour, IDataPersistence
{
    public static PlayerHealthManager instance { get; private set; }

    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject loseScreen;
    private bool experiencedDamage = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Player Health Manager Exists in the current scene");
        }
        instance = this;
    }

    private void Update()
    {
        if (healthBar.value <= 0)
        {
            loseScreen.SetActive(true);
        }
    }

    public void reduceHealth(float reductionValue)
    {
        if (!experiencedDamage){
            DialogueManager.instance.EnterDialogueMode(InkManager.instance.firstTimeGettingDamaged);
            experiencedDamage = true;
        }
        healthBar.value -= (GameWorldStatsManager.instance.hasFaceMask  ? (reductionValue / 2f) : reductionValue) * Time.deltaTime;
    }

    public void reduceHealth(){
        if (!experiencedDamage){
            DialogueManager.instance.EnterDialogueMode(InkManager.instance.firstTimeGettingDamaged);
            experiencedDamage = true;
        }
        healthBar.value -= GameWorldStatsManager.instance.hasGlove ? 0f : 4f;
        GloveBehavior.instance.removeGlove();
    }

    public void healthRestore()
    {
        healthBar.value = healthBar.maxValue;
    }

    public void LoadData(GameData data)
    {
        this.experiencedDamage = data.experienceDamageData;
    }

    public void SaveData(ref GameData data)
    {
        data.experienceDamageData = this.experiencedDamage;
    }
}