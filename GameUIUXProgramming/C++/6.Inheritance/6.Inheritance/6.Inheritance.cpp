//추상화
//좌표(벡터):도형의 좌표를 2차원에서 나타내기위한 객체
//도형: 동작:그리기 //인터페이스
//삼각형: 속성:좌표x3 동작:그리기
//사각형: 속성:좌표x4 동작:그리기
//원: 속성:좌표,반지름 동작:그리기
#include <iostream>
using namespace std;
//상속: 자식의 공통적인 부분을 클래스로 구현하여, 상속하면 일일히 여러번 코드를 작성하지않아도된다. 
//부모부분이 생성되고, 자식부분의 메모리가 추가되어 생성된다.
namespace Inheritance
{
	class Vihicle
	{
	protected: //자식은 접근가능하고 외부에서 접근불가.
		int m_nGear = 0;
		int m_nSpeed = 0;
		int m_nSeats = 1;
	public:
		Vihicle(int seat = 1)
		{
			cout << "Vihicle[" << this << "]:" << sizeof(*this) << endl;
			m_nSeats = seat;
		}
		~Vihicle() { cout << "~Vihicle[" << this << "]" << endl; }

		void Accel() { m_nSpeed++; }
		void Break() { m_nSpeed--; }
		void SetGear(int gear) { m_nGear = gear; }
		void SetSeats(int seat) { m_nSeats = seat; }
	};

	class Bike : public Vihicle
	{
	public:
		Bike() { cout << "Bike[" << this << "]:" << sizeof(*this) << endl; }
		~Bike() { cout << "~Bike[" << this << "]" << endl; }
	};

	class AutoBike : public Vihicle
	{
		int m_nEngine;
	public:
		AutoBike(int engine = 300)
		{
			cout << "AutoBike[" << this << "]:" << sizeof(*this) << endl;
			m_nEngine = engine;
		}
		~AutoBike() { cout << "~AutoBike[" << this << "]" << endl; }
	};

	class Track : public Vihicle
	{
		int m_nEngine;
		int m_nMaxWight;
	public:
		Track(int engine = 3000, int wight = 1000)
		{
			cout << "Track[" << this << "]:" << sizeof(*this) << endl;
			m_nEngine = engine;
			m_nMaxWight = wight;
		}
		~Track() { cout << "~Track[" << this << "]" << endl; }
	};

	class Bus : public Vihicle
	{
		int m_nEngine;
	public:
		Bus(int engine = 7000, int seat = 30) :Vihicle(seat)//부모생성자의 호출: 생성자를 통해 호출하면 부모멤버의 접근제어자와 상관없이 사용가능.
		{
			cout << "Bus[" << this << "]:" << sizeof(*this) << endl;
			m_nEngine = engine;
			///m_nSeats = seat; //부모멤버가 private가 아니여야 접근가능.
		}
		~Bus() { cout << "~Bus[" << this << "]" << endl; }
	};

	void CarMain()
	{
		Vihicle cVihvle;
		Bike cBike;
		AutoBike cAutoBike;
		Track cTrack;
		Bus cBus;
	}
}
//계층상속: 부모를 가진클래스를 상속받는것.
namespace HierarchyInheritance
{
	class Vihicle
	{
	protected: //자식은 접근가능하고 외부에서 접근불가.
		int m_nGear = 0;
		int m_nSpeed = 0;
		int m_nSeats = 1;
	public:
		Vihicle(int seat = 1)
		{
			cout << "Vihicle[" << this << "]:" << sizeof(*this) << endl;
			m_nSeats = seat;
		}
		~Vihicle() { cout << "~Vihicle[" << this << "]" << endl; }

		void Accel() { m_nSpeed++; }
		void Break() { m_nSpeed--; }
		void SetGear(int gear) { m_nGear = gear; }
		void SetSeats(int seat) { m_nSeats = seat; }
	};

	class Eneginer : Vihicle
	{
	protected:
		int m_nEngine;
	public:
		Eneginer(int engine = 300)
		{
			cout << "Eneginer[" << this << "]:" << sizeof(*this) << endl;
			m_nEngine = engine;
		}
		~Eneginer()
		{
			cout << "~Eneginer[" << this << "]" << endl;
		}
	};

	class AutoBike : public Eneginer
	{
	public:
		AutoBike(int engine = 300) : Eneginer(engine)
		{
			cout << "AutoBike[" << this << "]:" << sizeof(*this) << endl;
		}
		~AutoBike() { cout << "~AutoBike[" << this << "]" << endl; }
	};

	class Track : public Eneginer
	{
		int m_nMaxWight;
	public:
		Track(int engine = 3000, int wight = 1000)
		{
			cout << "Track[" << this << "]:" << sizeof(*this) << endl;
			m_nEngine = engine;
			m_nMaxWight = wight;
		}
		~Track() { cout << "~Track[" << this << "]" << endl; }
	};

