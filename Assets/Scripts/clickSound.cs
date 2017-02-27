using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickSound : MonoBehaviour {

    public AudioClip selectSound;

    public void Play() {
        AudioManager.instance.PlaySound(selectSound, Camera.main.transform.position);
    }   

}
