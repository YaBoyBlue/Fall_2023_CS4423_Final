using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject _startTransition;
    
    private void Start()
    {
        Transition();
    }

    private void Transition()
    {
        StartCoroutine(Translate());

        IEnumerator Translate()
        {
            _startTransition.SetActive(true);
            yield return new WaitForSeconds(1f);
            //SceneManager.LoadScene("Game");
            yield return null;
        }
    }
}