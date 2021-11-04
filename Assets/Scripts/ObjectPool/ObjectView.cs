using System.Collections;
using UnityEngine;

public class ObjectView : MonoBehaviour
{
    private void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            StartCoroutine(SetActive());
        }
    }
    private IEnumerator SetActive()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
