//�˴������ Skill.csv �Զ����ɣ���Ҫ�ֶ��޸ģ�������
//���߲˵���Export/CSV_TO_C#    ����ʱ�� �� 6/17/2016 3:00:31 PM
using System;
public class CSVSkill
{
	public uint ID;    //����ID
	public uint type;    //��������(1.�չ� 2.���� 3.���� 4.���� 5.���� 6.���� 7.�ٻ� 8.����)
	public string name;    //��������
	public uint cameraEffect;    //��ĻЧ��(1.���� 2.�䰵 3.����)
	public string skillIcon;    //����ͼ��
	public string skillIntro;    //��������
	public uint damageCoefficient;    //����ϵ��(�˺� / �ٻ���ID)
	public uint level;    //���ܵȼ� 
	public uint attackType;    //ʩ����Χ���� 1.��������  2.�Լ�  3.����(����Ϊ��� �������λ��) 4.����(������Ϊ��� Ĭ��120��) 5.Բ��(���Ϊԭ�������Ϊԭ��)
	public float attackDistance;    //ʩ������(��λ��)
	public float guideTime;    //����ʱ��
	public float hitTime;    //����ʱ��(���ܼ���սʿ�����ֲ����л���ʱ�����ģ�ͻ���ʧ)
	public float coolTime;    //��ȴʱ��
	public uint attackBuff;    //����Ч��(BUFF)
	public uint studyCost;    //ѧϰ�����Ǯ
	public string studyMat;    //ѧϰ������� ��������ϸ�ʽ150112*1|150112*3��
	public uint InitSkill;    //��ʼ����
	public uint preSkill;    //ǰ�ü���
	public uint nextSkill;    //�¼�����
	public float flySpeed;    //�켣�����ٶ�
	public string guideEffect;    //ָ����Ч��100/101��
	public float guideEffectBeginTime;    //ָ����Ч��ʼʱ�䣨�Ӽ��ܴ���ʱ�俪ʼ�㣩
	public float guideEffectDuration;    //ָ����Ч����ʱ��
	public string castEffect;    //�ͷ���Ч
	public float castEffectBeginTime;    //�ͷ���Ч��ʼʱ��
	public float castEffectDuration;    //�ͷ���Ч����ʱ��
	public string castEffectBindBone;    //�ͷ���Ч�󶨹���
	public string BulletEffect;    //�ӵ���Ч
	public float BulletBeginTime;    //�ӵ���ʼʱ��
	public string BulletBindBone;    //�ӵ��󶨹���
	public string beattackEffect;    //�ܻ���Ч
	public string guideAction;    //ָ������
	public float guideActionBeginTime;    //ָ��������ʼʱ��
	public float guideActionDuration;    //ָ����������ʱ��
	public string castAction;    //�ͷŶ���
	public float castActionBeginTime;    //�ͷŶ�����ʼʱ��
	public float castActionDuration;    //�ͷŶ�������ʱ��
	public string beattackAction;    //�ܻ�����
	public float beattackActionBeginTime;    //�ܻ�������ʼʱ��
	public float beattackActionDuration;    //�ܻ���������ʱ��
	public uint sound;    //����
}
