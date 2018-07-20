using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBall : MonoBehaviour {

    const float ARRIVE_DISTANCE = 0.2f;
    // [SerializeField] для отображения в инспекторе
    public float MovementSpeed = 3;

    private Camera _camera;
    private Vector3 _destination;
    private bool _isMoving = false;

	// Use this for initialization
	void Start () {
        _camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        var ray = _camera.ScreenPointToRay(Input.mousePosition); // от камеры до точки щелчка
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, color: Color.cyan); // отладка origin - start point, direction, color

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit, 100)) // out выходной параметр
            {
                Debug.Log(hit.collider.CompareTag("Terrain"));
                if (hit.collider.CompareTag("Terrain"))
                {
                    Debug.Log("HIT.POINT = " + hit.point);
                    _destination = hit.point;
                    _destination.y = transform.position.y;
                    Debug.Log("DESTINATION = " + _destination);
                    _isMoving = true;
                }
            }
        }

        WalkToDestination();
    }
    
    void WalkToDestination()
    {
        if (_isMoving == false)
            return;
        
        if (Vector3.Distance(transform.position, _destination) > ARRIVE_DISTANCE)
        {
            var step = MovementSpeed * Time.deltaTime; // deltaTime calculating from fps
            transform.position = Vector3.MoveTowards(transform.position, _destination, step);
        }
        else
        {
            _isMoving = false;
        }
    }
}
