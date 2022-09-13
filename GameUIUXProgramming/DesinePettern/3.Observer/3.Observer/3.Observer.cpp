#include <iostream>
#include <vector>
using namespace std;
//다음과 같이 모델링할때는 전략자패턴에 가까우나.
//커멘더의 명령에 따라 작동하는것은 비슷하므로 옵져버라고 말할수있다.
class Unit
{
public:
	int x;
	int y;
	//가상함수: 자식객체에서 해당함수를 구현하면 덮어씌울수있는 함수.
	virtual void Attack(Unit* target)
	{
		cout << typeid(*this).name() << "Attack" << endl;
	}
	virtual void Move(int x, int y)
	{
		cout << typeid(*this).name() << "Move:" << x << "," << y << endl;
	}
	virtual void SkillA(Unit* target)
	{
		cout <<"SkillA" << endl;
	}
	virtual void SkillB(Unit* target)
	{
		cout << "SkillB" << endl;
	}
	virtual void SkillC(Unit* target)
	{
		cout << "SkillC" << endl;
	}
};

class Marin : public Unit
{
	void SkillA(Unit* unit) override
	{
		cout << "Active StillPack" << endl;
	}
};

class Medic : public Unit
{
	//부모클래스의 기능과 다른 함수를 선택적으로 오버라이드할수있음.
	//오버라이드: 부모함수의 기능을 새롭게 정의하는 것.
	//동적바인딩: 할당된객체가 달라져서 함수 호출이 변경됨.
	//바인딩: 함수의 호출이 결정되는 것.
	//함수포인터: 호출되는 함수의 주소를 가르켜, 가르키는 주소에 따라 함수가 호출되는 것이 변경됨.
	//포인터: 메모리의 주소값을 저장하는 변수. 
	//메모리: 각 번지마다 주소값을 가지고 있고, 프로그램에서 사용되는 모든것은 메모리에 할당되어 관리된다.
	//ex) 32비트컴퓨너는 ram을 4g지 사용가능하다. 2^32 만큼의 주소값을 할당하고있다.
	void Attack(Unit* unit) override
	{
		Move(unit->x, unit->y);
	}

	void SkillA(Unit* unit) override
	{
		cout << "Active Hill" << endl;
	}

	void SkillB(Unit* unit) override
	{
		cout << "Recovery" << endl;
	}
};

class Commader
{

	vector<Unit*> group;
public:
	enum E_COMMAND { ATK, MOV };

	void AddGroup(Unit* unit)
	{
		group.push_back(unit);
	}

	bool RemvoeGroup(Unit* unit)
	{
		vector<Unit*>::iterator it;
		for (it = group.begin(); it != group.end(); it++)
		{
			if (&unit == &(*it))
				break;
		}
		if (it != group.end())
		{
			group.erase(it);
			return true;
		}
		return false;
	}
	//부대에 명령을 내리는 기능
	void Command(E_COMMAND command, Unit* target)
	{
		switch (command)
		{
		case E_COMMAND::ATK:
			for (int i = 0; i < group.size(); i++)
				group[i]->Attack(target);
			break;
		case E_COMMAND::MOV:
			for (int i = 0; i < group.size(); i++)
				group[i]->Move(10, 10);
			break;
		default:
			break;
		}
	}
};

void main()
{
	//메모리가 정적할당되었다.
	//따로 객체만 생성해서 접근할수있는 상태다.
	Commader cCommder;
	Marin marins[10];
	Medic medics[10];
	//커멘더는 유닛클래스를 상속받은 대상의 주소값이라면,
	//자식이 어느쪽유닛이 되었건 공통적으로 처리할수있다.
	//이렇게 주소값으로 메모리를 가르키는것을 참조라고 부른다.
	for (int i = 0; i < 10; i++)
		cCommder.AddGroup(&marins[i]);

	for (int i = 0; i < 10; i++)
		cCommder.AddGroup(&medics[i]);

	cCommder.Command(Commader::E_COMMAND::ATK, &marins[0]);
}