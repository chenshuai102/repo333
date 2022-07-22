using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1.Input��
/// 2.�¼�����ģ��
/// 3.����Monoģ���ʹ��
/// </summary>
public class InputMgr : BaseManager<InputMgr>
{
    private bool isStart = false;

    /// <summary>
    /// ���캯���� ���update����
    /// </summary>
    public InputMgr()
    {
        MonoMgr.GetInstance().AddUpdateListener(MyUpdate);
    }

    /// <summary>
    /// �Ƿ�����ر� �ҵ�������
    /// </summary>
    /// <param name="isOp"></param>
    public void StartOrEndCheck(bool isOpen)
    {
        isStart = isOpen;
        
    }

    public void CheckMouseButtonDown(int i)
    {
        if (Input.GetMouseButton(i))
        {
            EventCenter.GetInstance().EventTrigger("��갴��" + i.ToString());
        }
    }

    /// <summary>
    /// ������ⰴ��̧��,�ַ��¼���
    /// </summary>
    /// <param name="key"></param>
    private void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            EventCenter.GetInstance().EventTrigger(key.ToString() + "����", key);
        }
        if (Input.GetKeyUp(key))
        {
            EventCenter.GetInstance().EventTrigger(key.ToString() + "̧��", key);
        }

    }

    /// <summary>
    /// ���ڼ�������ƶ�
    /// </summary>
    /// <param name="axis"></param>
    private void CheckBodyAxis(string []axis)
    {
        
        EventCenter.GetInstance().EventTrigger<float[]>("ˮƽ�ƶ�", new float[2] { Input.GetAxis(axis[0]), Input.GetAxis(axis[1])}) ;
    }

    /// <summary>
    /// ���ڼ������ƶ�
    /// </summary>
    /// <param name="axis"></param>
    private void CheckMouseAxis(string[] axis)
    {

        EventCenter.GetInstance().EventTrigger<float[]>("����ƶ�", new float[2] { Input.GetAxis(axis[0]), Input.GetAxis(axis[1]) });
    }

    /// <summary>
    /// ���ڼ�ⰴť����
    /// </summary>
    /// <param name="button"></param>
    private void CheckButtonDown(string button)
    {
        if (Input.GetButtonDown(button))
        {
            EventCenter.GetInstance().EventTrigger<string>("��ֱ�ƶ�", button);
        }
        
    }

    private void MyUpdate()
    {
        if (!isStart)
        {
            return;
        }
        CheckBodyAxis(new string[2] { "Horizontal" , "Vertical" });
        CheckMouseAxis(new string[2] { "Mouse X", "Mouse Y" });
        CheckButtonDown("Jump");
        CheckKeyCode(KeyCode.LeftShift);
        CheckMouseButtonDown(0);
    }
    
}
