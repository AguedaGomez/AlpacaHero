using UnityEngine;
using System.Collections;

public class LoadOnCLick : MonoBehaviour {

	public void LoadScene()
    {
        Application.LoadLevel(1);
    }

    public void CloseGame() {
        Application.Quit();
    }
}
