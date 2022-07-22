using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWeapon : MonoBehaviour
{

    //����ʵ�������ӵ�����
    public GameObject bullet;

    //��Χ
    public float range = 100f;

    //�ӵ�����
    public int bulletNum = 360;

    //һ�����е�װ����
    public int bulletMag = 30;

    //���λ��
    public Transform shootPoint;

    //����ӵ����
    public PlayerObj fatherObj;

    //ǹ�ڻ�����Ч
    public ParticleSystem muzzleFlash;


    private void Start()
    {
        shootPoint = transform.Find("BulletStartPoint");
    }

    public void SetFather(PlayerObj obj)
    {
        fatherObj = obj;
    }

    /// <summary>
    /// ���𷽷�
    /// </summary>
    public void Fire()
    {

        //�����ӵ�Ԥ����
        GameObject obj = Instantiate(bullet, shootPoint.position, shootPoint.rotation);

        //�������Ҳ�����Ч
        ParticleSystem eff = Instantiate<ParticleSystem>(muzzleFlash, shootPoint.position, shootPoint.rotation);
        eff.Play();

        MusicMgr.GetInstance().PlaySound("shoot",gameObject);

        //�����ӵ���ʲô
        Bullet bulletObj = obj.GetComponent<Bullet>();
        bulletObj.SetFather(fatherObj);

    }



}
