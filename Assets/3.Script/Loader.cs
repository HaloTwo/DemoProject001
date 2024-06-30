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
        StartCoroutine(FadeInOut_Co());
    }


    //�ڷ�ƾ ���
    IEnumerator FadeInOut_Co()
    {
        // �̹����� ���İ��� 0���� �����մϴ�.
        Color orignColor = LoadImage.color;
        LoadImage.color = new Color(orignColor.r, orignColor.g, orignColor.b, 0);

        Text text = LoadImage.GetComponentInChildren<Text>();
        Color textOrignColor = text.color;
        text.color = new Color(textOrignColor.r, textOrignColor.g, textOrignColor.b, 0);

        // ���� �� ���̵� �� �ִϸ��̼� ����
        yield return new WaitForSeconds(delayTime);

        // ���̵� �� �ִϸ��̼�
        float fadeTimer = Time.time;
        while (Time.time - fadeTimer < fadeTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, (Time.time - fadeTimer) / fadeTime);
            LoadImage.color = new Color(LoadImage.color.r, LoadImage.color.g, LoadImage.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            yield return null;
        }

        yield return new WaitForSeconds(delayTime);

        // ���̵� �ƿ� �ִϸ��̼�
        fadeTimer = Time.time;
        while (Time.time - fadeTimer < fadeTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, (Time.time - fadeTimer) / fadeTime);
            LoadImage.color = new Color(LoadImage.color.r, LoadImage.color.g, LoadImage.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            yield return null;
        }


        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
