using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Action<Bullet> BulletAction;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Weapon>(out Weapon _)) { }
        else
            BulletAction?.Invoke(this);
    }
}
