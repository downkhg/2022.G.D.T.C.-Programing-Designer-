#include <stdio.h>
#include <string.h>
void ValPointerMain()
{
	//������ �������� ����
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
	//Swap�Լ� ���� �� ���� 2~5
}

void ArrayMain()
{
	//�迭�� ������ �˰���
}
void Array2DTestMain()
{
	//2�����迭�� 1�����迭�� 2���� Ȱ��
}
//#include <string.h> �ʿ�
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
	//���Լ����� 1���� �����غ��� ��� �۵��ϴ��� Ȯ���ϱ�
	ValPointerMain();
	SwapTestMain();
	ArrayMain();
	Array2DTestMain();
	StringCopyMain();
}

