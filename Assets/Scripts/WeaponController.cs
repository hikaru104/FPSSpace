using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
	[SerializeField] private GameObject nearbullet;
	public GameObject farbullet;
	GameObject farbullet2;
	[SerializeField] private AudioClip fireSound;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
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

	public void shooting2(Vector3 destination){
		farbullet2 = (GameObject)Instantiate (farbullet, destination, Quaternion.identity);
	}
}
