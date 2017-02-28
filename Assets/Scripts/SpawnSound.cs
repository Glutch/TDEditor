using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSound : MonoBehaviour {

    public AudioClip[] spawnSounds;

	void Start () {
        AudioManager.instance.PlaySound(spawnSounds[Random.Range(0, (spawnSounds.Length - 1))], transform.position, 1);
	}
}
