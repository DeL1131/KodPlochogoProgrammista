using UnityEngine;

public class PatrolController : MonoBehaviour
{
    private Transform _allPlacespoint;
    private Transform[] _arrayPlaces;

    private int _numberOfPlace;
    private float _speed;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacespoint.childCount];

        for (int i = 0; i < _arrayPlaces.Length; i++)
            _arrayPlaces[i] = _allPlacespoint.GetChild(i);
    }

    private void Update()
    {
        Transform target = _arrayPlaces[_numberOfPlace];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
            SelectNextPlace();
    }

    private void SelectNextPlace()
    {
        _numberOfPlace = (_numberOfPlace++) % _arrayPlaces.Length;

        Vector3 target = _arrayPlaces[_numberOfPlace].transform.position;
        transform.forward = target - transform.position;
    }
}