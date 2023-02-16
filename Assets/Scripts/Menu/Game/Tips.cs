using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour
{
    [SerializeField] [Range(5, 120)] private float delay = 0f;
    [SerializeField] [Range(1, 15)] private float duration = 0f;
    [SerializeField] private TMP_Text hintText;
    [SerializeField] private Image background;
    [SerializeField] private string[] hints;
    private int index;
    private int oldIndex;
    private string username;
    private bool returningPlayer;
        private void Start()
        {
            background.gameObject.SetActive(true);
            hintText.gameObject.SetActive(true);
            username = PlayerPrefs.GetString("Username");
            StartCoroutine(WelcomeTutorial());
         
            StartCoroutine(ShowTips());
        }

        #region Tutorial
        private IEnumerator WelcomeTutorial()
        {
            returningPlayer = PlayerPrefs.GetBool("ReturningPlayer");
            if (!returningPlayer)
            {
                hintText.text = $"Welcome {username}";
                float delay = 4f;
                yield return new WaitForSeconds(delay);
                hintText.text = $"Thanks for playing Fortress Guardian";
                yield return new WaitForSeconds(delay);
                hintText.text = $"You can move with WASD and look around with your mouse";
                yield return new WaitForSeconds(delay);
                hintText.text = $"You can Select a building with alphanumeric keys and then press lmb to place it";
                yield return new WaitForSeconds(delay);
                hintText.text = $"You can also press the alphanumeric key again to cancel the placement";
                yield return new WaitForSeconds(delay);
                hintText.text = $"Press F1 if you want to see more information about buildings";
                yield return new WaitForSeconds(delay);
                hintText.text = $"You can also press F2 to see the controls";
                yield return new WaitForSeconds(delay);
                hintText.text = $"Press F3 to see your Bestiary";
                yield return new WaitForSeconds(delay);
                hintText.text = $"you can pause the game by pressing Escape";
                yield return new WaitForSeconds(delay);
                hintText.text = $"also you can start every round by pressing the L key on your keyboard";
                yield return new WaitForSeconds(delay);
                hintText.text = $"And you can also reset or disable this tutorial and tips in the options menu";
                yield return new WaitForSeconds(delay);
                hintText.text = $"Have fun and good luck on defending your fortress";
                yield return new WaitForSeconds(delay);
                returningPlayer = true;
                PlayerPrefs.SetBool("ReturningPlayer", true);
            }
        }
        #endregion Tutorial
    private IEnumerator ShowTips()
    {
        if (!returningPlayer)  yield return new WaitForSeconds(45);

            background.gameObject.SetActive(false);
        hintText.gameObject.SetActive(false);
        if (PlayerPrefs.GetBool("hints") == true)
        {
            yield return new WaitForSeconds(delay);
            background.gameObject.SetActive(true);
            hintText.gameObject.SetActive(true);
            index = Random.Range(0, hints.Length - 1);
            #region Check if the same hint is displayed twice in a row
            if (index == oldIndex)
            { 
                index = Random.Range(0, hints.Length - 1);
            }
            #endregion
            hintText.text = hints[index];
            yield return new WaitForSeconds(duration);
            background.gameObject.SetActive(false);
            hintText.gameObject.SetActive(false);
            StartCoroutine(ShowTips());
        }
       
        
    }

   
}
