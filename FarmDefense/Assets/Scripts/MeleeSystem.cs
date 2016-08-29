using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour {

    public Camera MainCamera;
    public float MaxRange;
    public float Range;
    public int Damage;
	
	// Update is called once per frame
	void Update() {

        if (Input.GetButtonDown("Fire1")) {
            GetComponent<Animation>().Play();
        }
	}

    void Attack() {
        RaycastHit hitRay;
        Transform CameraTransform = MainCamera.transform;
        if (Physics.Raycast(CameraTransform.position, CameraTransform.TransformDirection(Vector3.forward), out hitRay)) {
            Range = hitRay.distance;
            if (hitRay.distance < MaxRange) {
                hitRay.transform.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
