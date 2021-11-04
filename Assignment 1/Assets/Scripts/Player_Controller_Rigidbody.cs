using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_Rigidbody : MonoBehaviour
{
    public float speed = 1f;
    public float rotSpeed = 50f;
    public float gunPower = 15f;
    public float gunCooldown = 2f;
    public float gunCooldownCount = 0;
    public bool hasGun = false;
    public GameObject prefabBullet;
    public Transform GunPosition;
    Rigidbody rb;
    float newRoty = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(speed, 0, 0, ForceMode.VelocityChange);
            newRoty = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-speed, 0, 0, ForceMode.VelocityChange);
            newRoty = 180;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(0, 0, speed, ForceMode.VelocityChange);
            newRoty = -90;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(0, 0, -speed, ForceMode.VelocityChange);
            newRoty = 90;
        }
        gunCooldownCount += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && hasGun && gunCooldownCount >= gunCooldown)
        {
            gunCooldownCount = 0;
            GameObject bullet = Instantiate(prefabBullet, GunPosition.position, GunPosition.rotation);
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 15f, ForceMode.Impulse);
            Rigidbody bRb = bullet.GetComponent<Rigidbody>();
            bRb.AddForce(transform.forward * gunPower, ForceMode.Impulse);
            Destroy(bullet, 2f);
        }
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, newRoty, 0), transform.rotation, rotSpeed * Time.deltaTime);
    } 
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
        }
    } 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Gun")
        {
            print("Better than nothing!");
            Destroy(other.gameObject);
            hasGun = true;
        }
    }
}
