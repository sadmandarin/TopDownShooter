using UnityEngine.SceneManagement;

public class StartGame : BaseButton
{
    protected override void ClickButton()
    {
        SceneManager.LoadScene(1);
    }
}
