using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
	[SerializeField] private GUIStyle guiStyle;
	[SerializeField] private Texture reticle;
	[SerializeField] private Texture snipe;
	private RayController rayController;
	private WeaponController weaponController;
	private float time;
	private Camera playerCamera;

	void Start () {
		rayController = GetComponent<RayController>();
		weaponController = GetComponent<WeaponController>();
		playerCamera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	}

	void OnGUI (){
		Rect position1 = new Rect (10, Screen.height - 40, 200, 40);
		Rect position2 = new Rect (10, Screen.height - 20, 200, 40);
		Rect position3 = new Rect (Screen.width - 130, Screen.height - 40, 200, 40);
		Rect position4 = new Rect (Screen.width - 130, Screen.height - 20, 200, 40);
		Rect reticleposition = new Rect (Screen.width / 2 - 20, Screen.height / 2 - 20, 40, 40);
		Rect snipeposition = new Rect (Screen.width / 2 - 750, Screen.height / 2 - 750, 1500, 1500);

		GUI.Label (position1, "Time:" + time + "s", guiStyle);
		GUI.Label (position2, "Pt:" + rayController.score, guiStyle);
		GUI.Label (position3, "BulletBox:" + weaponController.bulletbox, guiStyle);
		GUI.Label (position4, "Bullet:" + weaponController.currentbullet + "/" + weaponController.maxbullet, guiStyle);
		GUI.DrawTexture (reticleposition, reticle);
		if (Input.GetMouseButton (1)) {
			GUI.DrawTexture (snipeposition, snipe);
			playerCamera.fieldOfView = 5;
		}
		if (Input.GetMouseButtonUp (1)) {
			playerCamera.fieldOfView = 60;
		}
	}
}
