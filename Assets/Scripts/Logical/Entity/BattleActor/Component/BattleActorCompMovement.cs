using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ӿ�
/// </summary>
public interface IBattleActorMovement
{

}

/// <summary>
/// ������ڽӿ�
/// </summary>
public interface IBattleActorCompMovement: IBattleActorMovement
{

}

public class BattleActorCompMovement : BattleActorCompBase, IBattleActorCompMovement
{
    public BattleActorCompMovement(IBattleActorEntityCompOwner owner) : base(owner)
    {
    }


}
