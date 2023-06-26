using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] Pages pages;
    [SerializeField] float startingAnimationSpeed;
    void Start()
    {
        startingAnimation();
    }
    void startingAnimation()
    {
        CanvasGroup logo = pages.splashScreen.transform.GetChild(1).GetComponent<CanvasGroup>();

        logo.alpha = 0;
        LeanTween.alphaCanvas(logo, 1, startingAnimationSpeed).setOnComplete(OpennextPage);
    }

    void OpennextPage()
    {
        pages.splashScreen.SetActive(false);
        pages.readMe.SetActive(true);
    }
}



