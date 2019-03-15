using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Vuforia;

public class HatMinigame : MinigameBase
{
    [SerializeField] private Transform[] SpawnPositions;
    [SerializeField] private GameObject HatPrefab;

    [SerializeField] private Hat RightHat;

    public GameObject RightHatRender;

    // Start is called before the first frame update
    void Start()
    {

        base.Start();


        SpawnHats();

        Invoke("PickRandomHat", 0.6f);



    }

    void SpawnHats()
    {
        if (SpawnPositions != null)
        {
            foreach (Transform position in SpawnPositions)
            {
                GameObject hat = Instantiate(HatPrefab, position);
            }
        }
    }

    private void Update()
    {


        base.Update();

    }

    private void PickRandomHat()
    {
        if (SpawnPositions != null)
        {
            RightHat = SpawnPositions[Random.Range(0, SpawnPositions.Length)].GetComponentInChildren<Hat>();

            RightHatRender.GetComponent<MeshRenderer>().material.color = RightHat.colourHat;
        }
    }
}
