//�˴������ Entity.csv �Զ����ɣ���Ҫ�ֶ��޸ģ�������
//���߲˵���Export/CSV_TO_C#    ����ʱ�� �� 6/14/2016 2:19:54 PM
using System;
public class CSVEntity
{
	public uint ID;    //��ɫID
	public string ResPath;    //��ɫģ����Դ·��
	public uint EntityType;    //���ࣨ0=���� 1=���� 2=NPC�Ѿ� 3=NPC�о� 4=BOSS  5=MobaMonster  6=MobaPlayer 7=Moba����  8=Moba����  9=MobaBoss(����) 10=ľ׮ 11=���ˣ�
	public uint Sex;    //�Ա�0=Ů 1=�У�
	public int Level;    //Ĭ�ϵȼ�
	public string Name;    //����
	public string AIName;    //AI����
	public int StarLevel;    //�Ǽ���Ʒ�ʣ�
	public int Type;    //������������(1=�������  2=������� 3=������� 4=��������)
	public int ForceGrowth;    //�����ɳ�
	public int IntelligenceGrowth;    //�����ɳ�
	public int AgileGrowth;    //���ݳɳ�
	public int EnduranceGrowth;    //�����ɳ�
	public int PhysicalAttack;    //������
	public int MagicAttack;    //��������
	public int PhysicalDefense;    //�������
	public int MagicDefense;    //��������
	public int HealthPoint;    //Ѫ��
	public int CriticalRate;    //�����ʣ���֣�
	public int FreeCriticalRate;    //�Ⱪ�ʣ���֣�
	public int AttackSpeed;    //���٣���֣�
	public int MoveSpeed;    //����
	public int RotSpeed;    //ת��
	public string Skill;    //��ʼ����
	public int WarninngRange;    //���䷶Χ������������뾶��
	public int PursuitRange;    //׷����Χ������������뾶��
	public float NameHeight;    //���ָ߶�
	public string shows;    //SID
	public float Size;    //��С��������ײ���ͣ�
	public float Scale;    //���ţ��������ͷŴ������С��
	public uint body;    //����
	public string handl;    //����
	public string handr;    //����
	public int reviveTime;    //����ʱ�䣨�룩
	public uint showname;    //��ʾ����
	public uint DeadTime;    //����ʱ��(����)
}
