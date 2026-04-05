using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour {

    void FixedUpdate() {
		transform.Rotate (new Vector3 (15.0f, 30.0f, 45.0f) * Time.deltaTime);
    }

}