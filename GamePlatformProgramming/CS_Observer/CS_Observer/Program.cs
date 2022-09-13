using System;

namespace CS_Observer
{
    class Program
    {
        //다형성: 다양한 객체의 함수를 호출할때 공통적인 인터페이스를 사용하는 용도로 설계된다.
        //vptr: 부모의 객체에 자식의 인스턴스가 할당되어 호출하는 함수가 변경되는 부분.
        //바인딩: 함수의 호출이 결정되는 때
        //동적바인딩: 함수의 호출이 객체에 할당하거나 참조하는 인스턴스가 변경되어 호출되는 함수가 바뀌는 것.
        //정적바인딩: 일반적인 정적할당에서 함수의 호출
        static void Main(string[] args)
        { 
            //C#에 클래스는 객체(cCommder)로만 활용할수없으므로, 사용시 인스턴스(new Commder)를 할당해야한다.
            Commader cCommder = new Commader();
            //C#에서는 배열도 무조건 힙에 할당된다. 그러므로, 참조를 변경할수 있다.
            Marin[] marins = new Marin[10];
            Medic[] medics = new Medic[10];
            //각생성된 배열은 객체만 생성되었으므로, 각각 활용할수 있는 인스턴스를 생성하는 과정이다.
            for(int i = 0; i < 10; i++)
            {
                marins[i] = new Marin();
                medics[i] = new Medic();
            }

            for (int i = 0; i < 10; i++)
                cCommder.AddGroup(marins[i]);

            for (int i = 0; i < 10; i++)
                cCommder.AddGroup(medics[i]);

            cCommder.Command(Commader.E_COMMAND.ATK, marins[0]);
        }
    }
}
