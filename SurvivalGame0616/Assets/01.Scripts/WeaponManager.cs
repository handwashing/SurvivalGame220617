using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //무기 중복 교체 실행 방지
    public static bool isChangeWeapon = false; //true => ChangeWeapon x

    //현재 무기와 현재 무기의 애니메이션
    public static Transform currentWeapon;
    public static Animator currentWeaponAnim;

    //현재 무기의 타입
    [SerializeField]
    private string currentWeaponType;

    //무기 교체 딜레이(총을 꺼내려고 손을 집어넣는 시간)
    [SerializeField]
    private float changeWeaponDelayTime;
    //무기 교체가 완전히 끝난 시점
    [SerializeField]
    private float changeWeaponEndDelayTime;

    //무기 종류들 전부 관리
    [SerializeField]
    private Gun[] guns;
    [SerializeField]
    private Hand[] hands;

    //관리 차원에서 쉽게 무기 접근이 가능하도록 만들기
    private Dictionary<string, Gun> gunDictionary = new Dictionary<string, Gun>();
    private Dictionary<string, Hand> handDictionary = new Dictionary<string, Hand>();

    //필요한 컴퍼넌트
    [SerializeField]
    private GunController theGunController;
    [SerializeField]
    private HandController theHandController;


    void Start()
    {
        for (int i = 0; i < guns.Length; i ++)
        {
            gunDictionary.Add(guns[i].gunName, guns[i]);
        }
        for (int i = 0; i < hands.Length; i++)
        {
            handDictionary.Add(hands[i].handName, hands[i]);
        }  
    }

    void Update()
    {
        if (! isChangeWeapon)
        {//숫자 1이 눌렸을 경우 / 무기 교체 실행(서브머신건)
            if (Input.GetKeyDown(KeyCode.Alpha1));
        //숫자 2가 눌렸을 경우 / 무기 교체 실행(맨손) 
            else if (Input.GetKeyDown(KeyCode.Alpha2));
        }
    }

    public IEnumerator ChangeWeaponCoroutine(string _type, string _name)
    {
        isChangeWeapon = true; //무기 교체가 중복으로 실행되지 않도록
        currentWeaponAnim.SetTrigger("Weapon_Out");

        yield return new WaitForSeconds(changeWeaponDelayTime); //무기를 넣을때까지 대기

        //바뀐 무기를 새로 꺼내야함 정조준 상태를 하고 있다면 먼저 해제해야함
        CancelPreWeaponAction();
        WeaponChange(_type, _name);
    }

    private void CancelPreWeaponAction()
    {//현재 타입에 따라서...
        switch(currentWeaponType)
        {
            case "GUN":
                theGunController.CancelFineSight();
                theGunController.CancelReload();
                break;
            case "HAND":
                break;
        }
    }

    //무기 교체 함수
    private void WeaponChange(string _type, string _name)
    {
        if (_type == "GUN")
            theGunController.GunChange(gunDictionary[_name]);
         else if (_type == "HAND")
            theHandController.HandChange(handDictionary[_name]);
    }
}
