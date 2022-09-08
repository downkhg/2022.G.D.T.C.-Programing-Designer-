/*##################################
스레드를 이용한 WinAPI데모(수업용)
파일명: WinAppDemo.cpp
작성자: 김홍규 (downkhg@gmail.com)
마지막수정날짜: 2020.12.14
버전: 1.2 (메세지 주소값 출력 및 문제 단계별화)
###################################*/

#include <iostream>
#include <Windows.h>
#include <process.h>
#include <string>
#include <queue>

using namespace std;

enum WM_MSG { CREATE, COMMOND, PAINT, DESTROY, MAX };
string strMSG[MAX] = { "CREATE","COMMOND","PAINT","DESTROY" };

//전역변수: 프로그램이 종료시까지 메모리가 남아있는 변수.
bool g_bLoop = true;
int g_nMsg = false;
queue<int> g_queMsg;

//지역변수: 집밥: 
//전역변수: 배달음식: 
//집에서만 먹을수 있는 음식 : 집밥
//함수에서만 사용수 있는 변수: 지역변수({}를 벗어나면 사용할수 없다)
//어떤집이던 주문 할 수 있는 음식 : 배달음식
//어떤함수던 사용 할 수 있는 변수 : 전역변수({}안에 없으므로 프로그램이 종료시까지 유지된다)

//WndProc과 main이 같이 사용해야하는 변수이므로 지역변수로 선언한다.
//*포인터를 알면 다른함수의 지역변수에도 접근이 가능하다.

//arg를 통해 외부의 데이터값을 받을수있다.
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
				cout << "초기화" << endl;
				//g_nMsg = COMMOND;
				g_queMsg.push(COMMOND);
				break;
			case COMMOND:
				cout << "명령을 입력하세요." << endl;
				for (int i = 0; i < MAX; i++)
					cout << i << ":" << strMSG[i] << ",";
				cout << endl;
				break;
			case PAINT:
				cout << "화면에 그립니다." << endl;
				break;
			case DESTROY:
				cout << "프로그램을 종료합니다." << endl;
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

//입력을 받으면서 화면에 메세지에 필요한 출력을 처리하는 프로그램.
//큐를 활용하여 메세지를 큐에 쌓고, 쓰레드에서 큐에서 데이터를 1개씩꺼내서 처리하는 프로그램으로 만들기.
//1. 큐를 전역변수로 만들어서 처리하기.
//2. 큐를 main의 지역변수로 만들어서 동일한 과정이 가능하도록 처리하기.

int main() //OS가 프로그램이 실행되었을때 가장 먼저 호출하기로 약속된함수.
{
	HANDLE hThread = NULL;
	DWORD dwThreadID = NULL;
	//지역변수: 함수안에서만 존재하는 변수. 함수종료시 삭제된다.
	//int nMSG = CREATE;
	g_nMsg = CREATE;
	cout << "Msg:" << &g_nMsg << endl;
	//프로세스: 프로그램의 가장 기본적인 처리를 당담하는 흐름단위(메인루프), 큰흐름단위.
	//스레드: 프로세스 내부에 처리를 하는 흐름단위(반복문을 동시에 처리가능), 큰흐름 하위의 작은 흐름.
	//스레드는 프로그램 내부에서 처리하는 내용을 변경할수 있어야하므로, 
	//그 프로그램 내의 함수를 호출하여 사용한다.
	//콜백함수: 프로세스내에서 호출하지않고, 외부에서 호출하도록 하는 함수.
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