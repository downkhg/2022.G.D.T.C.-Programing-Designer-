#pragma once

#include <iostream>
#include <list>

namespace Virtual
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
	//추상클래스: 순수가상함수를 1개이상 가진 클래스. 객체화가 불가능하다.
	//실체화: 추상클래스를 상속받아서 객체화 가능한 클래스를 만드는것.
	class Shape 
	{
	public:
		Shape()
		{
			cout << "Shape[" << this << "]" << sizeof(*this) << endl;
		}
		//virtual ~Shape() = 0 //순수가상소멸자(?) 문법은 가능하지만, 실제로 원하는 대로 작동하지않는 코드이므로. 순수 가상소멸자라는 개념은 존재하지않는다.
		virtual ~Shape() = 0//가상소멸자
		{
			cout << "~Shape[" << this << "]" << endl;
		}
		//v-ptr에 자식의 객체가 할당이되면 자식함수의 주소값이 할당되어, 자식객체의 함수에 접근가능하다.
		//virtual void Draw()//가상함수: 자식객체에서 부모객체의 함수를 오버라이딩하여 구현하는 것.
		virtual void Draw() = 0 //순수가상함수: 자식객체에서 부모의 가상함수를 반드시 구현하도록 강제함.
		{
			cout << "Shape[" << this << "]::Draw()" << endl;
		};
	};
	//원과 같이 삼각형,사각형을 클래스로 만들기
	//실체화: 추상클래스를 상속받아 클래스를 생성함. 추상클래스는 객체화 할수없으므로 실체화하여 사용해야한다.
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
		void Draw() override //부모의 가상함수를 오버라이딩하여 자식객체에서 생성한것. //키워드는 필수사항이 아님.
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
		//Shape cShape; //추상클래스는 객체화 할 수 없다.
		Circle cCrilce({ 1,1 }, 1);
		//cShape.Draw();
		//cShape.Shape::Draw();
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
	//다형성은 가상함수를 이용하여 부모객체에서 자식객체에 멤버에 접근한다.
	//동적바인딩: 실행될 함수가 프로그램 실행(런타임)중에 결정된다.
	//정적바인딩: 컴파일시에 실행될 함수가 결정된것.
	void PowerPointTestMain()
	{
		cout << "#### Virtual::PowerPointTestMain Start #####" << endl;
		list<Shape*> listShapes;
		listShapes.push_back(new RectAangle());
		listShapes.push_back(new TriAngle());
		listShapes.push_back(new Circle());
		cout << "#### Virtual::PowerPointTestMain Draw All List #####" << endl;
		list<Shape*>::iterator it = listShapes.begin();
		for (it = listShapes.begin(); it != listShapes.end(); it++)
		{
			Shape* pShaep = *it;
			pShaep->Draw(); //v-ptr이 생성되고 객체에 담겨있는 주소(각 함수의 오버로딩함수)가 다르다.
		}
		cout << "#### Virtual::PowerPointTestMain Casting Draw #####" << endl;
		it = listShapes.begin();
		((RectAangle*)*it)->Draw();
		it++;
		((TriAngle*)*it)->Draw();
		it++;
		((Circle*)*it)->Draw();
		cout << "#### Virtual::PowerPointTestMain Delete List  #####" << endl;
		for (it = listShapes.begin(); it != listShapes.end(); it++)
		{
			Shape* pShaep = *it;
			delete pShaep;
		}
		listShapes.clear();
		cout << "#### Inheritance::PowerPointTestMain End #####" << endl;
	}
}