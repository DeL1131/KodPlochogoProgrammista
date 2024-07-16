using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] private float _speed;
    [SerializeField] float _attackSpeed;

    private Transform _target;

    private bool _isWork = true;

    void Start()
    {
        StartCoroutine(_shootingWorker());
    }

    IEnumerator _shootingWorker()
    {
        while (_isWork)
        {

            Vector3 direction = (_target.position - transform.position).normalized;
            GameObject NewBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = direction;
            NewBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return new WaitForSeconds(_attackSpeed);
        }


    }
}
