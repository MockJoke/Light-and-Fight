using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class Gameplay : MonoBehaviour
{
    public Button restartBtn; 
    private Button pauseBtn;
    public Button tipsBtn;
    [SerializeField] private GameObject controlsScreen; 

    // Start is called before the first frame update
    void Start()
    {
        restartBtn.onClick.AddListener(onClickRestartBtn);
        tipsBtn.onClick.AddListener(onClickTipsBtn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onClickRestartBtn()
    {
        SceneManager.LoadScene(0); 
    }

    void onClickTipsBtn()
    {
        GameObject gameScreen = GameObject.Find("GameScreen");
        controlsScreen.SetActive(true);
        gameScreen.SetActive(false);
    }
}
