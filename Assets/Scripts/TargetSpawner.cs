using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {
    private float _lastSpawnTime;
    private Bounds _bounds;
    public List<GameObject> prefabsToSpawn;
    private System.Random _random;
    private float _cooldown;

    private float _randomCooldown() {
        return (float) _random.Next(5, 10) / 10;
    }

    void Start() {
        _bounds = GetComponent<Collider>().bounds;
        _random = new System.Random();
        _cooldown = _randomCooldown();
    }

    void Update() {
        if (_lastSpawnTime + _cooldown <= Time.time) {
            _Spawn();
            _lastSpawnTime = Time.time;
            _cooldown = _randomCooldown();
        }
    }

    private void _Spawn() {
        var spawnedPrefab = Instantiate(
            prefabsToSpawn[_random.Next(prefabsToSpawn.Count)],
            RandomPointBelowBox(),
            Quaternion.identity
        );
    }

    private Vector3 RandomPointBelowBox() {
        return _bounds.center + new Vector3(
            (Random.value - 0.5f) * _bounds.size.x,
            (Random.value - 0.5f) * _bounds.size.y - 1,
            (Random.value - 0.5f) * _bounds.size.z
        );
    }
}