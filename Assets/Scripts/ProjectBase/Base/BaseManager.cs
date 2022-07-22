using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.C#�� ���͵�֪ʶ
//2.���ģʽ�� ����ģʽ��֪ʶ
//���ٵ���ģʽ���ظ�����ĳ���
public class BaseManager<T> where T:new()
{
    /*һ�ּ��д��
    private static T instance = new T();
    public static T Instance => instance;
     */
    private static T instance;

    public static T GetInstance()
    {
        if(instance == null)
        {
            instance = new T();
        }
        return instance;
    }

}
