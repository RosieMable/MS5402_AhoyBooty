using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Vuforia;

public class MinigameBase : TouchManager, ITrackableEventHandler
{

    public UnityEvent GameOverEvent;

    public UnityEvent SucceededEvent;

    public float interval = 121.0f;

    public Text timer_txt;

    public TrackableBehaviour imageTarget;

    public bool IsTargetDetected = false;


    // Start is called before the first frame update
   protected void Start()
    {
        imageTarget = GetComponentInParent<TrackableBehaviour>();

        imageTarget.RegisterTrackableEventHandler(this);
    }

    protected void Update()
    {

        if (IsTargetDetected)
        {
            interval -= Time.deltaTime;
            timer_txt.text = "Seconds Left: " + (int)interval;
        }
        else
        {
            timer_txt.text = null;
        }




        EventSystem();
    }


    protected void EventSystem()
    {
        if (interval <= 0)
        {
            print("gameover");
            GameOverEvent.Invoke();
        }
    }

     void ITrackableEventHandler.OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
             newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            IsTargetDetected = true;
        }
        else
        {
            IsTargetDetected = false;
        }

    }
}
