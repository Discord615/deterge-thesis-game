using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager instance { get; private set; }

    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject loseScreen;

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

    private void reduceHealth(float reductionValue)
    {
        healthBar.value -= reductionValue;
    }

    public void healthRestore()
    {
        healthBar.value = healthBar.maxValue;
    }
}