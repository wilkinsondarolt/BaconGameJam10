using UnityEngine;
using UnityEngine.UI;

public class GameOverScoreText : MonoBehaviour {

	void Start () {
        string score = PlayerPrefs.GetInt("LastRunScore").ToString();
        while (score.Length < 6)
        {
            score = '0' + score;

        }
        this.GetComponent<Text>().text = score;
	}
}
