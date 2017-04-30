using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayController : MonoBehaviour {
	Camera playerCamera;
	float coolTime;
	WeaponController weaponController;
	Vector3 center = new Vector3(Screen.width/2, Screen.height/2, 0);
	// Use this for initialization
	void Start () {
		playerCamera = GetComponent<Camera> ();
		weaponController = GetComponent<WeaponController> ();
	}

	// Update is called once per frame
	void Update (){
		coolTime += Time.deltaTime;

		if (Input.GetMouseButtonDown (0) && coolTime >= 0.2f) {
			coolTime = 0;
			Ray ray = playerCamera.ScreenPointToRay(center);
			RaycastHit hit = new RaycastHit ();
			Physics.Raycast (ray, out hit);
			weaponController.shooting (hit);
		}
	}
}
