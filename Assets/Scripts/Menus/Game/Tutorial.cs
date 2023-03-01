using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Tutorial : MonoBehaviour
{
    [SerializeField] [Range(5, 120)] private float delay = 0f;
    [SerializeField] [Range(1, 15)] private float duration = 0f;
    [SerializeField] private TMP_Text hintText;
    [SerializeField] private TMP_Text hintContinueText;
    [SerializeField] private Image background;
    [TextArea(3,10)]
    [SerializeField] private string[] hints;
    [TextArea(3,10)]
    [SerializeField] private string[] tutorialTexts;
    private int index;
    private int oldIndex;
    private string username;
    private bool returningPlayer;
    private int i = 0;
        private void Start()
        {
            returningPlayer = PlayerPrefs.GetBool("ReturningPlayer");
            username = PlayerPrefs.GetString("Username");
            tutorialTexts = new[]
            {
                "Welcome Guardian",
                $"{username}? What a nice name for a guardian!",
                "You can walk with WASD and look around with your mouse",
                "Also try clicking F5, that will transfer you to a view from above",
                "As you can see, there are some buildings that you can build by pressing their respective keys shown on the screen",
                "Though if you want to build a building, you need to have the required resources",
                "You can see your resources in the top right corner of the screen",
                "If you want to see what resources you need to build the building, you can click F1 to open a menu that will show you all the info",
                "You can also click F2, that will open a bestiary which will show you all the enemies you already encountered",
                "Your goal is to survive all the waves of enemies and don't let them destroy your fortress (the building you spawned at with the blue line)",
                "Enemies always spawn at the buildings with the red line",
                "If you want to see this tutorial again, you can reset it in the settings",
                "But now, let's get started!"
            };
            background.gameObject.SetActive(true);
            hintText.gameObject.SetActive(true);
            StartCoroutine(ShowTips());
        }

        private void Update()
        {
            TutorialFunc();
        }

        #region Tutorial
        private void TutorialFunc()
        {
          
            if (!returningPlayer)
            {
                hintContinueText.gameObject.SetActive(true);
                returningPlayer = PlayerPrefs.GetBool("ReturningPlayer");
                hintText.text = tutorialTexts[i];
                if (Input.GetKeyDown(KeyCode.X))
                {
                    i++;
                    hintText.text = tutorialTexts[i];
                    
                   
                }

                if (i == tutorialTexts.Length - 1)
                {
                    PlayerPrefs.SetBool("ReturningPlayer", true);
                    background.gameObject.SetActive(false);
                    hintText.gameObject.SetActive(false);
                    hintContinueText.gameObject.SetActive(false);
                    i = 0;
                    
                }
            }
        }
        #endregion Tutorial
    private IEnumerator ShowTips()
    {
        if (!returningPlayer)  yield return new WaitForSeconds(145);
        background.gameObject.SetActive(false);
        hintText.gameObject.SetActive(false);
        hintContinueText.gameObject.SetActive(false);
        if (PlayerPrefs.GetBool("Hints") == true)
        {
            yield return new WaitForSeconds(delay);
            background.gameObject.SetActive(true);
            hintText.gameObject.SetActive(true);
            hintContinueText.gameObject.SetActive(false);
            index = Random.Range(0, hints.Length - 1);
            oldIndex = index;
            #region Check if the same hint is displayed twice in a row
            if (index == oldIndex)
            { 
                index = Random.Range(0, hints.Length - 1);
                oldIndex = index;
            }
            #endregion
            hintText.text = hints[index];
            yield return new WaitForSeconds(duration);
            background.gameObject.SetActive(false);
            hintText.gameObject.SetActive(false);
            hintContinueText.gameObject.SetActive(false);
            StartCoroutine(ShowTips());
        }
       
        
    }

   
}
