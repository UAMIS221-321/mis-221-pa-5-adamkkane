namespace ListingClass{
    public class Listing
    {
        public string listingID;
        public string trainerName;
        public string dateOfSession;
        public string timeOfSession;
        public string costOfSession;
        public string taken;
        static private int count;
        public Listing(string listingID, string trainerName, string dateOfSession, string timeOfSession, string costOfSession, string taken){
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.dateOfSession = dateOfSession;
            this.timeOfSession = timeOfSession;
            this.costOfSession = costOfSession;
            this.taken = taken;
        }
        public string GetListingID()
        {
            return listingID;
        }

        public string GetTrainerName()
        {
            return trainerName;
        }

        public string GetDateOfSession()
        {
            return dateOfSession;
        }

        public string GetTimeOfSession()
        {
            return timeOfSession;
        }
        public string GetCostOfSession()
        {
            return costOfSession;
        }
        public string GetTaken()
        {
            return taken;
        }

        public void SetListingID(string listingID)
        {
            this.listingID = listingID;

        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public void SetDateofSession(string dateOfSession)
        {
            this.dateOfSession = dateOfSession;
        }
        public void SetTimeofSession(string timeOfSession)
        {
            this.timeOfSession = timeOfSession;
        }
        public void SetCostOfSession(string costOfSession)
        {
            this.costOfSession = costOfSession;
        }
        public void SetTaken(string taken){
            this.taken = taken;
        }

            static public int GetCount(){
            return Listing.count;
        }
        static public void SetCount(int count){
            Listing.count = count;
        }
        static public void CountUp(){
            Listing.count = count++;
        }
        static public void CountDown(){
            Listing.count = count--;
        }
        public override string ToString()
        {
            return$"{listingID}#{trainerName}#{dateOfSession}#{timeOfSession}#{costOfSession}#{taken}";
        }
        public string ToFile(){
            return$"{GetListingID()}#{GetTrainerName()}#{GetDateOfSession()}#{GetTimeOfSession()}#{GetCostOfSession}#{GetTaken()}";
        }
    }
}    