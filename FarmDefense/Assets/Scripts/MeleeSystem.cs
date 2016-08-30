using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour {

    public Camera MainCamera;
    public ParticleSystem bloodParticle;
    public AudioSource hitSound;

    public float MaxRange = 5;
    public float Range;
    public int Damage = 50;

    public bool canAttack = false;

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire1")) {
            GetComponent<Animation>().Play();
        }

        if (canAttack) {
            RaycastHit hitRay;
            Transform CameraTransform = MainCamera.transform;
            if (Physics.Raycast(CameraTransform.position, CameraTransform.TransformDirection(Vector3.forward), out hitRay)) {
                Range = hitRay.distance;
                if (hitRay.collider.tag == "Enemy" && hitRay.distance < MaxRange) {
                    hitRay.transform.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);

                    Quaternion prefabRot = Quaternion.FromToRotation(Vector3.up, hitRay.normal);
                    Instantiate(bloodParticle, hitRay.point, prefabRot);

                    Instantiate(hitSound, hitRay.point, prefabRot);

                    canAttack = false;
                }
            }
        }
    }

    // Called sometime within the animation to begin the damaging frames
    void BeginAttack() {
        canAttack = true;
    }

    // Called sometime within the animation to stop the damaging frames
    void EndAttack() {
        canAttack = false;
    }
}
