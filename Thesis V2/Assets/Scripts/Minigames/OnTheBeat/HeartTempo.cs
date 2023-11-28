using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HeartTempo : MonoBehaviour
{
    public static HeartTempo instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Heart Tempo in current scene");
        }
        instance = this;
    }

    public GameObject heart;
    public bool beat = false;
    public bool updateBeat = true;
    public float targetScale = 2.7f;
    public float maxScale = 3f;
    public float scaleChange = 0.05f;

    public float heartZScale;

    private AudioSource heartBeat;

    private void Start()
    {
        heartBeat = GetComponent<AudioSource>();
    }

    private void Update()
    {
        heartZScale = heart.transform.localScale.z;

        if (!updateBeat)
        {
            heartBeat.Stop();
            heartBeat.Play();
            heart.transform.localScale = new Vector3(maxScale, maxScale, maxScale);
            updateBeat = true;
            beat = true;
            return;
        }

        heart.transform.localScale -= new Vector3(scaleChange, scaleChange, scaleChange) * Time.deltaTime;
    }
}
