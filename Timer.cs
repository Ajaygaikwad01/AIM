using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {


    private class TimedEvent
    {
        public float TimeToExecute;
        public callback Method;
        
        }

    private List<TimedEvent> events;

    public delegate void callback();

	void Awake () {

        events = new List<TimedEvent>();
		
	}
    public void Add(callback method, float insecond)
    {
        events.Add(new TimedEvent
            {
                Method =method,
                TimeToExecute =Time .time +insecond 

            });


    }

	// Update is called once per frame
	void Update () {
        if (events.Count == 0)
            return;

        for (int i = 0; i < events.Count; i++)
        {

            var timeEvent = events [i];
            if (timeEvent.TimeToExecute <= Time.time)
            {
                timeEvent.Method();
                events.Remove(timeEvent );
            }

        }
	}
}
