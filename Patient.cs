namespace LP2_TP1
{
    public class Patient
    {
        #region ATTRIBUTES

        private string name;
        private int age;
        private string cc;
        private int priority;

        #endregion
    
        #region PROPERTIES

        public string Name
        {
            get => name;
            set => name = value;
        }
    
        public int Age
        {
            get => age;
            set => age = value;
        }

        public string CC
        {
            get => cc;
            set => cc = value;
        }

        public int Priority{
            get => priority;
            set => priority = value;
        }
 
        #endregion
        
        #region METHODS

        //private bool VerifyCC(string cc)
        //{
            
        //}
        
        #region CONSTRUCTOR

        
        public Patient(){
            this.name = "";
            this.age = 0;
            this.cc = "";
            this.priority = 0;
        }

        public Patient(string name, int age, string cc, int priority)
        {
            this.name = name;
            this.age = age;
            this.cc = cc;
            this.priority = priority;
        }
        #endregion

        #endregion

        #region Operators

        public override bool Equals(object obj)
        {
            Patient aux = (Patient) obj;
            return (string.Compare(this.cc, aux.cc) == 0);
        }

        public static bool operator ==(Patient p1, Patient p2)
        {
            return (p1.Equals(p2));
        }
        
        public static bool operator != (Patient p1, Patient p2)
        {
            return (!(p1.Equals(p2)));
        }
        
        #endregion

    }
}