	class Bus : public Eneginer
	{
	public:
		Bus(int engine = 7000, int seat = 30) :Eneginer(engine)//부모생성자의 호출: 생성자를 통해 호출하면 부모멤버의 접근제어자와 상관없이 사용가능.
		{
			//Vihicle(seat); //다음과같이 처리하면 임시객체만들기때문에 초기화가 아니다.
			//m_nSeats = seat; //기능적으로 같지만 초기화가 부모에서 이미 이루어졌다,
			cout << "Bus[" << this << "]:" << sizeof(*this) << endl;
			m_nEngine = engine;
			///m_nSeats = seat; //부모멤버가 private가 아니여야 접근가능.
		}
		~Bus() { cout << "~Bus[" << this << "]" << endl; }
	};

	void CarMain()
	{
		//Vihicle cVihicle; //탈것이라는것은 대분류의 개념이므로 존재하지않는다.
		//Bike cBike; //멤버가 추가되지않으므로 굳이 클래스로 만들필요가없다.
		//만약 자전거를 만든다면 객체를 다르게 표현하는것이 방법일수있다.
		Vihicle cBike;
		Eneginer cAutoBike;
		//AutoBike cAutoBike;
		Track cTrack;
		Bus cBus;
		cout << "#### Size #####" << endl;
		//cout << "Vihicle:" << sizeof(cVihicle) << endl;
		cout << "Engener:" << sizeof(cAutoBike) << endl;
		cout << "Track:" << sizeof(cTrack) << endl;
		cout << "Bus:" << sizeof(cBus) << endl;
	}
}
//다중상속의 문제
namespace DiamondInhartance
{
	class Vihicle
	{
	protected: //자식은 접근가능하고 외부에서 접근불가.
		int m_nGear = 0;
		int m_nSpeed = 0;
		int m_nSeats = 1;
	public:
		Vihicle(int seat = 1)
		{
			cout << "Vihicle[" << this << "]:" << sizeof(*this) << endl;
			m_nSeats = seat;
		}
		~Vihicle() { cout << "~Vihicle[" << this << "]" << endl; }

		void Accel() { m_nSpeed++; }
		void Break() { m_nSpeed--; }
		void SetGear(int gear) { m_nGear = gear; }
		void SetSeats(int seat) { m_nSeats = seat; }
	};

	class Bike : public Vihicle
	{
	public:
		Bike() { cout << "Bike[" << this << "]:" << sizeof(*this) << endl; }
		~Bike() { cout << "~Bike[" << this << "]" << endl; }
	};

	class Enginer : public Vihicle
	{
	protected:
		int m_nEngine;
	public:
		Enginer(int engine = 300)
		{
			cout << "Enginer[" << this << "]:" << sizeof(*this) << endl;
			m_nEngine = engine;
		}
		~Enginer()
		{
			cout << "~Enginer[" << this << "]" << endl;
		}
	};

	class AutoBike : public Bike, public Enginer
	{
	public:
		AutoBike(int engine = 300) : Enginer(engine)
		{
			cout << "AutoBike[" << this << "]:" << sizeof(*this) << endl;
		}
		~AutoBike() { cout << "~AutoBike[" << this << "]" << endl; }
	};

	class Track : public Enginer
	{
		int m_nMaxWight;
	public:
		Track(int engine = 3000, int wight = 1000)
		{
			cout << "Track[" << this << "]:" << sizeof(*this) << endl;
			m_nEngine = engine;
			m_nMaxWight = wight;
		}
		~Track() { cout << "~Track[" << this << "]" << endl; }
	};

	class Bus : public Enginer
	{
	public:
		Bus(int engine = 7000, int seat = 30) :Enginer(engine)//부모생성자의 호출: 생성자를 통해 호출하면 부모멤버의 접근제어자와 상관없이 사용가능.
		{
			//Vihicle(seat); //다음과같이 처리하면 임시객체만들기때문에 초기화가 아니다.
			//m_nSeats = seat; //기능적으로 같지만 초기화가 부모에서 이미 이루어졌다,
			cout << "Bus[" << this << "]:" << sizeof(*this) << endl;
			m_nEngine = engine;
			///m_nSeats = seat; //부모멤버가 private가 아니여야 접근가능.
		}
		~Bus() { cout << "~Bus[" << this << "]" << endl; }
	};
	//다이아몬드상속: 같은부모를 가진 자식을 다중상속받아서 구현한경우.
	//C#이나 Java에서는 다음과 같은 다중상속을 막기위해서 다중상속이 불가능하다.
	//(단, 인터페이스는 다중상속가능하나 클래스랑은 용어가 다르므로 추후 설명함)
	void CarMain()
	{
		AutoBike cAutoBike;

		cout << "#### Size #####" << endl;
		cout << "Engener:" << sizeof(cAutoBike) << endl;
		//다중상속을 할때는 상속구조를 제대로 파악해야한다.
		//cAutoBike.SetGear(0);
		cAutoBike.Bike::SetGear(0);
		cAutoBike.Enginer::SetGear(0);
	}
}

