#pragma once

#include <iostream>
#include <list>

using namespace std;
//도형과 같이 공통적인 특징이 속성이 없고 동작만 존재하는 클래스를 굳이 상속관계로 만들필요가 없다.
namespace Inheritance
{
	//1차원이라면 객체로 볼수없다.
	struct Vector//객체: 벡터(2차원 위치)
	{
		//public:
		float x;
		float y;
		Vector(float x = 0, float y = 0)
		{
			this->x = x;
			this->y = y;
		}
		void Print(const char* msg)
		{
			cout << msg << "(" << x << "," << y << ")" << endl;
		}
	};

	class Shape //도형:
	{
	public:
		Shape()
		{
			cout << "Shape[" << this << "]" << sizeof(*this) << endl;
		}
		~Shape()
		{
			cout << "~Shape[" << this << "]" << endl;
		}
		//부모의 함수, 자식에서 상속받아 같은이름으로 만들었더라도, 전혀 다른함수다.
		void Draw()
		{
			cout << "Shape[" << this << "]::Draw()" << endl;
		};
	};
	//원과 같이 삼각형,사각형을 클래스로 만들기
	class Circle : public Shape
	{
		Vector vPos;
		float fRadius;
	public:
		Circle(Vector pos = Vector(), float rad = 1)
		{
			cout << "Circle[" << this << "]" << sizeof(*this) << endl;
			vPos = pos;
			fRadius = rad;

			cout << "Rad:" << fRadius << endl;
		}
		~Circle()
		{
			cout << "~Circle[" << this << "]()" << endl;
		}
		void Draw()
		{
			cout << "Circle[" << this << "]::Draw()" << endl;
			vPos.Print("Pos");
			cout << "Rad:" << fRadius << endl;
		}
	};
	class TriAngle : public Shape
	{
		Vector vA;
		Vector vB;
		Vector vC;
	public:
		TriAngle(Vector a = Vector(), Vector b = Vector(), Vector c = Vector()) { cout << "TriAngle[" << this << "]" << sizeof(*this) << endl; };
		~TriAngle() { cout << "TriAngle[" << this << "]" << endl; };
		void Draw()
		{
			cout << "TriAngle[" << this << "]::Draw()" << endl;
			vA.Print("A:");
			vB.Print("B:");
			vC.Print("C:");
		}
	};
	class RectAangle : public Shape
	{
		Vector vTL;
		Vector vBR;
	public:
		RectAangle(Vector tl = Vector(), Vector br = Vector())
		{
			cout << "RectAangle[" << this << "]" << sizeof(*this) << endl;
			vTL = tl;
			vBR = br;
		}
		~RectAangle()
		{
			cout << "~RectAangle[" << this << "]()" << endl;
		}
		void Draw()
		{
			cout << "RectAangle[" << this << "]::Draw()" << endl;
			vTL.Print("TopLeft:");
			vBR.Print("BottomRight:");
		}
	};

	//부모의 부분과 자식의 부분은 메모리가 다르다. 
	//결국 상속을 통해서 두개의 같은이름의 함수를 가진다.
	void ShapeMain()
	{
		Shape cShape;
		Circle cCrilce({ 1,1 }, 1);
		cShape.Draw();
		cShape.Shape::Draw();
		cCrilce.Draw();
		cCrilce.Shape::Draw();
	}
	//프로그램 실행중에 선택하여 모양을 여러개를 그리려면 어떻게해야하는가?//동적으로 메모리를 할당받아야한다.
	void RuntimeShapeDrawMain()
	{
		void** arrShape;
		arrShape = new void* [3];

		arrShape[0] = (void*)new Circle();
		arrShape[1] = (void*)new RectAangle();
		arrShape[2] = (void*)new TriAngle();

		//for (int i = 0; i < 3; i++)
		//	(Shape*)arrShape[i]->Draw();
		((Circle*)arrShape[0])->Draw();
		((RectAangle*)(arrShape[1]))->Draw();
		((TriAngle*)(arrShape[2]))->Draw();
	}
	void PowerPointTestMain()
	{
		cout << "#### Inheritance::PowerPointTestMain Start #####" << endl;
		list<Shape*> listShapes;
		listShapes.push_back(new RectAangle());
		listShapes.push_back(new TriAngle());
		listShapes.push_back(new Circle());
		cout << "#### Inheritance::PowerPointTestMain Draw All List #####" << endl;
		list<Shape*>::iterator it = listShapes.begin();
		for (it = listShapes.begin(); it != listShapes.end(); it++)
		{
			Shape* pShaep = *it;
			pShaep->Draw();
		}
		cout << "#### Inheritance::PowerPointTestMain Casting Draw #####" << endl;
		it = listShapes.begin();
		((RectAangle*)*it)->Draw();
		it++;
		((TriAngle*)*it)->Draw();
		it++;
		((Circle*)*it)->Draw();
		cout << "#### Inheritance::PowerPointTestMain Delete List  #####" << endl;
		for (it = listShapes.begin(); it != listShapes.end(); it++)
		{
			Shape* pShaep = *it;
			delete pShaep;
		}
		listShapes.clear();
		cout << "#### Inheritance::PowerPointTestMain End #####" << endl;
	}
}