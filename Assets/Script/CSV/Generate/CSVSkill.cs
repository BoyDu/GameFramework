//�˴������ Skill.csv �Զ����ɣ���Ҫ�ֶ��޸ģ�������
//���߲˵���Export/CSV_TO_C#    ����ʱ�� �� 6/14/2016 2:19:54 PM
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
	public uint targetTpye;    //ѡ��Ŀ������ 1.ָ��Ŀ�� 2.�Լ� 3.�����ѷ� 4.Ѫ�������ѷ�
	public uint attackType;    //ʩ����ʽ 1.�󶨼���(��ս)2.��Χ���� 3.�ӵ�(��Ŀ��) 4.�ӵ�(��Ŀ��)
	public uint miagcType;    //ʩ����Χ���� 1.�� 2.����(����Ϊ��� �������λ��)3.����(������Ϊ��� Ĭ��120��)4.Բ��(���Ϊԭ�������Ϊԭ��)
	public float attackDistance;    //ʩ������(��λ����)
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
	public string flyEffect;    //�ӵ���Ч
	public uint beattackEffect;    //�ܻ���Ч(buff)
	public string guideAction;    //ָ������
	public float guideActionBeginTime;    //ָ��������ʼʱ��
	public float guideActionDuration;    //ָ����������ʱ��
	public string castAction;    //�ͷŶ���
	public float castActionBeginTime;    //�ͷŶ�����ʼʱ��
	public float castActionDuration;    //�ͷŶ�������ʱ��
	public string beattackAction;    //�ܻ�����
	public float beattackActionBeginTime;    //�ܻ�������ʼʱ��
	public float beattackActionDuration;    //�ܻ���������ʱ��
	public float comboBeginTime;    //����������տ�ʼʱ��
	public float comboEndTime;    //����������ճ���ʱ��
	public uint sound;    //����
	public int isCD;    //�Ƿ�CD ��ʼ״̬����CD״̬:1.������CD״̬ 2.����CD״̬
}
