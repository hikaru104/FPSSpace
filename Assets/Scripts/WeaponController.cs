using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
	[SerializeField] private GameObject nearbullet;
	[SerializeField] private GameObject farbullet;
	[SerializeField] private AudioClip fireSound;
	GameObject farbullet2;
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = transform.parent.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		nearbullet.SetActive (false);
	}

	public void shooting(RaycastHit hit){
		nearbullet.SetActive (true);
		audioSource.PlayOneShot (fireSound);
		if (hit.collider != null) {
			farbullet2 = (GameObject)Instantiate (farbullet, hit.point, Quaternion.identity);
			Destroy (farbullet2, 0.1f);
		}
	}
}
