using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������ӿ�
/// </summary>
public interface IBattleActorOptCmdInput
{
    void OptCmdInput(OptCmd optCmd);
}

/// <summary>
/// ������ڽӿ�
/// </summary>
public interface IBattleActorCompOptCmdInput: IBattleActorOptCmdInput
{

}

public class BattleActorCompOptCmdInput : BattleActorCompBase, IBattleActorCompOptCmdInput
{

    public BattleActorCompOptCmdInput(IBattleActorEntityCompOwner owner) : base(owner)
    {
    }

    public void OptCmdInput(OptCmd optCmd)
    {
        m_owner.BattleActorEnvGet().OptCmdPush(optCmd);
    }
}
