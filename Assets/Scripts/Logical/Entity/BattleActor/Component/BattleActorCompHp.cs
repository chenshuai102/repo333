using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ӿ�
/// </summary>
public interface IBattleActorHp
{
    float CurrentHpGet();

    float MaxHpGet();
} 

/// <summary>
/// ���ڽӿ�
/// </summary>
public interface IBattleActorCompHp: IBattleActorHp
{

}


public class BattleActorCompHp : BattleActorCompBase, IBattleActorCompHp
{
    public BattleActorCompHp(IBattleActorEntityCompOwner owner) : base(owner)
    {
    }

    public float CurrentHpGet()
    {
        throw new System.NotImplementedException();
    }

    public float MaxHpGet()
    {
        throw new System.NotImplementedException();
    }
}
