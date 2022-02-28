using UnityEngine;


public class Destroyable : MonoBehaviour {
    public float destroyY = -50f;
    
    void Update() {
        if (transform.position.y < destroyY) {
            Destroy(gameObject);
        }
    }
}
