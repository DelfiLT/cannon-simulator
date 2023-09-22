using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int jointCounter;
    public int JointCounter { get { return jointCounter; } set { jointCounter = value; } }

    public static GameManager Instance { get; private set; }

    public GameObject finalScreen;

    public TextMeshProUGUI barrelsBraked;

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    void Start()
    {
        jointCounter = 0;
    }

    void Update()
    {
        if(Cannon.Instance.BulletQuantity <= 0)
        {
            StartCoroutine(waitBullet());
            barrelsBraked.text = jointCounter.ToString("0");
        }
    }

    IEnumerator waitBullet()
    {
        yield return new WaitForSeconds(5f);
        finalScreen.SetActive(true);
    }
}
