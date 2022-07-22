using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region 内部变量
    public CharacterController controller;

    //用于在正常走路和奔跑速度中间变换的 实时速度
    public float midSpeed = 4f;

    //走路速度
    public float speed = 4f;

    public float gravity = -9.81f;

    //奔跑速度
    public float runSpeed = 6f;

    //一组用于进行地面判断的变量
    public Transform groundCheck;
    public float groundDistence = 0.4f;
    public LayerMask groundMask;

    //跳跃时所能达到的向上速度
    public float jumpHeight = 1.5f;

    Vector3 velocity;

    //判定是否在地面
    bool isGrounded;
    #endregion

    void Start()
    {

        //通过InputMgr进行输入侦测
        InputMgr.GetInstance().StartOrEndCheck(true);
        EventCenter.GetInstance().AddEventListener<float[]>("水平移动", HorizontalMove);
        EventCenter.GetInstance().AddEventListener<string>("垂直移动",VerticalMove);
        EventCenter.GetInstance().AddEventListener<KeyCode>(KeyCode.LeftShift.ToString() + "按下", Run);
        EventCenter.GetInstance().AddEventListener<KeyCode>(KeyCode.LeftShift.ToString() + "抬起", Run);
    }

    /// <summary>
    /// update主要处理玩家竖直方向的移动逻辑(重力模拟)
    /// </summary>
    void Update()
    {

        //Physics.CheckSpher在一个指定位置创建一个指定半径的球体，并与指定的层级的物体进行碰撞判断
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistence, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }


    /// <summary>
    /// 奔跑
    /// </summary>
    /// <param name="key">按下的键位</param>
    private void Run(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            midSpeed = runSpeed;
        }
        if (Input.GetKeyUp(key))
        {
            midSpeed = speed;
        }
    }

    /// <summary>
    /// 控制角色在水平地面移动逻辑
    /// </summary>
    /// <param name="num"></param>
    private void HorizontalMove(float[]num)
    {
        float x = num[0];
        float z = num[1];
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * midSpeed * Time.deltaTime);

    }

    /// <summary>
    /// 在按下跳跃键执行的逻辑
    /// </summary>
    /// <param name="button"></param>
    private void VerticalMove(string button)
    {
        //Physics.CheckSpher在一个指定位置创建一个指定半径的球体，并与指定的层级的物体进行碰撞判断
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistence, groundMask);
        if (Input.GetButtonDown(button) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

    }


}
