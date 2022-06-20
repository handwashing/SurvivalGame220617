using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public string handName; //너클이나 맨손을 구분
    public float range; //공격 범위(팔을 뻗으면 어디까지 닿을지 결정...)
    public int damage; //공격력
    public float workSpeed; //작업 속도
    public float attackDelay; //attck Delay
    public float attackDelayA; //공격 활성화 시점(딜레이)
    public float attackDelayB; //공격 비활성화 시점
    
    public Animator anim; //animation
    //public BoxCollider boxCollider; -> 주먹에 박스 콜라이더를 만들어 충돌한 물체에 데미지를 줄 수 있다. but 주먹이 휘두를때 1인칭 시점과 박스 콜라이더의 위치가 다르게 보일 수 있음
    //1인칭 시점에서 충돌하지 않았으나 충돌한 것처럼 보이고, 그 반대로 처리될 수 있어 사용하지 않는다. 

}
