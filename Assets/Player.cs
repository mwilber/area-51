﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float speed = 4f;
    [Tooltip("In ms^-1")] [SerializeField] float xRange = 1.5f;
    [Tooltip("In ms^-1")] [SerializeField] float yRange = 1f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        ProcessPosition();
        ProcessRotation();
		
	}

    void ProcessRotation(){

        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float pitchFromPosition = transform.localPosition.y * positionPitchFactor;
        float pitchFromThrow = yThrow * controlPitchFactor;

        float pitch = pitchFromPosition + pitchFromThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    void ProcessPosition() {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
