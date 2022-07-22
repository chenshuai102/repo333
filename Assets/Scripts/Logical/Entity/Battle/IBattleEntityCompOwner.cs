using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ս��ʵ����������߽ӿڣ��ṩս��ʵ�������ȡ����
/// </summary>
public interface IBattleEntityCompOwner
{
    IBattleEntityCompBasicInfo BattleEntityCompBasicInfoGet();

    IBattleEntityCompBattleActorEnv BattleEntityBattleActorEnvGet();

    IBattleEntityCompBattleActorManager BattleEntityBattleActorManagerGet();

    IBattleEntityCompOptCmd BattleEntityCompOptCmdGet();

}
