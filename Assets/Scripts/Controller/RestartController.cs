using UnityEngine.SceneManagement;
using UnityEngine;


public class RestartController : MonoBehaviour {

	
    public void Restart(int scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
