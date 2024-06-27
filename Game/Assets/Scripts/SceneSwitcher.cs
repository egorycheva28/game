using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneSwitcher : MonoBehaviour
{
    public int SceneNumber;
    public void Transition()
    {
        SceneManager.LoadScene(SceneNumber);
    }

}
 