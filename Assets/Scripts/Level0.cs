using System.Collections;
using UnityEngine;

public class Level0 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D caRigidbody2D;
    [SerializeField] private GameObject line1;
    [SerializeField] private GameObject line2;
    [SerializeField] private GameObject line3;
    [SerializeField] private GameObject line4;

    private void Start()
    {
        StartCoroutine(CallNextLine());
    }

    IEnumerator CallNextLine()
    {
        yield return new WaitForSeconds(2f);
        caRigidbody2D.AddForce(new Vector2(17, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(6f);
        line1.SetActive(false);
        line2.SetActive(true);
        yield return new WaitForSeconds(7f);
        line2.SetActive(false);
        line3.SetActive(true);
        yield return new WaitForSeconds(7f);
        line3.SetActive(false);
        line4.SetActive(true);
        yield return new WaitForSeconds(10f);
        LoadNextScene();
    }
    
    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
