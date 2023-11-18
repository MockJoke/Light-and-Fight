using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Gameplay : MonoBehaviour
{
    [SerializeField] private Button restartBtn;
    [SerializeField] public Button tipsBtn;
    [SerializeField] private GameObject gamePlayScreen; 
    [SerializeField] private GameObject controlsScreen; 

    // Start is called before the first frame update
    void Start()
    {
        restartBtn.onClick.AddListener(onClickRestartBtn);
        tipsBtn.onClick.AddListener(onClickTipsBtn);
    }

    void onClickRestartBtn()
    {
        SceneManager.LoadScene(0); 
    }

    void onClickTipsBtn()
    {
        controlsScreen.SetActive(true);
        gamePlayScreen.SetActive(false);
    }
}
