using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IBattleActorEntity: IBattleActorHp, IBattleActorBasicInfo,IBattleActorOptCmdInput
{
    /// <summary>
    /// ��ҵõ��ٶ�
    /// </summary>
    /// <returns></returns>
    int EntitySpeedGet();


}
