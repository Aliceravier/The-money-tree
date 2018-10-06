using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeOnHit : MonoBehaviour {

    public GameObject Particle;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        int nbParticles = 3;
        for (int i = 0; i < nbParticles; i++)
        {
            GameObject newParticle = Object.Instantiate(Particle, this.transform.position, Quaternion.identity);
            newParticle.transform.Rotate(new Vector3(Random.value, Random.value, Random.value));
            newParticle.GetComponent<Rigidbody>().velocity = newParticle.transform.forward;
        }
    }
}
