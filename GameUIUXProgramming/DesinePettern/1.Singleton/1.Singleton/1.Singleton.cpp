#include <iostream>
using namespace std;
//다른 객체지향언어와 C++의 차이점.
//(동적할당 메모리)언매니지드언어: 동적할당된 메모리를 프로그래머가 직접 해제해야함.(스마트포인터는 모던C++에 추가되었고 기본기능은 아님)

//클래스: 클래스(설계도)를 이용하여 객체여러개를 만드는것.
//객체: 클래스를 이용하여 실제 활용가능한 것으로 생성(메모리할당 == 변수생성)하는것.
//싱글톤: 객체가 1개이상 생성되지않는 클래스를 만드는 것.
class SingleObject
{
	//정적맴버변수: 클래스에서 1개만 존재하며, 모든 객체가 공유하는 변수.
	static SingleObject* m_pInstance;
	//생성자: 객체가 생성될때 호출되는 함수. 생성자가 private이면 객체생성을 객체외부에서 수행할수없음.
	SingleObject() { cout << "SingleObject:" << this << endl; }
	int m_nData;
public:
	~SingleObject() { cout << "~SingleObject:" << this << endl; }
	//객체가 없을 경우 객체를 생성하여 리턴하고, 있는경우 생성하지않고, 리턴한다.
	//즉, 객체가 1개이상 생성할수 없게 강제한다.
 
	//정적멤버함수: 객체가 생성되기전에 접근가능한 함수.
	static SingleObject* GetInstance()
	{
		cout << "GetInstance Start:" << endl;
		if (m_pInstance == NULL)
			m_pInstance = new SingleObject(); //동적할당: 프로그램이 실행하는 중에 메모리를 생성하는 것.
		cout << "GetInstance End:" << endl;
		return m_pInstance;
	}
	void ShowMessage()
	{
		cout << this << " SingleObject ShowMSG[" << &m_nData << "]:" << m_nData << endl;
	}
	//메모리누수: 동적할당된 메모리를 프로그램종료시에 삭제하지않아, 사용중이지않은 메모리가 메모리를 차지함.
	void Release()
	{
		delete m_pInstance; 
	}
};
//배달음식(전역변수)를 시키면 집(함수)에서 먹을수 있다.
//집밥(지역변수)는 집(함수)에서만 먹을수있다.

//정적할당: 메모리를 생성할때 컴파일러가 생성시점과 삭제시점을 미리 정하는 변수.
//지역변수: 함수안에서만 사용가능한 변수
//전역변수: 프로그램이 종료시까지 메모리가 남아있는 변수. 

//정적멤버 변수는 객체가 생성되기전부터 생성되어야하므로,
//프로그램이 종료될때까지 메모리가 유지되어야한다.(전역변수)
//전역변수를 이용하면 프로그램이 종료시까지 메모리가 남아있으므로 모든 클래스들이 공유 가능한 상태가 된다.
SingleObject* SingleObject::m_pInstance;

//싱글톤: 클래스의 인스턴스가 1개이상 존재 할수없는 클래스를 만드는 기법.(생성자 은닉,정적멤버)
int main()
{
	//정적할당되는지 가능한가?
	//싱글톤은 반드시 객체가 1개여야하므로,
	//다음과 같은 생성이 가능하면 안된다. 
	//그러므로, private으로 만든다.
	//SingleObject cSingleObject[100];
	//포인터는 대상을 직접 메모리가 할당되는 것이 아니므로,
	//여러개가 생성된다고해도 객체가 생긴것은 아니다.
	SingleObject* pSingleObjectA = NULL;
	SingleObject* pArrSingleObjects[2] = {};
	//동적할당은 가능한가?
	//동적할당도 객체를 생성할때는 생성자가 public이여만 가능하다.
	//pSingleObjectA = new SingleObject();
	//객체가 생성전인데 일반멤버에 접근하는것은 원칙적으로는 불가능하나, 함수는 객체 생성전부터 존재할수있으며,
	//메모리를 사용하여 접근하는데는 지장이 없으므로 실행이 가능하다. 단, 객체가 일반멤버변수를 출력하려고한다면, 
	//일반 멤버는 객체가 생성되기전에 접근이 불가능하므로, 컴파일오류가 나게된다.
	//pSingleObjectA->ShowMessage(); 
	pSingleObjectA = SingleObject::GetInstance();
	//SingleObject::ShowMessage(); //일반멤버함수는 객체가 생성전에 접근이 불가능하므로 다음과같은 문법을 활용할수 없다.
	pSingleObjectA->ShowMessage();
	for (int i = 0; i < 2; i++)
		pArrSingleObjects[i] = SingleObject::GetInstance();

	cout << "pSingleObjectA:" << pSingleObjectA << endl;
	for (int i = 0; i < 2; i++)
	{
		cout << "pSingleObject[" << i << "]:" << pArrSingleObjects[i] << endl;
		pArrSingleObjects[i]->ShowMessage();
	}
	//인스턴스가 1개이므로 굳이 여러번 불러줄필요는 없다.
	pSingleObjectA->Release();
}