class Spiker
{
	bool m_bPower;
	float m_fVolume;
public:
	Spiker()
	{
		m_bPower = false;
		m_fVolume = 0;
		cout << typeid(*this).name() << "[" << this << "](" << &m_bPower << "," << &m_fVolume << "):" << sizeof(*this) << endl;
	}
	void SwitchOn()
	{
		m_bPower = true;
		cout << typeid(*this).name() << "::SwitchOn(" << m_bPower << ")" << endl;
	}
	void SwitchOff()
	{
		m_bPower = false;
		cout << typeid(*this).name() << "::SwitchOff(" << m_bPower << ")" << endl;
	}
	void VolumeUp()
	{
		m_fVolume++;
		cout << typeid(*this).name() << "::VolumeUp(" << m_fVolume << ")" << endl;
	}
	void VolumeDown()
	{
		m_fVolume--;
		cout << typeid(*this).name() << "::VolumeDown(" << m_fVolume << ")" << endl;
	}
};

class Antena
{
	float m_fHertz = 0;
public:
	Antena()
	{
		m_fHertz = 0;
		cout << typeid(*this).name() << "[" << this << "]:" << sizeof(*this) << endl;
	}
	void HertzUp()
	{
		m_fHertz++;
		cout << typeid(*this).name() << "::HertzUp(" << m_fHertz << ")" << endl;
	}
	void HertzDown()
	{
		m_fHertz--;
		cout << typeid(*this).name() << "::HertzDown(" << m_fHertz << ")" << endl;
	}
};
//is-a: 상속을 이용하면 코드를 거이 작성하지않고 만들수있다.
namespace IsA
{
	class Radio : public Spiker, public Antena
	{
	public:
		Radio() 
		{ 
			cout << typeid(*this).name() << "[" << this << "]:" << sizeof(*this) << endl;
		}
	};

	void RadioMain()
	{
		Radio cRadio; //라디오를 만들수있다. 그러나 내부부품은 재활용할수없다.

		cRadio.SwitchOn();
		cRadio.VolumeUp();
		cRadio.HertzDown();
		cRadio.SwitchOff();
	}
}
//has-a: 각 객체를 감싸는 함수를 만들어한다.
//만들때 내부의 부품을 더 좋은 부품을 사용할수있다.
//(현실에 라디오라면 직접 인터페이스를 내부에 보드에 연결하므로 여기에 해당될수도 있다.)
namespace HasA
{
	//해당문법은 is-a만큼 범용성이 없으므로 잘사용되지않는다.
	/*class Radio
	{
		Spiker m_cSpiker;
		Antena m_cAntena;
	public:
		Radio()
		{
			cout << typeid(*this).name() << "[" << this << "]:" << sizeof(*this) << endl;
		}
	};*/

	class Radio
	{
		Spiker* m_pSpiker;
		Antena* m_pAntena;
	public:
		void SetSpiker(Spiker* pSpiker)
		{
			m_pSpiker = pSpiker;
		}
		Spiker* SetSpiker()
		{
			return m_pSpiker;
		}
		void SetAntena(Antena* pAntena)
		{
			m_pAntena = pAntena;
		}
		Antena* SetAntenar()
		{
			return m_pAntena;
		}
	public:
		Radio(Spiker* spiker, Antena* antena)
		{
			m_pSpiker = spiker;
			m_pAntena = antena;
			cout << typeid(*this).name() << "[" << this << "]("<< m_pSpiker<<","<<m_pAntena<< "):" << sizeof(*this) << endl;
		}
		void SwitchOn()
		{
			cout << typeid(*this).name() << "::SwitchOn()" << endl;
			m_pSpiker->SwitchOn();
		}
		void SwitchOff()
		{
			cout << typeid(*this).name() << "::SwitchOff()" << endl;
			m_pSpiker->SwitchOff();
		}
		void VolumeUp()
		{
			cout << typeid(*this).name() << "::VolumeUp()" << endl;
			m_pSpiker->VolumeUp();
		}
		void VolumeDown()
		{
			cout << typeid(*this).name() << "::VolumeDown()" << endl;
			m_pSpiker->VolumeDown();
		}
		void HertzUp()
		{
			cout << typeid(*this).name() << "::HertzUp()" << endl;
			m_pAntena->HertzUp();
		}
		void HertzDown()
		{
			cout << typeid(*this).name() << "::HertzDown()" << endl;
			m_pAntena->HertzDown();
		}
	};

	void RadioMain()
	{
		Spiker* pSpiker = new Spiker();
		Antena* pAntena = new Antena();

		//라디오를 조립할때 부품을 선택할수있고, 재활용이 가능하다.
		Radio cRadio(pSpiker, pAntena);
		//Radio cRadio(new Spiker(), new Antena()); //이렇게 사용하는 경우 객체내부에 포함된다.
		cRadio.SetSpiker()->SwitchOn();
		cRadio.SwitchOn();
		cRadio.VolumeUp();
		cRadio.HertzDown();
		cRadio.SwitchOff();

		delete pSpiker;
		delete pAntena;
	}
}
void main()
{
	//ShapeMain();
	//Inheritance::CarMain();
	//HierarchyInheritance::CarMain();
	//DiamondInhartance::CarMain();
	IsA::RadioMain();
	//HasA::RadioMain();
}