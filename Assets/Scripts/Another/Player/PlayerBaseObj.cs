using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseObj : MonoBehaviour
{
    //当前血量和最大血量相关
    public int maxHp;
    public int hp;

    //速度
    public float speed = 4f;

    //武器
    public PlayerWeapon weapon;

    //重力
    public float gravity = -9.81f;

    //一组用于进行地面判断的变量
    public Transform groundCheck;
    public float groundDistence = 0.4f;
    public LayerMask groundMask;

    //跳跃时所能达到的向上速度
    public float jumpHeight = 1.5f;

    public Vector3 velocity;

    //判定是否在地面
    public bool isGrounded;

    public float mouseSensitivity = 100f;
    public Texture2D tex;
    public Transform playerBody;
    public Transform playerCame;

    public float xRotation = 0f;

    /// <summary>
    /// 开火方法
    /// </summary>
    public abstract void Shoot();
    
    /// <summary>
    /// 受伤方法
    /// </summary>
    /// <param name="other"></param>
    public virtual void Wound(PlayerBaseObj other)
    {

    }

    /// <summary>
    /// 死亡方法
    /// </summary>
    public virtual void Dead()
    {
        //播放人物的死亡动画


        //对象死亡，从场景中移除该对象
        Destroy(this.gameObject);
        

    }
}
