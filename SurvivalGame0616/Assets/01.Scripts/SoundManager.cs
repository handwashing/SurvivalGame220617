using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound //다른 객체에 컴퍼넌트 추가할 수 없음(BCZ / MonoBehaviour 상속 x)
{
    public string name; //곡의 이름
    public AudioClip clip; //곡
}

public class SoundManager : MonoBehaviour
{//사운드 매니저가 복수 생성되는 것을 방지하기 위해 싱글턴화 -> 기존의 사운드 매니저를 살려두고
//새로 생성된 (씬에) 것은 파괴한다. => 어느 씬에 있던 하나의 사운드 매니저만을 유지할 수 있다.
    
    static public SoundManager instance; //자기 자신을(SoundManager)를 instance로 만드는 것 / 어디서든지 접근 가능하고 공유 자원으로 쓰도록 static처리
    //싱글턴 
    #region singleton
    void Awake() //객체 생성시 최초 실행
    {
        if(instance == null) //instance에 들어있는 것이 없다면...
        {
            instance = this; //최초 실행시 자기 자신을 (껍데기에)넣어 채워주기...
            DontDestroyOnLoad(gameObject); //자기 자신은 파괴시키지 말아라...
        }
        else
            Destroy(gameObject); //이미 존재한다면 새로 생성된 것을 파괴
    }
    #endregion singleton

    public AudioSource[] audioSourceEffects; //동시에 여러개 재생할 수 있도록 배열 사용
    public AudioSource audioSourceBgm; //Bgm은 하나만 필요 -> 배열 필요x

    public Sound[] effectSounds; //<- 이와 같이 class Sound의 내용을 변수로 만들어 가져다 쓰면 된다...
    public Sound[] bgmSounds;

    public void PlaySE(string _name)
    {//_name이 Sound의 name과 일치한다면 -> clip을 AudioSource에 넣어 재생시킬 것

     //Sound에 일치하는 이름이 있는지 확인
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if(_name == effectSounds[i].name) //_name와 effectSounds의 i번째 name과 일치하다면
            {
                for (int j = 0; j < audioSourceEffects.Length; j++)
                {
                    if(audioSourceEffects[j].isPlaying);
                }
            }
        }                                 
 //재생중인 것은 재생시키게 내버려두고 재생중이지 않은 오디오소스를 찾아 재생시키기(흐름이 끊기지 않도록)
 //재생중이지 않은 오디오 소스를 찾도록...
    }
}
