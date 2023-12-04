using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathListener : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<Player>().OnDieEvent.AddListener(GameOver);
    }

    public void GameOver()    
    {
        StartCoroutine(EndGameCoroutine());
    }

    private IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(Scenes.GameOver);
    }
}
