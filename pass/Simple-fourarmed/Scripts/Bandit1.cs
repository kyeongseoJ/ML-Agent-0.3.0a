using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 간단한 포암드 밴딧 four armed bandit
/// </summary>
public class Bandit1 : MonoBehaviour
{
    /// <summary>
    /// 보상값을 표시하는데 사용할 메터리얼 속성들
    /// </summary>
    //public Material Gold;
    //public Material Silver;
    //public Material Bronze;
    //public Material Any;
    public Simplearm1[] arms; 

    /// <summary>
    /// mesh renderer의 placeholder
    /// </summary>
    private MeshRenderer mesh;
    /// <summary>
    /// 위치 재설정을 위한 변수 
    /// </summary>
    private Material reset;

    // 사용할 컴포넌트 초기화
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        reset = mesh.material;
    }
    /// <summary>
    /// material과 보상을 설정하는 부분
    /// </summary>
    /// <param name="arm"></param>
    /// <returns></returns>
    public int PullArm(int arm)
    {
        //var reward = 0;
        //switch (arm)
        //{
        //    case 1:
        //        mesh.material = Gold;
        //        reward = 3;
        //        break;
        //    case 2:
        //        mesh.material = Bronze;
        //        reward = 1;
        //        break;
        //    case 3:
        //        mesh.material = Silver;
        //        reward = 2;
        //        break;
        //    case 4:
        //        mesh.material = Any;
        //        reward = 4;
        //        break;
        //}
        //return reward;

        if (arm < 0 || arm > arms.Length)
            return 0;
        mesh.material = arms[arm - 1].material;
        return arms[arm - 1].rewardValue;
    }

    public void Reset()
    {
        mesh.material = reset;
    }
}
