using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public Camera _camera;

    public GameObject cube;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 point = new Vector3(
            _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float hitX = hit.collider.gameObject.transform.position.x;
                float hitY = hit.collider.gameObject.transform.position.y;
                float hitZ = hit.collider.gameObject.transform.position.z;
                GameObject temp = Instantiate(cube);
                temp.transform.position = new Vector3(hitX, hitY + 1, hitZ);
                Debug.Log(temp.transform.position);
            }
        }
    }
}
