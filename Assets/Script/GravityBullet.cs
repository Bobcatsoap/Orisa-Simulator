using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GravityBullet : MonoBehaviour {
    [HideInInspector]
    public float gravityDistance;
    [HideInInspector]
    public float gravity;
    [HideInInspector]
    public GameObject gravityLine;
    GameObject player;
    bool collided;
    Collider[] nearbyCollider;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<FirstPersonController>().gameObject;
        //忽略玩家碰撞
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }
	
	// Update is called once per frame
	void Update () {
        nearbyCollider = Physics.OverlapSphere(transform.position,gravityDistance);

        DrawLine();

        //子弹销毁
        if (Vector3.Distance(transform.position, player.transform.position) >= 100)
        {
            Destroy(gameObject);
        }
        
        //子弹爆炸
        if (Input.GetMouseButtonDown(1))
        {
            if (!collided)
            {
                CreateGravity();
            }
        }

	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(GetComponent<Rigidbody>());
        collided = true;
        CreateGravity();
        Destroy(gameObject);
    }

    void CreateGravity()
    {
        if (nearbyCollider!=null)
        {
            foreach (var item in nearbyCollider)
            {
                if(item.tag=="scene decoration")
                    if (Vector3.Distance(item.transform.position, transform.position) <= gravityDistance)
                        item.GetComponent<Rigidbody>().velocity = (transform.position - item.transform.position).normalized * gravity / item.GetComponent<Rigidbody>().mass;
            }

            Destroy(gameObject);

            foreach (var item in GameObject.FindGameObjectsWithTag("gravity line"))
                Destroy(item);

        }
    }

    void DrawLine()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "gravity line")
                Destroy(child.gameObject);
        }
        if (nearbyCollider != null)
        {
            for (int i = 0; i < nearbyCollider.Length; i++)
            {
                if (nearbyCollider[i].gameObject.tag == "scene decoration")
                    if (Vector3.Distance(nearbyCollider[i].transform.position, transform.position) <= gravityDistance)
                    {
                        //Debug.DrawLine(nearbyCollider[i].transform.position, transform.position);
                        GameObject line = Instantiate(gravityLine);
                        line.tag = "gravity line";
                        line.transform.SetParent(transform);
                        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
                        lineRenderer.positionCount = 2;
                        lineRenderer.SetPosition(0, nearbyCollider[i].transform.position);
                        lineRenderer.SetPosition(1, transform.position);
                        lineRenderer.useWorldSpace = true;
                    }
            }
        }
        
    }
}
