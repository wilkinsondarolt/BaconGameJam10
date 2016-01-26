using UnityEngine;
using System.Collections;

public class StartButtonController : MonoBehaviour {

    public void IniciaJogo()
    {
        Application.LoadLevel("Main");

    }

    public void FechaJogo()
    {
        Application.Quit();

    }
}
