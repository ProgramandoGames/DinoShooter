using UnityEngine;

public class Gun : MonoBehaviour
{

    public ParticleSystem muzzleFlash;
    public ParticleSystem capsules;

    Camera cam;

    public GameObject shotSpawn;
    public GameObject shot;

    float shotInterval = 0.1f;
    float shotInstantiateTime = 0;

    void Start()
    {
        cam = Camera.main;
        muzzleFlash.Stop();
        capsules.Stop();
    }

    void Update()
    {

        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.right = (mousePosition - (Vector2)transform.position).normalized;

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            muzzleFlash.Play();
            capsules.Play();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            muzzleFlash.Stop();
            capsules.Stop();
        }

        // input tiro
        if (Input.GetKey(KeyCode.Mouse0)) {
            // instancia tiro
            if (Time.time > shotInstantiateTime) {
                Instantiate(shot, shotSpawn.transform.position, transform.rotation);
                shotInstantiateTime = Time.time + shotInterval;
            }
        }

    }
}
