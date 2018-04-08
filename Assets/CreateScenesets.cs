using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScenesets : MonoBehaviour {
    public GameObject sceneSet;
    [Range(0,100)]
    public float sceneSetPercent;
    public float createRadius;
	// Use this for initialization
	void Start () {
        float createArea = Mathf.PI * createRadius * createRadius;
        print("createArea:" + createArea);
        float canContainedSets = createArea / sceneSet.transform.localScale.x;
        print("canContainedSets:" + canContainedSets);
        float createSetsCount = sceneSetPercent/100 * canContainedSets;
        print("createSetsCount:" + createSetsCount);
        for (int i = 0; i < createSetsCount; i++)
        {
            GameObject set = Instantiate(sceneSet);
            set.transform.position = transform.position + Vector3.forward * Random.Range(-createRadius, createRadius);
            set.transform.RotateAround(transform.position, transform.up,Random.Range(0, 360));
            set.transform.SetParent(gameObject.transform);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
