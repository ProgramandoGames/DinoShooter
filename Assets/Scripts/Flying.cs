using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{

    public ParticleSystem explosionPrefab;

    float speed = 4;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        Collider2D box = Physics2D.OverlapBox(transform.position, Vector2.one * 0.2f, 0, LayerMask.GetMask("Shot"));
        if(box != null) {

            Destroy(Instantiate(explosionPrefab, transform.position, Quaternion.identity), 2);

            Destroy(box.gameObject);
            Destroy(gameObject);
        }

        if (transform.position.x <= -5) {
            Destroy(gameObject);

        }
    }
}










