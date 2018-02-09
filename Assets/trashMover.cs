using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashMover : MonoBehaviour {
    Rigidbody2D r;
    public float trashFireSpeed;
	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody2D>();
        r.velocity = Vector3.forward * trashFireSpeed * Time.deltaTime;
	}

}
