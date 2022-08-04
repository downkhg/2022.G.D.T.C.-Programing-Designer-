#include <iostream>
using namespace std;
//데코레이터: 장식을 추가하듯 기존에클래스에 멤버를 추가하여 생성함. 
//상속: 부모클래스가 가진 멤버들 가질 수 있다.
//상속의 메모리구조: 
//생성: 부모클래스부분이 만들어지고, 자식클래스의 부분이 추가 생성되어 만들어진다.
//삭제: 자식부분이 먼제 삭제되고 부모부분이 삭제된다.(스택 구조로 메모리가 생성된다.)
class Cookie
{
	int m_nFlour;
	int m_nSugar;
public:
	Cookie(int flour, int sugar)
	{
		//this: 객체의 주소값.
		cout << "Cookie:" << this << endl;
		m_nFlour = flour;
		m_nSugar = sugar;
	}
	~Cookie()
	{
		cout << "~Cookie:" << this << endl;
	}
};
//자식클래스: 클래스를 상속받아 만들어진 클래스.
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
//계층상속: 자식클래스를 상속받아 클래스를 생성함.
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
	//쿠키틀을 10개 준비한다.
	MilkCookie** pMilkCookies = new MilkCookie * [10];
	//밀크쿠키의 제료를 준비하여 한개씩 틀에 채워넣는다.
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