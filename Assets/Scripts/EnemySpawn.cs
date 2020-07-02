
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    struct SpawnTime {
        public float instantiateTime;
        public float interval;
        public float variation;
    }

    public Sprite[] cactusSprites;

    public GameObject cactusPrefabRef;
    public GameObject flyingPrefabRef;

    SpawnTime cactus;
    SpawnTime flying;

    public bool stopSpawn = false;

    float flyingMax = 2;
    float flyingMin = -1;

    public float speed = 4;

    void Start() {

        cactus.instantiateTime = 0;
        cactus.interval = 2;
        cactus.variation = 0.5f;

        flying.instantiateTime = 0;
        flying.interval = 0.7f;
        flying.variation = 0.5f;

    }

    void Update() {

        // spawn cactus
        if(Time.time > cactus.instantiateTime && !stopSpawn) {
            GameObject obj = Instantiate(cactusPrefabRef, new Vector3(5, -0.9f), Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = cactusSprites[Random.Range(0, cactusSprites.Length)];
            obj.AddComponent<BoxCollider2D>();
            obj.GetComponent<Cactus>().speed = speed;
            cactus.instantiateTime = Time.time + Random.Range(cactus.interval - cactus.variation, cactus.interval + cactus.variation);
        }

        // spawn flying
        if (Time.time > flying.instantiateTime && !stopSpawn) {
            GameObject obj = Instantiate(flyingPrefabRef, new Vector3(5, Random.Range(flyingMax, flyingMin)), Quaternion.identity);
            flying.instantiateTime = Time.time + Random.Range(flying.interval - flying.variation, flying.interval + flying.variation);
        }

    }
}
