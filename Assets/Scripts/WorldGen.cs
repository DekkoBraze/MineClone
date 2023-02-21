using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{

    public GameObject cube;

    void Start()
    {
        for (int i = -10; i < 10; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                GameObject temp = Instantiate(cube);
                temp.transform.position = new Vector3(i, 0, j);
            }
        }
    }
}
