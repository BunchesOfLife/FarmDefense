using UnityEngine;
using System.Collections;

public class ShootingSystem : MonoBehaviour {

    public Camera MainCamera;
    public ParticleSystem bloodParticle;
    public AudioSource shootSound;
    public AudioSource hitSound;

    public float MaxRange;
    public float Range;
    public int Damage;

    private bool canAttack;

    void Start() {
        MaxRange = 15;
        Damage = 60;
        canAttack = false;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire1")) {
            GetComponent<Animation>().Play();
            //ShootWeapon();
        }
    }

    void ShootWeapon() {
        RaycastHit hitRay;
        Transform CameraTransform = MainCamera.transform;

        Instantiate(shootSound, gameObject.transform.position, gameObject.transform.rotation);

        if (Physics.Raycast(CameraTransform.position, CameraTransform.TransformDirection(Vector3.forward), out hitRay)) {
            Range = hitRay.distance;
            if (hitRay.collider.tag == "Enemy" && hitRay.distance<MaxRange) {
                hitRay.transform.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);

                Quaternion prefabRot = Quaternion.FromToRotation(Vector3.up, hitRay.normal);
                Instantiate(bloodParticle, hitRay.point, prefabRot);
            }
        }
    }
}
