using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeComponent : MonoBehaviour
{
    //깎일 나무 조각들
    [SerializeField]
    private GameObject[] go_treePieces;
    [SerializeField]
    private GameObject go_treeCenter; //중간에 있는 나무 piece

    //부모 트리 파괴되면, 캡슐 콜라이더 제거
    [SerializeField]
    private CapsuleCollider parentCol;

    //자식 트리 쓰러질 때 필요한 컴퍼넌트 활성화 및 중력 활성화
    [SerializeField]
    private CapsuleCollider childCol;
    [SerializeField]
    private Rigidbody childRigid;

    //파편
    private GameObject go_hit_effect_prefab;

    //파편 제거 시간
    [SerializeField]
    private float debrisDestroyTime;

    //나무 제거 시간
    [SerializeField]
    private float destroyTime;


    //필요한 사운드
    [SerializeField]
    private string chop_sound; //나무 썰리는 소리
    [SerializeField]
    private string falldown_sound; //나무 떨어지는 소리
    [SerializeField]
    private string logChange_sound; //통나무로 바뀌는 소리


    public void Chop(Vector3 _pos, float angleY) // 도끼 부분에서 파편이 튀게 할 것 / (도끼랑 충돌한 지점의 위치, 플레이어가 서있는 위치)
    {
        Hit(_pos);

        AngleCalc(angleY); //플레이어가 어디서 도끼를 휘둘렀는지 각도 계산
    }

    //적중 이펙트
    private void Hit(Vector3 _pos)
    {
        SoundManager.instance.PlaySE(chop_sound);

        /*
        GameObject clone = Instantiate(go_hit_effect_prefab, _pos, Quaternion.Euler(Vector3.zero));
        Destroy(clone, debrisDestroyTime);
        */
    }

    private void AngleCalc(float _angleY)
    {
        Debug.Log(_angleY); //_angleY가 몇도인지에 따라서 어디 조각이 파괴되어야 하는지 결정
    }
}
