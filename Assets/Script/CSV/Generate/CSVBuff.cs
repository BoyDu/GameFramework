//�˴������ Buff.csv �Զ����ɣ���Ҫ�ֶ��޸ģ�������
//���߲˵���Export/CSV_TO_C#    ����ʱ�� �� 6/23/2016 4:18:44 PM
using System;
public class CSVBuff
{
	public int ID;    //buffid
	public int Type;    //����(1.���� 2.���� 3.����⻷ 4.����⻷)
	public int TiggerRate;    //�������ʣ��ٷֱȣ�
	public int TiggerImpact;    //����Ч��(0=��Ч�� 1=Ѫ�� 2=�﹥ 3=��� 4=���� 5=���� 6=���� 7=�Ⱪ 8=�ٶ� 9=���� 10=������/��Ѫ(�ж�������) 11=ѣ��(����) 12=��Ѫ 13=Ѫ���޻��� 14=(��)�˺����/���� 15=(��)�˺�����/��� 16=���� 17=�ٻ��Ա� 18=���ܺ��չ��˺� 19=ʹ������Ч�� 20=��������Ч�� 21=���� 22=���� 23=����ʩ�� 24=���� 25=ɱ�л�Ѫ 26=��ɢ���� 27=�����α��ˣ�
	public int ValueType;    //�������� 1.�̶�ֵ�������˺��� 2.�ٷֱ�  3.�������ٷֱ� 4.���������ٷֱ� 5.BUFFID
	public float Value;    //����
	public int KeepTime;    //����ʱ��(����)
	public int Time;    //���ô���
	public int DeathToClear;    //�����Ƿ����(1.��� 2.�������
	public int ResultMutex;    //Ч�����⣨��BUFF�� ������BUFF�ͷ���Ч��
	public int OverlayMode;    //Ч���������BUFF�����Ч�������BUFF��
	public int Buffhandle;    //һ��buff��־(ͬ��buff��ͬ ��ͬ�ֲ�ͬ)
	public int BuffLevel;    //buff�ȼ�
	public string Icon;    //ͼ��
	public string EffectName;    //��Ч
	public string BindBone;    //��Ч�󶨹���
	public string Name;    //buff����
	public string Intro;    //Ч������
}
