using System;

namespace CSBasic
{
    class Program
    {
        //Ctrl+F5: 디버거없이 빌드 및 실행
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!?!?");
            Console.WriteLine("Add:" + Add(30, 20));
            ValMain();//2. 함수의 호출
        }
        //변수: 데이터를 담는 상자
        static int Add(int a, int b)//30, 20
        {
            int c = a + b; //50 = 30 + 20
            return c;//50
        }
        //1. 함수선언
        static void ValMain()
        {
            //3. 함수의 정의
        }
    }
}
