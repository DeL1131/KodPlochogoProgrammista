using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed { get; private set; }

    private void Start()
    {
        Speed = _speed;
    }
}
