using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    [SerializeField] private float cubeTime;
    [SerializeField] private Camera camera;
 
    private GameObject cube;
    private float _timeLeft;
    private bool _timerOn = false;

    private void Start()
    {
        cube = Manager.link.cube;
        _timeLeft = cubeTime;
    }

    private void FixedUpdate()
    {
        if (!_timerOn && Input.GetMouseButton(1))
        {
            Ray ray = Ray();
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 cubePos = new Vector3(0, 50000, 0);
                Vector3 boxSize = new Vector3(0.25f, 0.25f, 0.25f);
                Collider []hitColliders = Physics.OverlapBox(cubePos, boxSize);
                if (hitColliders.Length == 0 && hit.distance < 3)
                {
                    GameObject newCube = Instantiate(cube, hit.collider.gameObject.transform.TransformPoint(cubePos), cube.transform.rotation);
                    _timerOn = true;
                }
            }
        }
        if (!_timerOn && Input.GetMouseButton(0))
        {
            Ray ray = Ray();
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.distance < 3)
                {
                    Destroy(hit.collider.gameObject.transform.parent.gameObject);
                    _timerOn = true;
                }
            }
        }
    }

    private void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
            }
            else
            {
                _timeLeft = cubeTime;
                _timerOn = false;
            }
        }
    }

    private Ray Ray()
    {
        Vector3 point = new Vector3(
            camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
        Ray ray = camera.ScreenPointToRay(point);
        return ray;
    }
}
