﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;
    AudioSource audioSource;
 
    [SerializeField] float rcsThrust = 150f;
    [SerializeField] float mainThrust = 20f;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
	}


    void OnCollisionEnter(Collision collision)
    {
  
        switch (collision.gameObject.tag)
        {
            case "friendly":
                print("hit:" + collision.gameObject.name);
                break;

            case "fuel":
                print("fuel");
                break;

            default:
                break;
        }
    }

    void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector2.up * mainThrust);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

    }

    void Rotate()
    {

        rigidBody.freezeRotation = true;
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -1 * rotationThisFrame);
        }
        rigidBody.freezeRotation = false;
    }
}
