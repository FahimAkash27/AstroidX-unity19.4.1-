using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper_My : MonoBehaviour
{
    float leftConstraint;
    float rightConstraint;
    float bottomConstraint;
    float topConstraint;
    float buffer = 1.0f;
    Camera camera;
    float distanceZ;
    public  bool screenWrappered;

    public static ScreenWrapper_My SwM;

    private void Awake()
    {
        SwM = this;
    }
    void Start()
    {
        screenWrappered = false;
        camera = Camera.main;
        distanceZ = Mathf.Abs(camera.transform.position.z + transform.position.z);
        leftConstraint = camera.ScreenToWorldPoint(
                          new Vector3(0f, 0f, distanceZ)).x;
        rightConstraint = camera.ScreenToWorldPoint(
                          new Vector3(Screen.width, 0f, distanceZ)).x;
        bottomConstraint = camera.ScreenToWorldPoint(
                          new Vector3(0f, 0f, distanceZ)).y;
        topConstraint = camera.ScreenToWorldPoint(
                          new Vector3(0f, Screen.height, distanceZ)).x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(transform.position.x < leftConstraint - buffer)
        {
            transform.position = new Vector3(
                rightConstraint - .10f, transform.position.y,
                transform.position.z);
            screenWrappered = true;
        }
        if (transform.position.x > rightConstraint)
        {
            transform.position = new Vector3(
                leftConstraint + 0.10f, transform.position.y,
                transform.position.z);
            screenWrappered = true;
        }
        if (transform.position.y > (bottomConstraint * -1))
        {
            transform.position = new Vector3(
                transform.position.x, bottomConstraint + 0.10f,
                transform.position.z);
            screenWrappered = true;
        }
        if (transform.position.y < bottomConstraint)
        {
            transform.position = new Vector3(
                transform.position.x, ((bottomConstraint * -1)),
                transform.position.z);
            screenWrappered = true;
        }
    }
}
