using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed = 1f;
    public float rotSpeed = 60f;
    float newRoty = -90;
    void Update()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        float newZ = transform.position.z;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            newZ = transform.position.z + speed * Time.deltaTime;
            newRoty = -90;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newZ = transform.position.z - speed * Time.deltaTime;
            newRoty = 90;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newX = transform.position.x - speed * Time.deltaTime;
            newRoty = 180;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newX = transform.position.x + speed * Time.deltaTime;
            newRoty = 0;
        }
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newRoty, 0), transform.rotation, rotSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, newY, newZ);

    }

}
