using UnityEngine;

public class Radgoll : MonoBehaviour {
    private Rigidbody[] _rigidbodies;
    
    private void Start() {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    public void ToggleRadgoll() {
        foreach (Rigidbody radgollBone in _rigidbodies) {
            radgollBone.isKinematic = true;
        }
    }
}
