#pragma once
//������ο��� ��������� �ҷ��ð��
//��������� �������ų� ��������� �߻��ϹǷ�,
//������ ���� �ܼ��� �����ϰų� �׳� ���ڸ� ����ϴ� ���� ����.
#define NULL 0
//Ŭ������ ����: �̷��� Ŭ������ �ִٴ� ���� �˸�.
class Context;
class StateOne;
class StateTow;
class StateThree;
//Ŭ������ ����: Ŭ������ ����� ����� �ִ��� Ȯ���Ҽ�����.
//�����ͳ� �����ڴ� ����� ����Ű�⶧����, ���¿� ��� ���� ���� ���θ� �˸� ��밡���ϴ�.
//�׷��Ƿ� ���𸸵� ����� ����ų�� Ȱ���Ҽ��ִ�.
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
	///�ر׷��� friend�� ��������ʵ��� ������.
	//������ ���� friendŬ������ Ȱ���Ͽ�
	//SetState�� �ܺο����� ������� ��������,
	//�� State��ü������ ���ٰ����ϵ��� �Ҽ��� �ִ�.
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
