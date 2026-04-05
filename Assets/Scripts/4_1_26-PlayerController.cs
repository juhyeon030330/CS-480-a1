using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody _playerBody;
    private int _score;
    private bool _jump;

    void Start() {
        _playerBody = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            _jump = true;
        }
    }

    void FixedUpdate() {
        float x = 0f;
        float z = 0f;

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x =  1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)  x = -1f;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)    z =  1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)  z = -1f;

        float y = 0.0f;
        if (_jump) {
            y = 30.0f;
            _jump = false;
        }

        Vector3 move = new Vector3(x, y, z);
        _playerBody.AddForce(move * speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
        }
    }
}