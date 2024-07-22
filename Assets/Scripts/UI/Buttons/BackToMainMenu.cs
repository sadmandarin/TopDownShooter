using UnityEngine.SceneManagement;

public class BackToMainMenu : BaseButton
{
    protected override void ClickButton()
    {
        SceneManager.LoadScene(0);
    }
}
