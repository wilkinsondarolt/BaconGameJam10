using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private float AtkWaitTime = 0.25f;
    private bool CanAttack = true;
    private bool FacingRight = true;
    private string SelectedSpell = "F";
    private float Timeout = 0.0f;
    private Animator Anim;

    public GameObject WaterSpell;
    public GameObject FireSpell;
    public AudioClip  FireSound;
    public AudioClip  WaterSound;

    void BlockAttack()
    {
        this.CanAttack = false;
        Invoke("ReleaseCanAttack", AtkWaitTime);
    }

    void ReleaseCanAttack()
    {
        this.CanAttack = true;
    }

    void SetTimeOut()
    {
        this.Timeout = 400.0f;
    }

    void Start()
    {
        this.Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.FacingRight = true;
            if (CanAttack)
            {
                this.SetTimeOut();
                this.BlockAttack();
                this.SpellSling();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.FacingRight = false;
            if (CanAttack)
            {
                this.SetTimeOut();
                this.BlockAttack();
                this.SpellSling();
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SelectedSpell = "F";            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SelectedSpell = "W";
        }
    }

    void SpellSling()
    {
        // Criar o projetil
        GameObject Spell = null;
        if (this.SelectedSpell == "W")
        {
            Spell = Instantiate<GameObject>(WaterSpell);
            this.GetComponent<AudioSource>().PlayOneShot(WaterSound);
        }
        else if (this.SelectedSpell == "F")
        {
            Spell = Instantiate<GameObject>(FireSpell);
            this.GetComponent<AudioSource>().PlayOneShot(FireSound);
        }

        // Configura a posiçao inicial do projetil
        float xMod = 0;
        if (this.FacingRight)
            xMod = 1;
        else
            xMod = -1;
        Spell.transform.position = new Vector3(this.transform.position.x + (1.0f * xMod),
                                               this.transform.position.y,
                                               this.transform.position.z);        
    }

    void FixedUpdate()
    {
        // Controls the animation for attacks and to stand idle
        if (Timeout >= 0)
            Timeout = Timeout - 50f;
        Anim.SetBool("FacingRight", this.FacingRight);
        Anim.SetFloat("Timeout", this.Timeout);
    }        
}
