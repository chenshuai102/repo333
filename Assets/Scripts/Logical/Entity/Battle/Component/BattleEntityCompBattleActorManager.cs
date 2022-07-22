using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleEntityBattleActorManager
{
    /// <summary>
    /// ��ȡ���е�Actor
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<IBattleActorEntity> BattleActorListGet();
}

public interface IBattleEntityCompBattleActorManager: IBattleEntityBattleActorManager
{
    /// <summary>
    /// ����Env
    /// </summary>
    /// <param name="env"></param>
    void BattleActorEnvSet(IBattleActorEnv env);

    /// <summary>
    /// ս����ʼ
    /// </summary>
    void OnBattleStart();
}

public class BattleEntityCompBattleActorManager : BattleEntityCompBase,IBattleEntityCompBattleActorManager
{
    protected List<BattleActorCompBase> m_battleActorList = new List<BattleActorCompBase>();

    protected IBattleActorEnv m_battleActorEnv;

    protected IBattleEntityCompBasicInfo m_compBattleInfo;

    public BattleEntityCompBattleActorManager(IBattleEntityCompOwner owner) : base(owner)
    {
    }

    public void BattleActorEnvSet(IBattleActorEnv env)
    {
        m_battleActorEnv = env;
    }

    public IReadOnlyList<IBattleActorEntity> BattleActorListGet()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// ս����ʼ
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void OnBattleStart()
    {
        var battleActorEntity = new BattleActorEntity(m_battleActorEnv);
        battleActorEntity.Initialize();
        
    }
}
