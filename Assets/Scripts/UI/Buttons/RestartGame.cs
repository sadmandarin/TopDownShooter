using UnityEngine.SceneManagement;

public class RestartGame : BaseButton
{
    protected override void ClickButton()
    {
        SceneManager.LoadScene(1);
    }
}
