using UnityEngine;

[RequireComponent(typeof(Player))]

public class NPCPatrul : MonoBehaviour
{
    [SerializeField] private Transform[] _allPlacesPoint;

    private Transform _target;
    private Player _player;

    private int _numberPoint;

    private void Start()
    {
        _player = GetComponent<Player>();
        _target = _allPlacesPoint[_numberPoint];
    }

    private void Update()
    {
        Vector3 targetPoint = _target.position;
        Vector3 direction = (targetPoint - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _player.Speed);

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _player.Speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        _numberPoint++;

        if (_numberPoint == _allPlacesPoint.Length)
            _numberPoint = 0;

        _target = _allPlacesPoint[_numberPoint].transform;
    }
}
