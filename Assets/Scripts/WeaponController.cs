using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
	public GameObject nearbullet;
	public GameObject farbullet;
	GameObject farbullet2;
	AudioClip fireSound;
	AudioSource audioSource;
	public Vector3 destination;
	// Use this for initialization
	void Start () {
		fireSound = Resources.Load<AudioClip>("Audio/fire");
		audioSource = transform.parent.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		nearbullet.SetActive (false);
		if (farbullet2 != null) {
			Destroy (farbullet2);
		}
	}
	public void shooting1(){
		nearbullet.SetActive (true);
		audioSource.PlayOneShot (fireSound);
	}

	public void shooting2(){
		farbullet2 = (GameObject)Instantiate (farbullet, destination, Quaternion.identity);
	}
}
