using UnityEngine;
using System.Collections;

public class DestroyAudioSourceOnFinish : MonoBehaviour {

    private AudioSource aus;
    
    // Use this for initialization
    void Start () {
        aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
	    if (!aus.isPlaying) {
            Destroy(gameObject);
        }
	}
}
