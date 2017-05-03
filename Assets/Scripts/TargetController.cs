using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {
	[SerializeField] private int maxlife;
	private Animator anim;
	public int life;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		life = maxlife;
	}
	
	// Update is called once per frame
	void Update () {
		if (life == 0){
			anim.SetBool ("broken", true);
			Invoke ("restore", 10.0f);
		}
	}

	void restore () {
		anim.SetBool ("broken", false);
		life = maxlife;
	}
}
