﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 0.5f;
	float newRotY = 0;
	float rotspeed = 0.5f;

    void Update()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        float newZ = transform.position.z;

        if (Input.GetKey(KeyCode.UpArrow))
        {
	        newZ = transform.position.z - speed * Time.deltaTime ;
	        newRotY = 180;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
	        newZ = transform.position.z + speed * Time.deltaTime;
	        newRotY = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
	        newX = transform.position.x - speed * Time.deltaTime;
	        newRotY = -90;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
	        newX = transform.position.x + speed * Time.deltaTime;
	        newRotY = 90;
        }
	    transform.position = new Vector3(newX, newY, newZ);
	    transform.rotation = Quaternion.Lerp( Quaternion.Euler(0,newRotY,0),
		    transform.rotation,Time.deltaTime * rotspeed);  
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.name == "Cube")
        {
	        transform.localScale = new Vector3(3, 3, 3);
        }
	    if(collision.gameObject.name == "Ball")
	    {
		    transform.localScale = new Vector3(1, 1, 1);
	    }
    }
}
