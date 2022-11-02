#include <stdio.h>
#include <string.h>
void ValPointerMain()
{
	//변수와 포인터의 개념
}

void SwapVal(int a, int b)
{
	int c = a;
	a = b;
	b = c;
}
void SwapPtr(int* a, int* b)
{
	int c = *a;
	*a = *b;
	*b = c;
}
void SwapRef(int& a, int& b)
{
	int c = a;
	a = b;
	b = c;
}
void SwapTestMain()
{
	//Swap함수 구현 및 검증 2~5
}

void ArrayMain()
{
	//배열과 포인터 알고리즘
}
void Array2DTestMain()
{
	//2차원배열과 1차원배열의 2차원 활용
}
//#include <string.h> 필요
void StringCopyMain()
{
	char strLastName[10];
	char strFirstName[10];
	char strFullName[20];

	strcpy_s(strLastName, "game");
	strcpy_s(strFirstName, "program");

	strcpy_s(strFullName, strLastName);
	strcat_s(strFullName, strFirstName);
	printf("LastName:%s\n", strLastName);
	printf("FirstName:%s\n", strFirstName);
	printf("FullName:%s\n", strFirstName);

	int idx = 0;
	while (strFullName[idx] != '\0')
		printf("[%d]:%c\n", idx, strFullName[idx]);
}
void main()
{
	//각함수들을 1개씩 실행해보고 어떻게 작동하는지 확인하기
	ValPointerMain();
	SwapTestMain();
	ArrayMain();
	Array2DTestMain();
	StringCopyMain();
}

