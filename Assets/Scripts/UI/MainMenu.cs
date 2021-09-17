using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Screen
{
    [SerializeField] private CreatorsScreen _creatorsScreen;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _creatorsButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        GetSceneLoader();
        OpenScreen();
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _creatorsButton.onClick.AddListener(OnCreatorsButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _creatorsButton.onClick.RemoveListener(OnCreatorsButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnPlayButtonClick()
    {
        _sceneLoader.LoadScene(SceneLoader._startingLevelSceneName);
    }

    private void OnCreatorsButtonClick()
    {
        _creatorsScreen.OpenScreen();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    public override void OpenScreen()
    {
        Time.timeScale = 1;
    }
}
