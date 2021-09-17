using UnityEngine;
using UnityEngine.UI;

public class CreatorsScreen : Screen
{
    [SerializeField] private Button _screenButton;
    [SerializeField] private Animator _creatorsScreenAnimation;

    private const string _animationParameterName = "IsOpen";

    private void OnEnable()
    {
        _screenButton.onClick.AddListener(CloseScreen);
    }

    private void OnDisable()
    {
        _screenButton.onClick.RemoveListener(CloseScreen);
    }

    public override void OpenScreen()
    {
        PlayAnimation(true);
    }

    public override void CloseScreen()
    {
        PlayAnimation(false);
    }

    private void PlayAnimation(bool condition)
    {
        _creatorsScreenAnimation.SetBool(_animationParameterName, condition);
    }
}
