using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]

public class Weapon : MonoBehaviour
{
    [SerializeField] Bullet _prefab;
    [SerializeField] float _attackSpeed;
    [SerializeField] float _bulletSpeed;

    private ObjectPool<Bullet> _pool;
    private Rigidbody _rigidbody;

    bool isWork = true;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (bullet) => ActivateOnGet(bullet),
            actionOnRelease: (bullet) => bullet.gameObject.SetActive(false),
            actionOnDestroy: (bullet) => Destroy(bullet.gameObject),
            collectionCheck: true);            
    }
            
    void Start()                
    {
        StartCoroutine(Shot());
        _rigidbody = GetComponent<Rigidbody>();     
    }

    IEnumerator Shot()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_attackSpeed);

        while (isWork)
        {            
            yield return waitForSeconds;
            _pool.Get();
        }       
    }

    private void ActivateOnGet(Bullet bullet)
    {
        _rigidbody = bullet.GetComponent<Rigidbody>();
        bullet.gameObject.SetActive(true);      
        bullet.BulletAction += ReturnToPool;
        bullet.transform.position = transform.position;
        _rigidbody.velocity = transform.position * _bulletSpeed;      
    }

    private void ReturnToPool(Bullet bullet)
    {
        bullet.BulletAction -= ReturnToPool;
        _pool.Release(bullet);
    }
}
