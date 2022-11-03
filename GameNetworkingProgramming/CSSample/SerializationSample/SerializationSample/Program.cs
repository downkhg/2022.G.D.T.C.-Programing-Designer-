using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationSample
{
    [Serializable]
    public class Loan : INotifyPropertyChanged
    {
        public double LoanAmount { get; set; }
        public double InterestRatePercent { get; set; }

        [field: NonSerialized()]
        public DateTime TimeLastLoaded { get; set; }

        public int Term { get; set; }

        private string customer;
        public string Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                PropertyChanged?.Invoke(this,
                  new PropertyChangedEventArgs(nameof(Customer)));
            }
        }

        [field: NonSerialized()]
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public Loan(double loanAmount,
                    double interestRate,
                    int term,
                    string customer)
        {
            this.LoanAmount = loanAmount;
            this.InterestRatePercent = interestRate;
            this.Term = term;
            this.customer = customer;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const string FileName = @"../../../SavedLoan.bin";

            Loan TestLoan = new Loan(10000.0, 7.5, 36, "Neil Black");

            TestLoan.PropertyChanged += (_, __) => Console.WriteLine($"New customer value: {TestLoan.Customer}");

            TestLoan.Customer = "Henry Clay";
            Console.WriteLine(TestLoan.InterestRatePercent);

            Stream SaveFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(SaveFileStream, TestLoan);
            SaveFileStream.Close();

            TestLoan.InterestRatePercent = 7.1;
            Console.WriteLine(TestLoan.InterestRatePercent);

            if (File.Exists(FileName))
            {
                Console.WriteLine("Reading saved file");
                Stream openFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                TestLoan = (Loan)deserializer.Deserialize(openFileStream);
                TestLoan.TimeLastLoaded = DateTime.Now;
                openFileStream.Close();
            }
            else
                Console.WriteLine(FileName + " not found!");

            Console.WriteLine(TestLoan.InterestRatePercent);
        }
    }
}
