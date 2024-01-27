using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Dialogue : MonoBehaviour
{
    [SerializeField] private UnityEvent _destroy;
    [SerializeField] private GameObject[] _dialogues;
    private int currentIndex = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextDialogue();
        }
    }

    private void ShowNextDialogue()
    {
        if (currentIndex < _dialogues.Length)
        {
            _dialogues[currentIndex].SetActive(false);
            if (currentIndex + 1 < _dialogues.Length)
            {
                _dialogues[currentIndex + 1].SetActive(true);
                currentIndex++;
            }
            else
            {
                Exit();
            }
        }
    }

    public void Exit()
    {
        currentIndex = 0;
        _destroy.Invoke();
        Destroy(_dialogues[0].transform.parent.gameObject);
        this.GetComponent<Dialogue>().enabled = false;
    }

}
