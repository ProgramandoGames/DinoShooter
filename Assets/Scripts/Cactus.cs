using UnityEngine;

public class Cactus : MonoBehaviour {

    public float speed = 4;

    void Start() {
        
    }

    void Update() {

        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x <= -5) {
            Destroy(gameObject);
        }

    }

}
