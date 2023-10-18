using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject _endTransition;
    
    private void Start()
    {
        Transition();
    }

    private void Transition()
    {
        StartCoroutine(Translate());

        IEnumerator Translate()
        {
            _endTransition.SetActive(true);
            yield return new WaitForSeconds(1f);
            yield return null;
        }
    }
}
