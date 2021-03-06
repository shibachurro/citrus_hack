﻿using UnityEngine;
using System.Collections.Generic;
 
public class Gravity : MonoBehaviour{	
	public static float range = 1000;
    public Vector3 startPoint;
    
    void Start(){
        startPoint = this.transform.position;
    }
	void FixedUpdate () {
       
       
		Collider[] cols  = Physics.OverlapSphere(transform.position, range); 
		List<Rigidbody> rbs = new List<Rigidbody>();
 
		foreach(Collider c in cols){
            Rigidbody rb = c.attachedRigidbody;
			if(rb != null && rb != GetComponent<Rigidbody>() && !rbs.Contains(rb)){
				rbs.Add(rb);
				Vector3 offset = transform.position - c.transform.position;
				rb.AddForce( offset / offset.sqrMagnitude * GetComponent<Rigidbody>().mass);
			}
		}
    }

    void OnTriggerEnter(Collider coll){
       
        if(coll.gameObject.tag == "Respawn"){
            this.transform.position = startPoint;
        }
        if(coll.gameObject.tag == "Finish"){
            Debug.Log("moved");
        }
	}
}