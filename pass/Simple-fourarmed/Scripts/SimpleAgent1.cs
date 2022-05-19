using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 일부 보상에서 일부 태스크 또는 태스크 기반 명령집합을 수행하는 방법을 배우도록 훈련하고 있는 Actor를 나타낸다.
/// </summary>
public class SimpleAgent1 : Agent {
    /// <summary>
    /// 에이전트가 환경을 관측하는 대상을 설정하기 위해 호출하는 메서드
    /// 모든 에이전트 단계 또른 에이전트 활동에서 호출된다.
    /// </summary>
    public override void CollectObservations()
    {
        // float값 0을 에이전트 관측 컬렉션에 추가
        AddVectorObs(0);
    }

    public Bandit1 bandit;
    /// <summary>
    /// PullArm메서드가 있는 Bandit에 적용해 팔을 당기도록 전달
    /// 밴딧에서 반환되어 가져온 보상은 AddReward를 이용해 추가
    /// </summary>
    /// <param name="vectorAction"></param>
    /// <param name="textAction"></param>
    public override void AgentAction(float[] vectorAction, string textAction)
	{
        var action = (int)vectorAction[0];
        AddReward(bandit.PullArm(action));
        Done();
    }

    /// <summary>
    /// Bandit를 다시 시작상태로 재설정 한다.
    /// 에이전트가 행동을 마치거나, 완성 혹은 단꼐를 벗어날때 호출된다
    /// </summary>
    public override void AgentReset()
    {
        bandit.Reset();
    }

    public override void AgentOnDone()
    {

    }

    public Academy academy;
    public float timeBetweenDecisionsAtInference;
    private float timeSinceDecision;

    public void FixedUpdate()
    {
        WaitTimeInference();
    }

    /// <summary>
    /// 브레인이 플레이어의 결정을 받을때까지 기다리게 하는 코드
    /// </summary>
    private void WaitTimeInference()
    {
        if (!academy.GetIsInference())
        {
            RequestDecision();
        }
        else
        {
            if (timeSinceDecision >= timeBetweenDecisionsAtInference)
            {
                timeSinceDecision = 0f;
                RequestDecision();
            }
            else
            {
                timeSinceDecision += Time.fixedDeltaTime;
            }
        }
    }
}
