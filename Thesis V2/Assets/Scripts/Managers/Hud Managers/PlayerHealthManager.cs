using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager instance { get; private set; }

    [SerializeField] private Slider healthBar;

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
            // TODO: Game Over From Infection
        }

        if (InputManager.getInstance().getAlcoholPressed())
        {
            healthBar.value += InventoryManager.instance.useAlcohol() ? 5 : 0;
        }

        if (InputManager.getInstance().getGlovePressed())
        {
            InventoryManager.instance.toggleGlove();
        }

        if (InputManager.getInstance().getMaskPressed())
        {
            InventoryManager.instance.toggleMask();
        }
    }

    public void reduceHealth()
    {
        reduceHealthWithGloves();
        reduceHealthWithMask();
    }

    private void reduceHealthWithGloves()
    {
        float reductionValue = 10;

        if (InventoryManager.instance.glovesInUse && InventoryManager.instance.gloveRemainingUses >= 1)
        {
            reductionValue = 3;
        }

        InventoryManager.instance.gloveRemainingUses--;
        healthBar.value -= reductionValue;
    }

    private void reduceHealthWithMask()
    {
        float reductionValue = 15;

        if (InventoryManager.instance.maskInUse && InventoryManager.instance.maskRemainingUses >= 1)
        {
            reductionValue = 5;
        }

        InventoryManager.instance.maskRemainingUses--;
        healthBar.value -= reductionValue;
    }

    public void fullRestore()
    {
        healthBar.value = healthBar.maxValue;
        InventoryManager.instance.alcoholRemainingUses = 2;
        InventoryManager.instance.gloveRemainingUses = 3;
        InventoryManager.instance.maskRemainingUses = 3;
    }

    public void healthRestore(){
        healthBar.value = healthBar.maxValue;
    }
}