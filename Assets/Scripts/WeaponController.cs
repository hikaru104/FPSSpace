using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
	[SerializeField] private GameObject nearbullet;
	[SerializeField] private GameObject farbullet;
	[SerializeField] private AudioClip fireSound;
	[SerializeField] private AudioClip reloadSound;
	private GameObject farbullet2;
	private AudioSource audioSource;
	public int currentbullet;
	public int bulletbox;
	public int maxbullet;
	// Use this for initialization
	void Start () {
		audioSource = transform.parent.GetComponent<AudioSource>();
		currentbullet = maxbullet;
	}

	// Update is called once per frame
	void Update () {
		nearbullet.SetActive (false);
		if (currentbullet < maxbullet && bulletbox > 0 && Input.GetKey (KeyCode.R)) {
			audioSource.PlayOneShot (reloadSound);
			if (bulletbox > maxbullet - currentbullet){
			bulletbox -= (maxbullet - currentbullet);
			currentbullet = maxbullet;
			} else {
				currentbullet += bulletbox;
				bulletbox = 0;
			}
		}
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
