#include "State.h"
#include <iostream>
//클래스멤버함수의 정의: 클래스의 정에서 선언된  함수들을 정의한다.
//추후 라이브러리로 빌드하여, 코드를 유출하지않고, 사용하도록만들수있다.
//ex) 유니티api...
//클래스멤버함수를 정의할때 각 객체의 함수의 기능을 모르면 활용이 불가능하므로.
//멤버함수의 정의만 따롸 빼서 선언된 객체를 활용하도록 할수있다.
void StateThree::GoNext(Context* context)
{
	context->SetState(new StateOne);
}

void StateTow::GoNext(Context* context) 
{
	context->SetState(new StateThree);
}

void StateOne::GoNext(Context* context)
{
	context->SetState(new StateTow);
}

Context::Context()
{
	m_pState = new StateOne();
}

Context::Context(State* state)
{
	m_pState = state;
}

Context::~Context()
{
	delete m_pState;
}

void Context::SetState(State* newState)
{
	if (m_pState) delete m_pState;
	std::cout << "SetState:" << typeid(*newState).name() << std::endl;
	m_pState = newState;
}

void Context::GoNext()
{
	m_pState->GoNext(this);
}
