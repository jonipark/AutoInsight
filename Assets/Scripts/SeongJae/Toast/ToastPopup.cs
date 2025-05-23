using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;

public class ToastPopup : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private Image image; 
    [Header("Image Color")]
    [SerializeField] private float r;
    [SerializeField] private float g;
    [SerializeField] private float b;
    [Space]
    [Header ("Text Color")]
    [SerializeField] private float textr;
    [SerializeField] private float textg;
    [SerializeField] private float textb;
    [Space]
    [Header("Text Color")]
    [SerializeField] private Vector3 offset;

    // ������
    int count;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        //PopText("Currently Playing <b>Test</b>." + (count++));
    //        PopUpToast();
    //    }
    //}

    public void PopText(string textNeededToBeShown)
    {
        if (textComponent == null)
        {
            textComponent = GetComponentInChildren<TextMeshProUGUI>();
            image = GetComponent<Image>();
            image.color = new Color(r, g, b, 0);
        }

        transform.position = Camera.main.transform.position + offset;
        LeanTween.cancelAll(gameObject);
        textComponent.text = textNeededToBeShown;
        SetAlpha();
    }

    public void PopUpToast()
    {
        image = GetComponent<Image>();
        image.enabled = true;
        image.color = new Color(r, g, b, 0);

     //   transform.position = Camera.main.transform.position + offset;
        LeanTween.cancelAll(gameObject);
        SetAlpha();
    }


    //private void UpdateAlpha(float alpha)
    //{
    //    textComponent.color = new Color(textr, textg, textb, alpha);
    //}

    private void SetAlpha()
    {
        LeanTween.alpha(image.rectTransform, 1f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.alpha(image.rectTransform, 0f, 0.5f).setDelay(2f).setEase(LeanTweenType.easeInOutQuad);
        //LeanTween.value(gameObject, UpdateAlpha, 0f, 1f, 0.5f).setEase(LeanTweenType.easeInOutQuad);
        //LeanTween.value(gameObject, UpdateAlpha, 1f, 0f, 0.5f).setDelay(2f).setEase(LeanTweenType.easeInOutQuad);
    }
}
