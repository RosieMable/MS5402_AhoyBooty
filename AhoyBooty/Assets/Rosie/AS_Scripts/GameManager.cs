using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{

    public UnityEvent OnCompleteMG;
    public UnityEvent OnRunOutTime;
    public int timer;


    // Start is called before the first frame update
    void Start()
    {
        StartMinigameCountdown();
    }


    void StartMinigameCountdown()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        OnRunOutTime.Invoke();
        print("Meh");

    }


}
