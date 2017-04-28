using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayController : MonoBehaviour {
	Camera playerCamera;
	float coolTime;
	WeaponController weaponController;
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
			Ray ray = playerCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit ();
			weaponController.shooting1 ();

			if (Physics.Raycast (ray, out hit)) {
				weaponController.destination = hit.point;
				weaponController.shooting2 ();
			} 
		}
	}
}
