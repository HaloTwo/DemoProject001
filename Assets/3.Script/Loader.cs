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
        //데이터 로드
    }

    void Start()
    {
        StartCoroutine(FadeInOut_Co());
    }


    //코루틴 방식
    IEnumerator FadeInOut_Co()
    {
        // 이미지의 알파값을 0으로 설정합니다.
        Color orignColor = LoadImage.color;
        LoadImage.color = new Color(orignColor.r, orignColor.g, orignColor.b, 0);

        Text text = LoadImage.GetComponentInChildren<Text>();
        Color textOrignColor = text.color;
        text.color = new Color(textOrignColor.r, textOrignColor.g, textOrignColor.b, 0);

        // 지연 후 페이드 인 애니메이션 시작
        yield return new WaitForSeconds(delayTime);

        // 페이드 인 애니메이션
        float fadeTimer = Time.time;
        while (Time.time - fadeTimer < fadeTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, (Time.time - fadeTimer) / fadeTime);
            LoadImage.color = new Color(LoadImage.color.r, LoadImage.color.g, LoadImage.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            yield return null;
        }

        yield return new WaitForSeconds(delayTime);

        // 페이드 아웃 애니메이션
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
