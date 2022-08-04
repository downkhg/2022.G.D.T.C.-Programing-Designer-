#pragma once
//헤더내부에서 헤더파일을 불러올경우
//빌드과정이 느려지거나 헤더꼬임이 발생하므로,
//다음과 같이 단순히 정의하거나 그냥 숫자를 사용하는 것이 좋다.
#define NULL 0
//클래스의 선언: 이러한 클래스가 있다는 것을 알림.
class Context;
class StateOne;
class StateTow;
class StateThree;
//클래스의 정의: 클래스의 멤버가 어떤것이 있는지 확인할수있음.
//포인터나 참조자는 대상을 가르키기때문에, 형태와 상관 없이 존제 여부만 알면 사용가능하다.
//그러므로 선언만된 대상을 가르킬때 활용할수있다.
class State
{
	friend class Context;
public:
	virtual void GoNext(Context* context) = 0;
};


class StateThree : public State
{
public:
	void GoNext(Context* context) override;
};

class StateTow : public State
{
public:
	void GoNext(Context* context) override;
};


class StateOne : public State
{
public:
	void GoNext(Context* context) override;
};

class Context
{
	State* m_pState = NULL;
	///※그러나 friend는 사용하지않도록 권장함.
	//다음과 같이 friend클래스를 활용하여
	//SetState를 외부에서는 사용하지 못하지만,
	//각 State객체에서는 접근가능하도록 할수도 있다.
	friend class StateOne;
	friend class StateTow;
	friend class StateThree;

	void SetState(State* newState);
public:
	Context();
	Context(State* curState);
	~Context();
	void GoNext();
};
