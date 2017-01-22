using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUp : MonoBehaviour {
    
	public ParticleSystem dissaperParticle;
    [SerializeField]
    private GameObject goods;
	// Use this for initialization
	void Awake () {
        dissaperParticle = gameObject.transform.FindChild("dissaperParticle").GetComponent<ParticleSystem>();
        dissaperParticle.enableEmission = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "player")
        {
            goods.SetActive(false);
            this.gameObject.GetComponent<Collider>().enabled = false;
            //Invoke("dissaper", 0);
            dissaperParticle.enableEmission = true;
            StartCoroutine(dissaperE());

        }
    }

    IEnumerator dissaperE()
    {
        yield return new WaitForSeconds(0.3f);
        Invoke("dissaper", 0);
    }

    void dissaper() {
        dissaperParticle.enableEmission = false;
        Invoke("Destroy",2f);
        
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}

       // else if (col.name.Split('(')[0] == "Blocker2")
      //  {
      //      transform.position = new Vector3(-3.87f, 0.69f, -2.78f);
      //  }