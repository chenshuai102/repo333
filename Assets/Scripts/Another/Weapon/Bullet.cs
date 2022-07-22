using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�ƶ��ٶ�
    public float moveSpeed = 0.1f;
    
    //˭�������
    public PlayerObj fatherObj;

    //�ӵ�������Ч
    public GameObject effObj;
    public GameObject effObj2;
    void Start()
    {
        
    }


    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }


    public void SetFather(PlayerObj obj)
    {
        fatherObj = obj;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            //���ӵ�����ʱ�����Դ���һ������
            if(effObj != null)
            {
                GameObject eff = Instantiate(effObj,this.transform.position,this.transform.rotation);
                GameObject eff2 = Instantiate(effObj2, this.transform.position, this.transform.rotation);
            }

            Destroy(this.gameObject);
        }

    }
}
