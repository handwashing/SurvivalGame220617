using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    //기존 위치(가만히 있을 때 원래 위치로 돌아가야함)
    private Vector3 originPos;

    //(계산에 필요한)현재 위치
    private Vector3 currentPos;

    //sway 한계 (무기가 흔들릴 때 최대 얼마만큼 흔들릴지...)
    [SerializeField]
    private Vector3 limitPos;

    //정조준 sway 한계
    [SerializeField]
    private Vector3 fineSightLimitPos;

    //움직임의 부드러움 정도 (총이 얼마나 부드럽게 흔들릴지...)
    [SerializeField]
    private Vector3 smoothSway;

    //필요한 컴퍼넌트
    private GunController theGunController;   //(총의 경우)정조준 상태를 받아올 수 있는 값이 필요


    void Start()
    {
        originPos = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
