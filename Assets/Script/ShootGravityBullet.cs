using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGravityBullet : MonoBehaviour {

    public float coolDownTime;
    public float bulletSpeed=20;
    public float gravity;
    public float gravityDistance;
    public GameObject gravityBullet;
    public Image coolDownIcon;
    public GameObject GravityLine;
    float lastUseTime;
    bool coolingDown;

	// Use this for initialization
	void Start () {
        lastUseTime = Time.time - coolDownTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastUseTime >= coolDownTime)
        {
            coolingDown = false;
            coolDownIcon.fillAmount = 1;

            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(gravityBullet);
                GameObject camera = FindObjectOfType<Camera>().gameObject;
                bullet.transform.position = camera.transform.position+ camera.transform.forward *1.5f;
                bullet.GetComponent<Rigidbody>().velocity= camera.gameObject.transform.forward * bulletSpeed;
                bullet.GetComponent<GravityBullet>().gravity = gravity;
                bullet.GetComponent<GravityBullet>().gravityDistance = gravityDistance;
                bullet.GetComponent<GravityBullet>().gravityLine = GravityLine;
                lastUseTime = Time.time;
                coolingDown = true;
                coolDownIcon.fillAmount = 0;
            }
        }

        if (coolingDown)
        {
            coolDownIcon.fillAmount += (float)1 / coolDownTime * Time.deltaTime;
        }

        print(coolingDown);
	}
}
