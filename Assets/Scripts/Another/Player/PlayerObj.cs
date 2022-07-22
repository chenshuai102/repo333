using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : PlayerBaseObj
{
    public CharacterController controller;

    

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(tex, Vector2.zero, CursorMode.Auto);

        //获得自身控件
        controller = GetComponent<CharacterController>();
        groundCheck = transform.Find("GroundCheck");
        groundMask = LayerMask.GetMask("Ground");
        playerBody = this.transform;
        playerCame = transform.Find("MainCamera");

        //通过InputMgr进行输入侦测
        InputMgr.GetInstance().StartOrEndCheck(true);
        EventCenter.GetInstance().AddEventListener<float[]>("水平移动", HorizontalMove);
        EventCenter.GetInstance().AddEventListener<string>("垂直移动", VerticalMove);
        EventCenter.GetInstance().AddEventListener("鼠标按下" + 0.ToString(),Shoot);
        EventCenter.GetInstance().AddEventListener<KeyCode>(KeyCode.LeftControl.ToString() + "按下", Crouch);
        EventCenter.GetInstance().AddEventListener<KeyCode>(KeyCode.LeftControl.ToString() + "抬起", Crouch);
        EventCenter.GetInstance().AddEventListener<float[]>("鼠标移动", MouseMove);
    }

    
    void Update()
    {
        GravitySimulation();
    }


    /// <summary>
    /// 控制角色在水平地面移动逻辑, walk状态
    /// </summary>
    /// <param name="num"></param>
    private void HorizontalMove(float[] num)
    {
        float x = num[0];
        float z = num[1];
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

    }

    /// <summary>
    /// 在按下跳跃键执行的逻辑  jump状态
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

    /// <summary>
    /// 按下 LeftControl 进行下蹲
    /// </summary>
    private void Crouch(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            //播放下蹲动画，降低移动速度，摄像头高度下降


        }
        if (Input.GetKeyUp(key))
        {
            //LeftControl抬起取消下蹲动画，并且回复速度


        }
    }

    /// <summary>
    /// 重力模拟
    /// </summary>
    private void GravitySimulation()
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
    /// 视角移动
    /// </summary>
    /// <param name="nums"></param>
    private void MouseMove(float[] nums)
    {
        float mouseX = nums[0] * mouseSensitivity * Time.deltaTime;
        float mouseY = nums[1] * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCame.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    /// <summary>
    /// 重写开火方法
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public override void Shoot()
    {
        if (weapon != null)
        {
            weapon.Fire();
        }
        
    }
}
