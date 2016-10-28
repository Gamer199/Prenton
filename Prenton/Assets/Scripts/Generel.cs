using UnityEngine;
using UnityEngine.SceneManagement;

public class Generel : MonoBehaviour {

    /*public static int currentScore = 0;
    public float offsetY = 40;
    public float sizeX = 100;
    public float sizeY = 40;*/

    void Start () {
        //currentScore = 0;
	}
	
	void Update () {
 
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }

    /*void OnGUI()
    {
        GUI.Box(new Rect(Screen.width / 2 - sizeX / 2, offsetY, sizeX, sizeY), "Score: " + currentScore);
    }*/
}
