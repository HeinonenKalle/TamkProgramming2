using UnityEngine;
using System.Collections;

public class FloorPart : MonoBehaviour {

    public float startingPoint;
    public float endPoint;
    private Vector3 _locationAtStart;
    private Vector3 _locationAtEnd;
    private float _startTime;
    private float _journeyLength;

    // Use this for initialization
    void Start () {
        _locationAtStart = transform.position;
        _locationAtEnd = new Vector3(_locationAtStart.x, _locationAtStart.y, endPoint);
        _journeyLength = Vector3.Distance(_locationAtStart, _locationAtEnd);
    }
	
	// Update is called once per frame
	void Update () {
        float distCovered = (Time.time - _startTime);
        float fracJourney = distCovered / _journeyLength;
        transform.position = Vector3.Lerp(_locationAtStart, _locationAtEnd, fracJourney);

        Vector3 _currentPosition = transform.position;

        if (_currentPosition.z <= endPoint)
        {
            Destroy(gameObject);
        }
    }
}
