using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//각각의 무기마다 컨트롤러를 붙이면 매우 번거롭고 중복됨. -> 공통된, 비슷한 유형의 무기끼리 따로 컨트롤러를 만들어 통합시키기
//Hand 스크립트에서 가져와서 참조형식으로 작성

public class HandController : CloseWeaponController
{
     //활성화 여부
     public static bool isActivate = false;

    void Update()
    {
        if (isActivate)
            TryAttack();
    }

    protected override IEnumerator HitCoroutine()
    {
        while (isSwing)
        {
            if (CheckObject())
            {
                isSwing = false;
                Debug.Log(hitInfo.transform.name);
            }
            yield return null;
        }
    }

      public override void CloseWeaponChange(CloseWeapon _closeWeapon)
    {
        base.CloseWeaponChange(_closeWeapon);
        isActivate = true;
    }
}
//////////////////////////////////////// 근접무기구현 끝나고 지워버려~
// {
//         //활성화 여부
//     public static bool isActivate = false;

//     //현재 장착된 Hand형 타입(무기)
//     [SerializeField]
//     private CloseWeapon currentHand;

//     //공격중?
//     private bool isAttack = false;
//     private bool isSwing = false; //팔을 휘두르고있나?

//     private RaycastHit hitInfo; //Raycast에 닿은 정보를 hitInfo에 저장하는 변수

//     void Update()
//     {         
//         if (isActivate)
//         TryAttack();
//     }

//     private void TryAttack()
//     { //왼쪽 버튼을 누를 경우 코루틴이 실행
//         if(Input.GetButton("Fire1")) //마우스를 누르고 있는 경우에도 효과 지속
//         {
//             if (!isAttack) //딜레이때문에...false일 경우에만 실행 / 코루틴으로 트루로 바꿔줄 것
            
//             {
//                 StartCoroutine(AttackCoroutine());
//             }
//         }
//     }
// //마우스 좌클릭을 하는 순간 StartCoroutine(AttackCoroutine() 코루틴이 실행되고,
// //바로 isAttack = true가 되면서 중복 실행이 막아진다!
// //마지막에 isAttack = false를 줘서 실행시키기...!
//     IEnumerator AttackCoroutine()
//     {
//         isAttack = true;
//         currentHand.anim.SetTrigger("Attack"); //Attack애니메이션 실행

//         yield return new WaitForSeconds(currentHand.attackDelayA);//currentHand.attackDelayA 만큼 대기시간 주기...
//         isSwing = true; //공격 들어감 true가 된 순간 공격이 적중했는지 구분하는 함수(코루틴)

//         //적중 여부를 판단할 수 있는 코루틴 반복 실행...
//         StartCoroutine(HitCoroutine());

//         //공격 활성화 시점

//         yield return new WaitForSeconds(currentHand.attackDelayB); //또 대기시간 주기
//         isSwing = false; //일정 시간이 지나면 false 가 되어 HitCoroutine이 꺼짐

//         //공격할 수 있게 대기...
//         //딱 attackDelay 만큼 쉴 수 있게 그 전의 A,B값을 빼줌...
//         yield return new WaitForSeconds(currentHand.attackDelay - currentHand.attackDelayA - currentHand.attackDelayB);
//         isAttack = false; //false를 줘서 재공격할 수 있도록 만들었다...
//     }

// //공격 적중을 알아보는 코루틴
// //Delay A,B사이에 계속 닿은것이 있는지를 체크...
//     IEnumerator HitCoroutine()
//     {
//         while (isSwing)
//         {//isSwing이 트루 -> 반복 실행하며 (CheckObject를 호출해) 조건 분기 체크
//             if (CheckObject())
//             {
//                 isSwing = false; //하나 적중했을 경우 다시 실행하지 않도록...
//                 //충돌함/충돌한 것의 하이어라키 이름 받아오기
//                 Debug.Log(hitInfo.transform.name);
//             }
//             yield return null; //while문이 한 번 돌 동안 1프레임 대기
//         }
//     }

//     private bool CheckObject()
//     {
//         if(Physics.Raycast(transform.position, transform.forward, out hitInfo, currentHand.range))
//         {
//             return true; //충돌한 게 있음
//         }
//         return false; //충돌한 게 없음
//     }

//      public void HandChange(CloseWeapon _hand) 
//     {
//         if(WeaponManager.currentWeapon != null) //무언가(weapon)를 들고있는 경우..
//            WeaponManager.currentWeapon.gameObject.SetActive(false); //기존에 들고있던 무기 제거(비활성화)
        
//         currentHand = _hand;
//         WeaponManager.currentWeapon = currentHand.GetComponent<Transform>();
//         WeaponManager.currentWeaponAnim = currentHand.anim;

//         currentHand.transform.localPosition = Vector3.zero; //총의 경우 정조준을하면 좌표값이 달라짐 / 다른 무기에서 총으로 변경을 하면 transform.localPosition이 달라질 수도 있음
//         currentHand.gameObject.SetActive(true);
//         isActivate = true;
    
//     }
// }
