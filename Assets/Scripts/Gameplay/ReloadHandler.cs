using UnityEngine;
using UnityEngine.SceneManagement; 

public class ReloadHandler : MonoBehaviour
{
    public void OnClickReload()
    {
        SceneManager.LoadScene(0);
    }
}
