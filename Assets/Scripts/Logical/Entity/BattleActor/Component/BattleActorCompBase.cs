using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleActorCompBase
{
    //������ȡ���������һЩ���ڽӿڵľ��
    protected IBattleActorEntityCompOwner m_owner;

    protected BattleActorCompBase(IBattleActorEntityCompOwner owner)
    {
        m_owner = owner;
    }

    /// <summary>
    /// ��ʼ��
    /// </summary>
    public virtual void Initialize()
    {

    }

    /// <summary>
    /// update������������һ֡һ֡�߼�
    /// </summary>
    /// <param name="deltaTime"></param>
    public virtual void Tick(float deltaTime)
    {

    }

    /// <summary>
    /// ж��
    /// </summary>
    public virtual void UnInitialize()
    {

    }
}
