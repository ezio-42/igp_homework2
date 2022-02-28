using UnityEngine;

public class Bullet : MonoBehaviour {
    public LayerMask destroyLayerMask;
    public LayerMask radgollLayerMask;

    private void OnCollisionExit(Collision other) {
        var destroyable = other.gameObject.GetComponent<Destroyable>();
        if (destroyable == null) return;

        if ((destroyLayerMask.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer) {
            Destroy(other.gameObject);
        }
        else if ((radgollLayerMask.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer) {
            other.gameObject.GetComponent<Radgoll>().ToggleRadgoll();
        }
    }
}