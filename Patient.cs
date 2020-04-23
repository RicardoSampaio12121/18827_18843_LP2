namespace LP2_TP1
{
    public class Patient
    {
        #region ATTRIBUTES

        private string name;
        private string birthDate;
        private string cc;
        private string adress;
        private int priority = 0;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }

        public string CC
        {
            get => cc;
            set => cc = value;
        }

        public string Adress
        {
            get => adress;
            set => adress = value;
        }

        public int Priority
        {
            get => priority;
            set => priority = value;
        }



        #endregion

        #region METHODS

       

        #region CONSTRUCTOR

        public Patient()
        {
            this.name = "";
            this.birthDate = "";
            this.cc = "";
            this.adress = "";
        }

        public Patient(string name, string birthDate, string cc, string morada)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.cc = cc;
            this.adress = morada;
        }


        #endregion

        #endregion

        #region Operators

        public override bool Equals(object obj)
        {
            Patient aux = (Patient)obj;
            return (string.Compare(this.cc, aux.cc) == 0);
        }

        public override int GetHashCode() { return 0; }

        public static bool operator ==(Patient p1, Patient p2)
        {
            return (p1.Equals(p2));
        }

        public static bool operator !=(Patient p1, Patient p2)
        {
            return (!(p1.Equals(p2)));
        }

        #endregion

    }
}