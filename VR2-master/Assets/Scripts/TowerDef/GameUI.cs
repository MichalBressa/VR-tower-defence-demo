using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{ 
    public GameObject canvas;

    public Camera camera;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.back, camera.transform.rotation * Vector3.up);

    }

    public void Hide()
    {
        canvas.SetActive(false);
    }
}
