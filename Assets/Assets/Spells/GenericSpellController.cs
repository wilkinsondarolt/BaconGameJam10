using UnityEngine;
using System.Collections;

public class GenericSpellController : MonoBehaviour {
    float Velocity = 0.15f;


	void Start ()
    {
        if (this.transform.position.x < 0)
        {
            this.Velocity *= -1;
            this.Flip();
        }
        Invoke("Fizzle", 1.0f);
    }

    void Fizzle()
    {
        Destroy(this.gameObject);
    }

    void Update ()
    {
        this.transform.Translate(new Vector3(this.Velocity, 0.0f, 0.0f));	
	}

    void Flip()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x * -1,
                                                this.transform.localScale.y,
                                                this.transform.localScale.z);
    }
}
