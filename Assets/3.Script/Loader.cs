using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    [SerializeField] Image LoadImage;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] float delayTime = 1f;
    private void Awake()
    {
        //������ �ε�
    }

    void Start()
    {

        //FadeInOut_Dt();
        StartCoroutine(FadeInOut_Co());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Start();
        }
    }




    //Dotween ���
    void FadeInOut_Dt()
    {
        LoadImage.color = new Color(1, 1, 1, 0);

        LoadImage.DOFade(1, fadeTime).SetDelay(delayTime).OnComplete(() => LoadImage.DOFade(0, fadeTime));
    }


    //�ڷ�ƾ ���
    IEnumerator FadeInOut_Co()
    {
        // �̹����� ���İ��� 0���� �����մϴ�.
        LoadImage.color = new Color(1, 1, 1, 0);

        // ���� �� ���̵� �� �ִϸ��̼� ����
        yield return new WaitForSeconds(delayTime);

        // ���̵� �� �ִϸ��̼�
        float fadeTimer = Time.time;
        while (Time.time - fadeTimer < fadeTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, (Time.time - fadeTimer) / fadeTime);
            LoadImage.color = new Color(LoadImage.color.r, LoadImage.color.g, LoadImage.color.b, alpha);
            yield return null;
        }

        // ���̵� �ƿ� �ִϸ��̼�
        fadeTimer = Time.time;
        while (Time.time - fadeTimer < fadeTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, (Time.time - fadeTimer) / fadeTime);
            LoadImage.color = new Color(LoadImage.color.r, LoadImage.color.g, LoadImage.color.b, alpha);
            yield return null;
        }


        SceneManager.LoadScene("Main",LoadSceneMode.Single);
    }
}
