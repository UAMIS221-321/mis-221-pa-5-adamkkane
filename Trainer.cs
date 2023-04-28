namespace TrainerClass{
    public class Trainer
    {
        private string trainerID;
        private string trainerName;
        private string mailingAddress;
        private string trainerEmailAddress;
        static private int count;

        public Trainer(string trainerID, string trainerName, string mailingAddress, string trainerEmailAddress){
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.mailingAddress = mailingAddress;
            this.trainerEmailAddress = trainerEmailAddress;
        }

        public string GetTrainerID()
        {
        return trainerID;
        }

        public string GetTrainerName()
        {
        return trainerName;
        }

        public string GetMailingAddress()
        {
        return mailingAddress;
        }

        public string GetTrainerEmailAddress()
        {
        return trainerEmailAddress;
        }
        public void SetTrainerID(string trainerId)
        {
        this.trainerID = trainerId;
        }
        public void SetTrainerName(string trainerName)
        {
        this.trainerName = trainerName;
        }
        public void SetMailingAddress(string mailingAddress)
        {
        this.mailingAddress = mailingAddress;
        }
        public void SetTrainerEmailAddress(string trainerEmailAddress)
        {
        this.trainerEmailAddress = trainerEmailAddress;
        }
        static public int GetCount(){
            return Trainer.count;
        }
        static public void SetCount(int count){
            Trainer.count = count;
        }
        static public void CountUp(){
            Trainer.count = count++;
        }
        static public void CountDown(){
            Trainer.count = count--;
        }
        public override string ToString()
        {
            return$"{trainerID}#{trainerName}#{mailingAddress}#{trainerEmailAddress}#";
        }
        public string ToFile(){
            return$"{GetTrainerID()}#{GetTrainerName()}#{GetMailingAddress}#{GetTrainerEmailAddress()}";
        }

    }
}