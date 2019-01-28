using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;

public class PressButton : MonoBehaviour, 
    IColliderEventPressUpHandler, 
    IColliderEventPressEnterHandler,
    IColliderEventPressExitHandler,
    IColliderEventHoverEnterHandler,
    IColliderEventHoverExitHandler
{
    public GameObject pressButton;
    public GameObject explosionEffect;
    public GameObject explosionPosition;
    private Transform pressButtonTransform;
    private float pressButtonOriginalYPos;

    private void Start()
    {
        pressButtonTransform = pressButton.GetComponent<Transform>();
        pressButtonOriginalYPos = pressButtonTransform.position.y;
    }

    //버튼이 눌려지는 효과
    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        pressButtonTransform.position = new Vector3(pressButtonTransform.position.x, pressButtonOriginalYPos - 0.15f, pressButtonTransform.position.z);
    }

    //버튼이 눌려졌다가 떼어지는 효과
    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        pressButtonTransform.position = new Vector3(pressButtonTransform.position.x, pressButtonOriginalYPos, pressButtonTransform.position.z);
    }

    public void OnColliderEventPressUp(ColliderButtonEventData eventData)
    {
        GameObject go = Instantiate(explosionEffect, explosionPosition.GetComponent<Transform>());
        Destroy(go, 2f);
    }

    //터치하지 않고 커서를 위에 올려만 놓는 동작
    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        pressButton.GetComponent<Renderer>().material.color = Color.white;
    }

    //터치하지 않고 커서를 위에 올려놓았다가 빠져나오는 동작
    public void OnColliderEventHoverExit(ColliderHoverEventData eventData)
    {
        pressButton.GetComponent<Renderer>().material.color = Color.red;
    }
}
