using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
    public Font FontToUse;
    public List<Sprite> Imagens;

    void Start()
    {
        Image Texto = this.GetComponent<Image>();
        Texto.sprite = Imagens[Random.Range(0, Imagens.Count)];
    }

    void OnGUI()
    {
        GUI.skin.font = FontToUse;
        //GUI.skin.fontSize = 35;
    }
}
