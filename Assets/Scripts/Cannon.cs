using UnityEngine;

public class Cannon : MonoBehaviour {
    private float _angleOfView;
    public GameObject bulletStartPositionObject;
    private Vector3 _bulletStartPosition;
    public float cooldown = 1f;
    public float bulletInitialVelocityY = 1f;
    private Vector3 _bulletInitialVelocity;
    private float _lastShootTime;
    public GameObject bulletPrefab;

    void Start() {
        _angleOfView = transform.rotation.x;
        _bulletStartPosition = bulletStartPositionObject.transform.position;
        _bulletInitialVelocity = new Vector3(0, bulletInitialVelocityY, bulletInitialVelocityY / Mathf.Tan(_angleOfView));
    }

    void Update() {
        if (_lastShootTime + cooldown <= Time.time) {
            _Shoot();
            _lastShootTime = Time.time;
        }
    }

    void _Shoot() {
        var bullet = Instantiate(bulletPrefab, _bulletStartPosition, Quaternion.identity);
        var bulletRigidBody = bullet.GetComponent<Rigidbody>();
        bulletRigidBody.AddForce(_bulletInitialVelocity, ForceMode.Impulse);
    }
}