using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayController : MonoBehaviour {
	Camera playerCamera;
	public GameObject gan;
	public GameObject nearbullet;
	public GameObject farbullet;
	GameObject farbullet2;
	AudioClip fireSound;
	AudioSource audioSource;
	float coolTime;
	// Use this for initialization
	void Start () {
		playerCamera = GetComponent<Camera> ();
		fireSound = Resources.Load<AudioClip>("Audio/fire");
		audioSource = transform.parent.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update (){
		coolTime += Time.deltaTime;
		nearbullet.SetActive (false);
		if (farbullet2 != null) {
			Destroy (farbullet2);
		}
		
		if (Input.GetMouseButtonDown (0) && coolTime >= 0.2f) {
			coolTime = 0;
			nearbullet.SetActive (true);
			audioSource.PlayOneShot (fireSound);
			Ray ray = playerCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();

			if (Physics.Raycast (ray, out hit)) {
				farbullet2 = (GameObject)Instantiate (farbullet, hit.point, Quaternion.identity);
			} 
		}
	}
}
