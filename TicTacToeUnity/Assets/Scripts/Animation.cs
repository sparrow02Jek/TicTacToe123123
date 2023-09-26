using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    [SerializeField] private float _speed;
    public bool toAnimateRotation, toAnimateScale, toAnimateButton, toAnimateloginButton;
    [SerializeField] private BGGenerator _bgGenerator;
    [SerializeField] private SpriteRenderer loginImage;
    void Start()
    {
        DOTween.Init();
        if(transform != null) if (toAnimateScale) transform.DOScale(0.5f ,_bgGenerator._frequence + 0.5f);
        _speed = Random.Range(-0.6f, 0.6f);
        if (toAnimateButton) StartCoroutine(buttonAnimation());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (toAnimateRotation)
        {
            if (transform is not null)
                transform.Rotate(new Vector3(0, 0, _speed));
        }
    }

    float F(float x)
    {
        float a = 0;
        a += Mathf.Sin(x);
        return a;
    }

    IEnumerator buttonAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            transform.DOScale(1.2f ,0.5f);
            yield return new WaitForSeconds(0.5f);
            transform.DOScale(1f , 0.5f);
        }
    }
    
}

