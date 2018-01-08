using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SETiming : MonoBehaviour {

    public new AudioClip[] audio = new AudioClip[2];
    [SerializeField]
    private AudioSource soud;

    private void Start()
    {
        //soud = this.gameObject.GetComponent<AudioSource>();

    }

    void OnPlayJump()
    {
        soud.clip = audio[0];
        soud.PlayOneShot(soud.clip);
    }

    void OnPlayAttack()
    {
        soud.clip = audio[1];
        soud.PlayOneShot(soud.clip);
    }

}
