using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimScript : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    Animator animator;

    [SerializeField] float speed;
    [SerializeField] float deccelarationSpeed = 0.5f;
    [SerializeField] float accelarationSpeed = 1f;

    [Header("Bed Variables")]
    public bool isSick = false;
    public bool goingToBed = false;
    public bool isLayingDown = false;
    public bool slowDown = false;
    public bool stopped = false;

    [Header("Chair Variables")]
    public bool wantToSit = false;
    public bool isSitting = false;

    [SerializeField] private Material skinColor;
    private Color originalSkinColor;


    private void Start()
    {
        originalSkinColor = skinColor.color;
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        skinColor.color = isSick ? Color.green : originalSkinColor;

        updateSpeed();

        animator.SetFloat("Speed", speed);
    }

    private void updateSpeed()
    {
        if (stopped)
        {
            speed = 0;
            return;
        }

        if (speed > 1f) speed = 1f;

        if (!slowDown)
        {
            speed += accelarationSpeed * Time.deltaTime;
            return;
        }

        speed -= deccelarationSpeed * Time.deltaTime;

        if (speed < 0.05f)
        {
            speed = 0;
            stopped = true;
            slowDown = false;
        }
    }

    public void LoadData(GameData data)
    {
        data.NPCIsLayingDownMap.TryGetValue(id, out isLayingDown);

        data.NPCIsSickMap.TryGetValue(id, out isSick);

        data.NPCIsSittingMap.TryGetValue(id, out isSitting);

        data.NPCWantToSitMap.TryGetValue(id, out wantToSit);
    }

    public void SaveData(ref GameData data)
    {
        if (data.NPCIsLayingDownMap.ContainsKey(id))
        {
            data.NPCIsLayingDownMap.Remove(id);
        }
        data.NPCIsLayingDownMap.Add(id, isLayingDown);

        if (data.NPCIsSickMap.ContainsKey(id))
        {
            data.NPCIsSickMap.Remove(id);
        }
        data.NPCIsSickMap.Add(id, isSick);

        if (data.NPCIsSittingMap.ContainsKey(id))
        {
            data.NPCIsSittingMap.Remove(id);
        }
        data.NPCIsSittingMap.Add(id, isSitting);

        if (data.NPCWantToSitMap.ContainsKey(id))
        {
            data.NPCWantToSitMap.Remove(id);
        }
        data.NPCWantToSitMap.Add(id, wantToSit);
    }
}
