using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sinkAndItemsCompleter : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject healthPanel;
    private void Update() {
        if (GameWorldStatsManager.instance.hasFaceMask && GameWorldStatsManager.instance.hasGlove && healthBar.value >= healthBar.maxValue) {
            VisualCueManager.instnace.sinkCue.SetActive(false);
            healthPanel.SetActive(false);
            TutorialManager.instance.continueTutorial();
            Destroy(this);
        }
    }
}
