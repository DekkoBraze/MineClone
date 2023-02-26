using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager link;
    public GameObject cube;
    private bool curMode = false;

    private void Awake()
    {
        link = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Start()
    {
        WorldGen();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CursorChangeMode(curMode);
        }
    }

    private void WorldGen()
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

    private void CursorChangeMode(bool curMode)
    {
        curMode = !curMode;
        if (curMode)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
