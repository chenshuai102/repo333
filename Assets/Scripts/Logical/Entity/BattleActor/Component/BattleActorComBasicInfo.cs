using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ӿ�
/// </summary>
public interface IBattleActorBasicInfo
{

}

/// <summary>
/// ���ڽӿ�
/// </summary>
public interface IBattleActorCompBasicInfo:IBattleActorBasicInfo
{

}

public class BattleActorComBasicInfo : BattleActorCompBase,IBattleActorCompBasicInfo
{


    public BattleActorComBasicInfo(IBattleActorEntityCompOwner owner) : base(owner)
    {
    }


}
