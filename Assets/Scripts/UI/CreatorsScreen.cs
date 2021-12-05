using UnityEngine;
using UnityEngine.UI;

public class CreatorsScreen : Screen
{
    [SerializeField] private Button _screenButton;
    [SerializeField] private Animator _creatorsScreenAnimation;

    private const string _animationParameterName = "IsOpen";

    private void OnEnable()
    {
        _screenButton.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _screenButton.onClick.RemoveListener(Close);
    }

    public override void Open()
    {
        PlayAnimation(true);
    }

    public override void Close()
    {
        PlayAnimation(false);
    }

    private void PlayAnimation(bool condition)
    {
        _creatorsScreenAnimation.SetBool(_animationParameterName, condition);
    }
}
