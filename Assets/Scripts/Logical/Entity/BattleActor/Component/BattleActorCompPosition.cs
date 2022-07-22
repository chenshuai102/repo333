using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ӿ�
/// </summary>
public interface IBattleActorPosition
{
    float HorizontalGet();

    float VerticalGet();
}

/// <summary>
/// ���ڽӿ�
/// </summary>
public interface IBattleActorCompPostion :IBattleActorPosition
{

}

/// <summary>
/// ս������λ�����
/// </summary>
public class BattleActorCompPosition : BattleActorCompBase, IBattleActorCompPostion
{
    private float m_horizontal;
    private float m_vertical;

    public float Horizontal { get { return m_horizontal; } set { m_horizontal = value; } }
    public float Vertical { get { return m_vertical; } set { m_vertical = value; } }

    /// <summary>
    /// ���캯��
    /// </summary>
    /// <param name="owner">��������ĵ�λ</param>
    /// <param name="horizontal"></param>
    /// <param name="vertical">ʵ��ĳ�ʼλ��</param>
    public BattleActorCompPosition(IBattleActorEntityCompOwner owner, float horizontal, float vertical) : base(owner)
    {
        m_horizontal = horizontal;
        m_vertical = vertical;
    }

    #region IBattleActorPosition�ӿ�ʵ��
    public float HorizontalGet()
    {
        return Horizontal;
    }

    public float VerticalGet()
    {
        return Vertical;
    }
    #endregion
}
