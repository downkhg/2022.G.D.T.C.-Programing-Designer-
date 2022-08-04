#include <iostream>
using namespace std;
//�ٸ� ��ü������� C++�� ������.
//(�����Ҵ� �޸�)��Ŵ�������: �����Ҵ�� �޸𸮸� ���α׷��Ӱ� ���� �����ؾ���.(����Ʈ�����ʹ� ���C++�� �߰��Ǿ��� �⺻����� �ƴ�)

//Ŭ����: Ŭ����(���赵)�� �̿��Ͽ� ��ü�������� ����°�.
//��ü: Ŭ������ �̿��Ͽ� ���� Ȱ�밡���� ������ ����(�޸��Ҵ� == ��������)�ϴ°�.
//�̱���: ��ü�� 1���̻� ���������ʴ� Ŭ������ ����� ��.
class SingleObject
{
	//�����ɹ�����: Ŭ�������� 1���� �����ϸ�, ��� ��ü�� �����ϴ� ����.
	static SingleObject* m_pInstance;
	//������: ��ü�� �����ɶ� ȣ��Ǵ� �Լ�. �����ڰ� private�̸� ��ü������ ��ü�ܺο��� �����Ҽ�����.
	SingleObject() { cout << "SingleObject:" << this << endl; }
	int m_nData;
public:
	~SingleObject() { cout << "~SingleObject:" << this << endl; }
	//��ü�� ���� ��� ��ü�� �����Ͽ� �����ϰ�, �ִ°�� ���������ʰ�, �����Ѵ�.
	//��, ��ü�� 1���̻� �����Ҽ� ���� �����Ѵ�.
 
	//��������Լ�: ��ü�� �����Ǳ����� ���ٰ����� �Լ�.
	static SingleObject* GetInstance()
	{
		cout << "GetInstance Start:" << endl;
		if (m_pInstance == NULL)
			m_pInstance = new SingleObject(); //�����Ҵ�: ���α׷��� �����ϴ� �߿� �޸𸮸� �����ϴ� ��.
		cout << "GetInstance End:" << endl;
		return m_pInstance;
	}
	void ShowMessage()
	{
		cout << this << " SingleObject ShowMSG[" << &m_nData << "]:" << m_nData << endl;
	}
	//�޸𸮴���: �����Ҵ�� �޸𸮸� ���α׷�����ÿ� ���������ʾ�, ������������� �޸𸮰� �޸𸮸� ������.
	void Release()
	{
		delete m_pInstance; 
	}
};
//�������(��������)�� ��Ű�� ��(�Լ�)���� ������ �ִ�.
//����(��������)�� ��(�Լ�)������ �������ִ�.

//�����Ҵ�: �޸𸮸� �����Ҷ� �����Ϸ��� ���������� ���������� �̸� ���ϴ� ����.
//��������: �Լ��ȿ����� ��밡���� ����
//��������: ���α׷��� ����ñ��� �޸𸮰� �����ִ� ����. 

//������� ������ ��ü�� �����Ǳ������� �����Ǿ���ϹǷ�,
//���α׷��� ����ɶ����� �޸𸮰� �����Ǿ���Ѵ�.(��������)
//���������� �̿��ϸ� ���α׷��� ����ñ��� �޸𸮰� ���������Ƿ� ��� Ŭ�������� ���� ������ ���°� �ȴ�.
SingleObject* SingleObject::m_pInstance;

//�̱���: Ŭ������ �ν��Ͻ��� 1���̻� ���� �Ҽ����� Ŭ������ ����� ���.(������ ����,�������)
int main()
{
	//�����Ҵ�Ǵ��� �����Ѱ�?
	//�̱����� �ݵ�� ��ü�� 1�������ϹǷ�,
	//������ ���� ������ �����ϸ� �ȵȴ�. 
	//�׷��Ƿ�, private���� �����.
	//SingleObject cSingleObject[100];
	//�����ʹ� ����� ���� �޸𸮰� �Ҵ�Ǵ� ���� �ƴϹǷ�,
	//�������� �����ȴٰ��ص� ��ü�� ������� �ƴϴ�.
	SingleObject* pSingleObjectA = NULL;
	SingleObject* pArrSingleObjects[2] = {};
	//�����Ҵ��� �����Ѱ�?
	//�����Ҵ絵 ��ü�� �����Ҷ��� �����ڰ� public�̿��� �����ϴ�.
	//pSingleObjectA = new SingleObject();
	//��ü�� �������ε� �Ϲݸ���� �����ϴ°��� ��Ģ�����δ� �Ұ����ϳ�, �Լ��� ��ü ���������� �����Ҽ�������,
	//�޸𸮸� ����Ͽ� �����ϴµ��� ������ �����Ƿ� ������ �����ϴ�. ��, ��ü�� �Ϲݸ�������� ����Ϸ����Ѵٸ�, 
	//�Ϲ� ����� ��ü�� �����Ǳ����� ������ �Ұ����ϹǷ�, �����Ͽ����� ���Եȴ�.
	//pSingleObjectA->ShowMessage(); 
	pSingleObjectA = SingleObject::GetInstance();
	//SingleObject::ShowMessage(); //�Ϲݸ���Լ��� ��ü�� �������� ������ �Ұ����ϹǷ� ���������� ������ Ȱ���Ҽ� ����.
	pSingleObjectA->ShowMessage();
	for (int i = 0; i < 2; i++)
		pArrSingleObjects[i] = SingleObject::GetInstance();

	cout << "pSingleObjectA:" << pSingleObjectA << endl;
	for (int i = 0; i < 2; i++)
	{
		cout << "pSingleObject[" << i << "]:" << pArrSingleObjects[i] << endl;
		pArrSingleObjects[i]->ShowMessage();
	}
	//�ν��Ͻ��� 1���̹Ƿ� ���� ������ �ҷ����ʿ�� ����.
	pSingleObjectA->Release();
}