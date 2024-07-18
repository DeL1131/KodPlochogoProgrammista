using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Weapon : MonoBehaviour
{
    [SerializeField] Bullet _prefab;
    [SerializeField] private float _speed;
    [SerializeField] float _attackSpeed;

    private Transform _target;

    private bool _isWork = true;

    private void Start()
    {
        StartCoroutine(_shootingWorker());
    }

    private IEnumerator _shootingWorker()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_attackSpeed);

        while (_isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;                 
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return waitForSeconds;
        }
    }
}