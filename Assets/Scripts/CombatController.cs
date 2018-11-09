using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.MagicLeap;
using UnityEngine;


public class CombatController : MonoBehaviour {
    private MLInputController _controller;
    private bool _enabled = false;
    private bool _trigger = false;

    public GameObject cloneObject;

    void Awake() {
        Debug.Log("AWAKE");

        MLInput.Start();
        MLInput.OnControllerButtonUp += OnButtonUp;
        _controller = MLInput.GetController(MLInput.Hand.Left);
    }

    void OnDestroy() {
        MLInput.OnControllerButtonUp -= OnButtonUp;
        MLInput.Stop();
    }

    void Update() {
        CheckControl();

        if (_trigger && _enabled) {
            // spawn new soldier
            //GameObject newObject = (GameObject)Instantiate(Resources.Load("./resource/Low poly archer"));
            GameObject newObject = Instantiate(cloneObject);


            // at some position of the island

            newObject.transform.parent = GameObject.Find("GameObject3").transform;
            newObject.transform.position = GameObject.Find("GameObject3").transform.position;

            Debug.Log("MAKING SOLDIER");

            _trigger = false;
        }

    }

    void CheckControl() {
        if (_controller.TriggerValue > 0.2f && _enabled) {
            _trigger = true;
        }
    }

    // Home button to start game
    void OnButtonUp(byte controller_id, MLInputControllerButton button) {
        if (button == MLInputControllerButton.HomeTap) {
            //_cube.SetActive(true);
            //_cube.transform.position = transform.position + transform.forward * _distance;
            //_cube.transform.rotation = transform.rotation;
            _enabled = true;
        }
    }

}
