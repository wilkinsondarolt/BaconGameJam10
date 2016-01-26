using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {
    private Text _ScoreText = null;
    private int _Score = 0;

    public int Score
    {
        get { return _Score; }
        set
        {
            _Score = value;
            _ScoreText.text = _Score.ToString();
        }
    }   

    void Start () {
        _ScoreText = GetComponent<Text>();
        this.Score = 0;
    }
	
	void Update () {
	
	}
}
