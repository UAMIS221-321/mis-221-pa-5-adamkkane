namespace BookingClass{
    public class Booking
    {
        public string sessionID;
        public string customerName;
        public string customerEmail;
        public string trainingDate;
        public string trainerID;
        public string trainerName;
        public string status;
        static private int count;
        public Booking(string sessionID, string customerName, string customerEmail, string trainingDate, string trainerID, string trainerName, string status){
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
        }
        public string GetSessionID()
        {
            return sessionID;
        }

        public string GetCustomerName()
        {
            return customerName;
        }

        public string GetCustomerEmail()
        {
            return customerEmail;
        } 

        public string GetTrainingDate()
        {
            return trainingDate;
        }
        public string GetTrainerID()
        {
            return trainerID;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public string GetStatus()
        {
            return status;
        }

        public void SetSessionID(string sessionID)
        {
            this.sessionID = sessionID;

        }
        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public void SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }
        public void SetTrainingDate(string trainingDate)
        {
            this.trainingDate = trainingDate;
        }
        public void SetTrainerId(string trainerID)
        {
            this.trainerID = trainerID;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public void SetStatus(string status){
            this.status = status;
        }

            static public int GetCount(){
            return Booking.count;
        }
        static public void SetCount(int count){
            Booking.count = count;
        }
        static public void CountUp(){
            Booking.count = count++;
        }
        static public void CountDown(){
            Booking.count = count--;
        }
        public override string ToString()
        {
            return$"{sessionID}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{trainerName}#{status}";
        }
        public string ToFile(){
            return$"{GetSessionID()}#{GetCustomerName()}#{GetCustomerEmail()}#{GetTrainingDate()}#{GetTrainerID}#{GetTrainerName()}#{GetStatus()}";
        }
    }
}    