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




    //Dotween 방식
    void FadeInOut_Dt()
    {
        LoadImage.color = new Color(1, 1, 1, 0);

        LoadImage.DOFade(1, fadeTime).SetDelay(delayTime).OnComplete(() => LoadImage.DOFade(0, fadeTime));
    }


    //코루틴 방식
    IEnumerator FadeInOut_Co()
    {
        // 이미지의 알파값을 0으로 설정합니다.
        LoadImage.color = new Color(1, 1, 1, 0);

        // 지연 후 페이드 인 애니메이션 시작
        yield return new WaitForSeconds(delayTime);

        // 페이드 인 애니메이션
        float fadeTimer = Time.time;
        while (Time.time - fadeTimer < fadeTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, (Time.time - fadeTimer) / fadeTime);
            LoadImage.color = new Color(LoadImage.color.r, LoadImage.color.g, LoadImage.color.b, alpha);
            yield return null;
        }

        // 페이드 아웃 애니메이션
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
