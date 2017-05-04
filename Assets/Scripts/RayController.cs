using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayController : MonoBehaviour {
	[SerializeField] private GameObject target;
	private Camera playerCamera;
	private float coolTime;
	private Vector3 center = new Vector3(Screen.width/2, Screen.height/2, 0);
	private WeaponController weaponController;
	private TargetController targetController;
	private float distancex;
	private float distancey;
	public GameObject marker;
	public float score;

	void Start () {
		playerCamera = GetComponent<Camera> ();
		weaponController = GetComponent<WeaponController> ();
		targetController = target.GetComponent<TargetController> ();
		score = 0;
	}

	// Update is called once per frame
	void Update (){
		coolTime += Time.deltaTime;
		if (Input.GetMouseButtonDown (0) && coolTime >= 0.2f && weaponController.currentbullet > 0) {
			coolTime = 0;
			Ray ray = playerCamera.ScreenPointToRay(center);
			RaycastHit hit = new RaycastHit ();
			Physics.Raycast (ray, out hit);
			weaponController.shooting (hit);
			weaponController.currentbullet -= 1;
			if (hit.collider != null && hit.collider.gameObject.tag == "Target"){
				targetController.life -= 1;
				distancex = Mathf.Abs (hit.point.x - marker.transform.position.x);
				distancey = Mathf.Abs (hit.point.y - marker.transform.position.y);
				score += Mathf.Round(1 / (distancex + distancey)) * 10;
			} 
		}
	}
}
