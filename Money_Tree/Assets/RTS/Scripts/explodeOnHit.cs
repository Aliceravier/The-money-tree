using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeOnHit : MonoBehaviour {

    public GameObject Particle;

    public Team team = Team.player;

    public float timeTillParticleDestruction = 1f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if (health == null)
        {
            Destroy(this.gameObject);
        }
        else if(health.team != team) {        
            int nbParticles = 3;
            for (int i = 0; i < nbParticles; i++)
            {
                GameObject newParticle = Object.Instantiate(Particle, this.transform.position, Quaternion.identity);
                newParticle.transform.Rotate(new Vector3(Random.value, Random.value, Random.value));
                newParticle.GetComponent<Rigidbody>().velocity = newParticle.transform.forward;
                newParticle.AddComponent<destroyAfterTime>();
                newParticle.GetComponent<destroyAfterTime>().timeTillDestruction = timeTillParticleDestruction;
            }
        }
    }
}
