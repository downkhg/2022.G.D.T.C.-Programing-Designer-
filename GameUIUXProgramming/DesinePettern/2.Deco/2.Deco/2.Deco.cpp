#include <iostream>
using namespace std;
//���ڷ�����: ����� �߰��ϵ� ������Ŭ������ ����� �߰��Ͽ� ������. 
//���: �θ�Ŭ������ ���� ����� ���� �� �ִ�.
//����� �޸𸮱���: 
//����: �θ�Ŭ�����κ��� ���������, �ڽ�Ŭ������ �κ��� �߰� �����Ǿ� ���������.
//����: �ڽĺκ��� ���� �����ǰ� �θ�κ��� �����ȴ�.(���� ������ �޸𸮰� �����ȴ�.)
class Cookie
{
	int m_nFlour;
	int m_nSugar;
public:
	Cookie(int flour, int sugar)
	{
		//this: ��ü�� �ּҰ�.
		cout << "Cookie:" << this << endl;
		m_nFlour = flour;
		m_nSugar = sugar;
	}
	~Cookie()
	{
		cout << "~Cookie:" << this << endl;
	}
};
//�ڽ�Ŭ����: Ŭ������ ��ӹ޾� ������� Ŭ����.
class MilkCookie : public Cookie
{
	int m_nMilk;
public:
	MilkCookie(int flour, int sugar, int milk) :Cookie(flour, sugar)
	{
		cout << "MilkCookie:" << this << endl;
		m_nMilk = milk;
	}
	~MilkCookie()
	{
		cout << "~MilkCookie:" << this << endl;
	}
};
class ChocoCookie : public Cookie
{
	int m_nChoco;
public:
	ChocoCookie(int flour, int sugar, int choco) :Cookie(flour, sugar)
	{
		cout << "ChocoCookie:" << this << endl;
		m_nChoco = choco;
	}
	~ChocoCookie()
	{
		cout << "~ChocoCookie:" << this << endl;
	}
};
//�������: �ڽ�Ŭ������ ��ӹ޾� Ŭ������ ������.
class AmondChocoCookie : public ChocoCookie
{
	int m_nAmond;
public:
	AmondChocoCookie(int flour, int sugar, int choco, int amond) :ChocoCookie(flour, sugar, choco)
	{
		cout << "AmondChocoCookie:" << this << endl;
		m_nAmond = amond;
	}
	~AmondChocoCookie()
	{
		cout << "~AmondChocoCookie:" << this << endl;
	}
};
int main()
{
	Cookie cCookie(100, 20);
	//MilkCookie cMilkCookie[10]{ MilkCookie(100,20,10), };
	//��ŰƲ�� 10�� �غ��Ѵ�.
	MilkCookie** pMilkCookies = new MilkCookie * [10];
	//��ũ��Ű�� ���Ḧ �غ��Ͽ� �Ѱ��� Ʋ�� ä���ִ´�.
	for (int i = 0; i < 10; i++)
	{
		pMilkCookies[i] = new MilkCookie(100, 20, 20);
	}

	for (int i = 0; i < 10; i++)
	{
		delete(pMilkCookies[i]);
	}

	delete[] pMilkCookies;

	AmondChocoCookie cAmondChcoCookie(100, 20, 50, 10);
}