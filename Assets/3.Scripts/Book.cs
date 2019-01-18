using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
책의 행동을 결정. StageManager로부터 '떨어져라'라는 신호를 받으면 지진 이펙트에서 흔드는 알고리즘에 따라 떨어지고, 
기존 위치와 일정(BookManager가 갖는 거리) 이상 가까워지면 원 위치로 돌아가고 효과발생, BookManager에 정답갯수 올림.
*/
public class Book : MonoBehaviour
{
    //기존의 위치와 회전값를 가짐.
    Vector3 initPos = Vector3.zero;
    Vector3 initEulerRot = Quaternion.identity.eulerAngles;
    public Text title = null;
    public MeshRenderer _mesh;
    
    //이 책이 떨어져서 제자리를 찾아야 되는 책인지?
    bool isQuestion = false;

    private void Awake()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        if(isQuestion)
        {
            if ((transform.position - initPos).magnitude <= BookManager.Instance.correctDist && (transform.rotation.eulerAngles - initEulerRot).magnitude <= BookManager.Instance.correctRot)
            {
                RightAnswer();
            }
        }
    }

    public void SetText(string newTitle)
    {
        title.text = newTitle;
    }

    public void SetColor(Color color)
    {
        _mesh.material.color = color;
    }

    /// <summary>
    /// 정답일 때 작동. 위치와 회전을 원위치 시키고, 상호작용을 못하도록 함.
    /// </summary>
    void RightAnswer()
    {
        isQuestion = false;
        transform.position = initPos;
        transform.rotation = Quaternion.Euler(initEulerRot);

        //TODO: 상호작용 불가능하도록 하는 작업. 레이어.
        gameObject.layer = 0;
        CorrectEffect();
    }

    void CorrectEffect()
    {

    }
}
