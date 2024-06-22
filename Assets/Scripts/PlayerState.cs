using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private GameObject[] objArray;

    // Start is called before the first frame update
    void Start()
    {
        //objArray��Ground�^�O���������I�u�W�F�N�g�B��z��Ɋi�[������
        objArray = GameObject.FindGameObjectsWithTag("Ground");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�z��̗v�f��obj�Ɏ擾
        foreach (GameObject obj in objArray)
        {
            //yuka�ɂ��ׂĂ̔z���YUKAcontroller���擾������
            YUKAcontroller yuka = obj.GetComponent<YUKAcontroller>();

            //yuka �ɃR���|�[�l���g������A playerInHole �t���O��ture�̎�
            if (yuka != null && yuka.playerInHole == true)
            {
                //player�̉��ɂ���I�u�W�F�N�g��obj�Ɋi�[����Ă�����̂Ɠ����ꍇ
                if (collision.gameObject == obj)
                {
                    //���̃I�u�W�F�N�g��j�󂷂�
                    Destroy(gameObject);
                    Debug.LogWarning("�������`���b�^");
                    break;
                }
            }
        }
    }
}
