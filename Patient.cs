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
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public string Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public string BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public string CC
        {
            get => cc;
            set => cc = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public string Adress
        {
            get => adress;
            set => adress = value;
        }
        /// <summary>
        /// Gives and receaves the value of the variable
        /// </summary>
        /// <value></value>
        public int Priority
        {
            get => priority;
            set => priority = value;
        }



        #endregion

        #region METHODS

       

        #region CONSTRUCTOR
        /// <summary>
        /// Creates an object of the class
        /// </summary>
        public Patient()
        {
            this.name = "";
            this.birthDate = "";
            this.cc = "";
            this.adress = "";
        }
        /// <summary>
        /// Create a new Patient
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="cc"></param>
        /// <param name="morada"></param>
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
        /// <summary>
        /// Creates an equals of the object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Patient aux = (Patient)obj;
            return (string.Compare(this.cc, aux.cc) == 0);
        }

        public override int GetHashCode() { return 0; }
        /// <summary>
        /// Creates an == of the object
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Patient p1, Patient p2)
        {
            return (p1.Equals(p2));
        }
        /// <summary>
        /// Creates an != of the object
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Patient p1, Patient p2)
        {
            return (!(p1.Equals(p2)));
        }

        #endregion

    }
}