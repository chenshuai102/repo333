using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleActorEntity : IBattleActorEntity, IBattleActorEntityCompOwner
{

    protected List<BattleActorCompBase> m_battleActorCompList = new List<BattleActorCompBase>();

    protected BattleActorComBasicInfo m_comBattleActorComBasicInfo;

    protected BattleActorCompHp m_comBattleActorHp;

    protected BattleActorCompOptCmdInput m_comBattleActorOptCmdInput;

    protected IBattleActorEnv m_battleActorEnv;


    /// <summary>
    /// ctor ���캯��
    /// </summary>
    public BattleActorEntity(IBattleActorEnv env)
    {
        m_battleActorEnv = env;
    }

    #region IBattleActorEnv �ӿ�ʵ��
    public IBattleActorEnv BattleActorEnvGet()
    {
        return m_battleActorEnv;
    }
    #endregion

    #region IBattleActorCompBasicInfo�ӿ�ʵ��
    public IBattleActorCompBasicInfo CompBattleActorBasicInfoGet()
    {
        return m_comBattleActorComBasicInfo;
    }
    #endregion

    #region IBattleActorCompHp�ӿ�ʵ��
    public IBattleActorCompHp CompBattleActorHpGet()
    {
        return m_comBattleActorHp;
    }
    #endregion

    #region IBattleActorHp�ӿ�ʵ��
    public float CurrentHpGet()
    {
        return m_comBattleActorHp.CurrentHpGet();
    }

    public float MaxHpGet()
    {
        return m_comBattleActorHp.MaxHpGet();
    }
    #endregion

    #region IBattleActorBasicInfo�ӿ�ʵ��
    public int EntitySpeedGet()
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region IBattleActorOptCmdInput�ӿ�ʵ��
    public void OptCmdInput(OptCmd optCmd)
    {
        m_comBattleActorOptCmdInput.OptCmdInput(optCmd);
    }
    #endregion

    /// <summary>
    /// ��ʼ��
    /// </summary>
    public void Initialize()
    {
        m_comBattleActorHp = new BattleActorCompHp(this);
        m_comBattleActorHp.Initialize();
        m_battleActorCompList.Add(m_comBattleActorHp);

        m_comBattleActorComBasicInfo = new BattleActorComBasicInfo(this);
        m_comBattleActorComBasicInfo.Initialize();
        m_battleActorCompList.Add(m_comBattleActorComBasicInfo);

        m_comBattleActorOptCmdInput = new BattleActorCompOptCmdInput(this);
        m_comBattleActorOptCmdInput.Initialize();
        m_battleActorCompList.Add(m_comBattleActorOptCmdInput);
    }

    /// <summary>
    /// �߼�֡����
    /// </summary>
    /// <param name="deltaTime"></param>
    public void Tick(float deltaTime)
    {

    }

    /// <summary>
    /// ж��
    /// </summary>
    public virtual void UnInitialize()
    {

    }

}
