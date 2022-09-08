/*##################################
�����带 �̿��� WinAPI����(������)
���ϸ�: WinAppDemo.cpp
�ۼ���: ��ȫ�� (downkhg@gmail.com)
������������¥: 2020.12.14
����: 1.2 (�޼��� �ּҰ� ��� �� ���� �ܰ躰ȭ)
###################################*/

#include <iostream>
#include <Windows.h>
#include <process.h>
#include <string>
#include <queue>

using namespace std;

enum WM_MSG { CREATE, COMMOND, PAINT, DESTROY, MAX };
string strMSG[MAX] = { "CREATE","COMMOND","PAINT","DESTROY" };

//��������: ���α׷��� ����ñ��� �޸𸮰� �����ִ� ����.
bool g_bLoop = true;
int g_nMsg = false;
queue<int> g_queMsg;

//��������: ����: 
//��������: �������: 
//�������� ������ �ִ� ���� : ����
//�Լ������� ���� �ִ� ����: ��������({}�� ����� ����Ҽ� ����)
//����̴� �ֹ� �� �� �ִ� ���� : �������
//��Լ��� ��� �� �� �ִ� ���� : ��������({}�ȿ� �����Ƿ� ���α׷��� ����ñ��� �����ȴ�)

//WndProc�� main�� ���� ����ؾ��ϴ� �����̹Ƿ� ���������� �����Ѵ�.
//*�����͸� �˸� �ٸ��Լ��� ������������ ������ �����ϴ�.

//arg�� ���� �ܺ��� �����Ͱ��� �������ִ�.
unsigned int WINAPI WndProc(void* arg)
{
	cout << "WndProc Start: arg:" << arg << endl;
	//int* pData = (int*)arg;
	//int nMsg = *pData;


	while (g_bLoop)
	{
		if (!g_queMsg.empty())
		{
			int nMsg = g_queMsg.front();
			g_queMsg.pop();

			switch (nMsg)
			{
			case CREATE:
				cout << "�ʱ�ȭ" << endl;
				//g_nMsg = COMMOND;
				g_queMsg.push(COMMOND);
				break;
			case COMMOND:
				cout << "����� �Է��ϼ���." << endl;
				for (int i = 0; i < MAX; i++)
					cout << i << ":" << strMSG[i] << ",";
				cout << endl;
				break;
			case PAINT:
				cout << "ȭ�鿡 �׸��ϴ�." << endl;
				break;
			case DESTROY:
				cout << "���α׷��� �����մϴ�." << endl;
				g_bLoop = false;
				break;
			default:
				break;
			}
			Sleep(2000);
		}
		else
			cout << " QueueSize:" << g_queMsg.size() << endl;
	}
	cout << "WndProc End arg:" << arg << endl;
	return 0;
}

//�Է��� �����鼭 ȭ�鿡 �޼����� �ʿ��� ����� ó���ϴ� ���α׷�.
//ť�� Ȱ���Ͽ� �޼����� ť�� �װ�, �����忡�� ť���� �����͸� 1���������� ó���ϴ� ���α׷����� �����.
//1. ť�� ���������� ���� ó���ϱ�.
//2. ť�� main�� ���������� ���� ������ ������ �����ϵ��� ó���ϱ�.

int main() //OS�� ���α׷��� ����Ǿ����� ���� ���� ȣ���ϱ�� ��ӵ��Լ�.
{
	HANDLE hThread = NULL;
	DWORD dwThreadID = NULL;
	//��������: �Լ��ȿ����� �����ϴ� ����. �Լ������ �����ȴ�.
	//int nMSG = CREATE;
	g_nMsg = CREATE;
	cout << "Msg:" << &g_nMsg << endl;
	//���μ���: ���α׷��� ���� �⺻���� ó���� ����ϴ� �帧����(���η���), ū�帧����.
	//������: ���μ��� ���ο� ó���� �ϴ� �帧����(�ݺ����� ���ÿ� ó������), ū�帧 ������ ���� �帧.
	//������� ���α׷� ���ο��� ó���ϴ� ������ �����Ҽ� �־���ϹǷ�, 
	//�� ���α׷� ���� �Լ��� ȣ���Ͽ� ����Ѵ�.
	//�ݹ��Լ�: ���μ��������� ȣ�������ʰ�, �ܺο��� ȣ���ϵ��� �ϴ� �Լ�.
	/*hThread = (HANDLE)_beginthreadex(NULL, 0,
		WndProc,
		(void*)&nMSG, 0,
		(unsigned int*)dwThreadID);*/
	hThread = (HANDLE)_beginthreadex(NULL, 0,
		WndProc,
		NULL, 0,
		(unsigned int*)dwThreadID);

	while (g_bLoop)
	{
		scanf_s("%d", &g_nMsg);
		g_queMsg.push(g_nMsg);
	}

	return 0;
}