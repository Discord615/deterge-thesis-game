using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(countDownToMainMenu());
    }

    IEnumerator countDownToMainMenu()
    {
        yield return new WaitForSeconds(3f);
        LoadingScreen.instance.LoadScene(0);
    }
}
