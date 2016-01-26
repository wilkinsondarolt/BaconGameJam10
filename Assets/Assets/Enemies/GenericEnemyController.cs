using UnityEngine;
using System.Collections;

public class GenericEnemyController : MonoBehaviour {
    // Local declarations    

    // Properties
    private GameController GmController;
    public  float Speed = 0.10f;
    private int ScorePoints = 1;
    public  int Hitpoints = 10;
    private bool FireResist = false;
    private bool WaterResist = false;

    public GameObject WaterElement;
    public GameObject FireElement;

    void Start()
    {
        this.GmController = GameObject.FindObjectOfType<GameController>();
        this.ScorePoints  = this.Hitpoints;
        this.FireResist   = false;
        this.WaterResist  = false;
        GameObject Element = null;
        // Fireproof
        if (Random.Range(1, 3) == 1)
        {
            this.FireResist  = true;
            Element = Instantiate<GameObject>(WaterElement);
        }
        else
        {
            this.WaterResist = true;
            Element = Instantiate<GameObject>(FireElement);
        }
        Element.transform.position = new Vector3(this.transform.position.x,
                                                 this.transform.position.y + 1.0f,
                                                 this.transform.position.z);
        Element.transform.SetParent(this.transform);
    }

    void Update()
    {
        if (this.Hitpoints <= 0)
        {
            GmController.Score += this.ScorePoints;
            Destroy(this.gameObject);
            AudioSource Audio = this.GmController.GetComponent<AudioSource>();
        }
    }

    void FixedUpdate()
    {
        // Make the enemies move a little bit
        float lfMove = 0.0f;
        if (this.transform.position.x > 0)
            lfMove = Speed * -1;
        else
            lfMove = Speed;
        this.transform.Translate(new Vector3(lfMove, 0.0f, 0.0f));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        bool FireSpell  = (other.tag == "FireSpell");
        bool WaterSpell = (other.tag == "WaterSpell");
        if (WaterSpell || FireSpell)
        {
            if ((!this.FireResist) && FireSpell)
                this.Hitpoints -= 1;
            if ((!this.WaterResist) && WaterSpell)
                this.Hitpoints -= 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("LastRunScore", this.GmController.Score);
            Application.LoadLevel("GameOver");
        }        
    }
}
