// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Twig : MonoBehaviour
// {
//     [SerializeField]
//     private int hp; //체력
//     [SerializeField]
//     private float destroyTime; //이펙트 삭제 시간

//     [SerializeField]
//     private GameObject go_hit_effect_prefab; //타격 이펙트

//     //회전값 변수
//     private Vector3 originRot; 
//     private Vector3 wantedRot;
//     private Vector3 currentRot;

//     //필요한 사운드 이름
//     [SerializeField]
//     private string hit_Sound;
//     [SerializeField]
//     private string broken_Sound;

//     void Start()
//     {//rotation값을 그대로 받아오려면 quaternion으로 선언해야 한다 but 보기 편하게 euler값을 토대로 Vector3로 표기한 것 / 그래서 아래의  rotation값은 (euler로 변환 시킨) quaternion 값임
//         originRot = transform.rotation.eulerAngles; 
//         currentRot = originRot; //현재 위치값은 지금 자기 자신임
//     }

//     //데미지 입히기
//     public void Damage(Transform _playerTf)
//     {//맞을 때 플레이어가 때린 반대 방향으로 나뭇가지를 휘게 만들기
//         hp--;

//         Hit();

//         if(hp <= 0)
//         {
//             ;//Destroy
//         }
//     }

//     // private void Hit()
//     // {
//     //     SoundManager.instance.PlaySE(hit_Sound);
//     //     //프리팹을 생성해 클론에 넣기 / 나뭇가지의 정중앙에 생성 / 회접값 : 기본값
//     //     GameObject clone = Instantiate(go_hit_effect_prefab, 
//     //                                    gameObject.GetComponent<BoxCollider>().bounds.center,
//     //                                    Quaternion.identity);

//     //     Destroy(clone, destroyTime); //destroyTime 후에 클론 삭제
//     // }

//     // IEnumerator HitSwayCoroutine(Transform _target) // 이 타겟은 player 의 Transform
//     // {
//     //     Vector3 direction = (_target.position - transform.position).normalized; //나뭇가지와 플레이어가 서로 바라보는 방향
//     // }
// }
