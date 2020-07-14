using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (AudioSource ))]
public class AudioController : MonoBehaviour {
    [SerializeField ]
    AudioClip[] clips;

    [SerializeField]
    float DelayBetweenClips;

    bool canplay;

    AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent <AudioSource >();
        canplay = true;
	}


    public void play()
    {
        if (!canplay)
            return;

        GameManager .Instance .Timer .Add (()=>{
            canplay = true;
        },DelayBetweenClips );

        canplay = false;
        int clipIndex = Random.Range(0, clips.Length);
        AudioClip clip= clips [clipIndex ];

        source.PlayOneShot(clip );


    }


	void Update () {
		
	}
}
