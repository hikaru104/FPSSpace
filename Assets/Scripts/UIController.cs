using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
	[SerializeField] private GameObject player;
	[SerializeField] private GUIStyle guiStyle;
	[SerializeField] private Texture reticle;
	private RayController rayController;
	private WeaponController weaponController;
	private float time;
	// Use this for initialization
	void Start () {
		rayController =player.GetComponent<RayController>();
		weaponController = player.GetComponent<WeaponController>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	}

	void OnGUI (){
		Rect position1 = new Rect (10, Screen.height - 40, 200, 40);
		Rect position2 = new Rect (10, Screen.height - 20, 200, 40);
		Rect position3 = new Rect (Screen.width - 130, Screen.height - 40, 200, 40);			Rect position4 = new Rect (Screen.width - 130, Screen.height - 20, 200, 40);
		Rect positioncenter = new Rect (Screen.width/2 - 20, Screen.height/2 - 20, 40, 40);
	
		GUI.Label (position1, "Time:" + time + "s", guiStyle);
		GUI.Label (position2, "Pt:" + rayController.score, guiStyle);
		GUI.Label (position3, "BulletBox:" + weaponController.bulletbox, guiStyle);
		GUI.Label (position4, "Bullet:" + weaponController.currentbullet + "/" + weaponController.maxbullet, guiStyle);
		GUI.DrawTexture (positioncenter, reticle);
	}
}
