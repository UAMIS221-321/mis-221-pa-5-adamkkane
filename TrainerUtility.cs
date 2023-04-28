using TrainerClass;

namespace TrainerUtility
{
    public class TUtility{

        public Trainer[] trainerList;

        public TUtility(){
            trainerList= new Trainer[99];
        }
        public Trainer[] GetTrainers(){
            return trainerList;
        }


        public void Menu(){
        GetFile();
        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("If you would like to add trainers please enter 1");
        System.Console.WriteLine("If you would like to edit trainers please enter 2");
        System.Console.WriteLine("If you would like to delete trainers please enter 3");
        System.Console.WriteLine("If you would like to go back to the main menu please enter 4");
        string userChoice = Console.ReadLine();
            if(IsValidChoice(userChoice)){
                if(userChoice == "1"){
                    AddTrainer();
                }
                else if(userChoice == "2"){
                    EditTrainer();
                }
                else if(userChoice == "3"){
                    DeleteTrainer();
                }
                else if(userChoice == "4"){
                    System.Console.Write("\n");
                    return;
                    
                }
            }
            else{
            SayInvalid();
            } 
        
        }
        public void GetFile(){
            StreamReader inFile = new StreamReader("trainer.txt");
            string a = inFile.ReadLine();
            Trainer.SetCount(0);
            while (a != null){
                if(!string.IsNullOrWhiteSpace(a)){
                    Array.Resize(ref trainerList, Trainer.GetCount()+1);
                    string[]  b = a.Split('#');
                    trainerList[Trainer.GetCount()] = new Trainer(b[0], b[1], b[2], b[3]);
                    Trainer.CountUp();
                }
                a = inFile.ReadLine();
            }
            inFile.Close();
      
        }

        public void PrintFile(){
            System.IO.StreamWriter file = new System.IO.StreamWriter("trainer.txt",true);
            for(int i = 0; i <= Trainer.GetCount(); i++){
                string fileID = trainerList[i].GetTrainerID();
                string fileName = trainerList[i].GetTrainerName();
                string fileAddress = trainerList[i].GetMailingAddress();
                string fileEmail = trainerList[i].GetTrainerEmailAddress();
                file.WriteLine($"{fileID}#{fileName}#{fileAddress}#{fileEmail}\n");
                
            }
        file.Close();
        }

        public void AddTrainer(){
            int counter = Trainer.GetCount();
            string a = "a";
            while(a!="!"){
            trainerList[counter] = new Trainer("","","","");
            System.Console.WriteLine("------------------------------------------------------------");
            System.Console.Write("Please enter all your trainer information below for the number ");
            System.Console.Write(counter);
            System.Console.WriteLine(" trainer.");
            System.Console.Write("Please enter ! when you are finished");
            System.Console.Write("\n");
               System.Console.WriteLine("Please enter the Trainers ID");
               a = Console.ReadLine();
               if(a == "!"){
                break;
                }
                trainerList[counter].SetTrainerID(a);
                System.Console.WriteLine("Please enter the Trainers Name");
                a = Console.ReadLine();
                if(a == "!"){
                    break;
                }
                trainerList[counter].SetTrainerName(a);
                System.Console.WriteLine("Please enter the Mailing Address");
                a = Console.ReadLine();
                if(a == "!"){
                break;
                }
                trainerList[counter].SetMailingAddress(a);
                System.Console.WriteLine("Please enter the Trainers Email Address");
                a = Console.ReadLine();
                if(a == "!"){
                break;
                }
                trainerList[counter].SetTrainerEmailAddress(a);
                if(a == "!"){
                break;
                }
                counter++;
            }
            PrintFile();
            Menu();
        }

        public void EditTrainer(){
            System.Console.WriteLine("------------------------------------------------------------");
            System.Console.WriteLine("Please enter the Name of the Trainer you would like to edit");
            Trainer tempList = null;
            string temp = "";
            string name = Console.ReadLine();
            int a = findTrainer(name,ref trainerList);
            if(a == -1){
                System.Console.WriteLine("Sorry the Name of that Trainer does not exist");
            }
            else{
                tempList = trainerList[a];
                System.Console.WriteLine("You are now editing if you would like to leave something the same please leave it blank");
                System.Console.WriteLine("Please enter the Trainers ID");
               temp = Console.ReadLine();
               if(!string.IsNullOrEmpty(temp)){
                    trainerList[a].SetTrainerID(temp);
                }
                System.Console.WriteLine("Please enter the Trainers Name");
                temp = Console.ReadLine();
                if(!string.IsNullOrEmpty(temp)){
                    trainerList[a].SetTrainerName(temp);
                }
                System.Console.WriteLine("Please enter the Mailing Address");
                temp = Console.ReadLine();
                if(!string.IsNullOrEmpty(temp)){
                    trainerList[a].SetMailingAddress(temp);
                }
                System.Console.WriteLine("Please enter the Trainers Email Address");
                temp = Console.ReadLine();
                if(!string.IsNullOrEmpty(temp)){
                    trainerList[a].SetTrainerEmailAddress(temp);
                }
                PrintFile();
                System.Console.WriteLine("Editing is Complete!");
            }

        }
        public void DeleteTrainer(){
            System.Console.WriteLine("------------------------------------------------------------");
            System.Console.WriteLine("Please enter the Name of the Trainer you would like to delete");
            Trainer tempList = null;
            string temp = "";
            string name = Console.ReadLine();
            int a = findTrainer(name,ref trainerList);
            if(a == -1){
                System.Console.WriteLine("Sorry the Name of that Trainer does not exist");
            }
            else{
                tempList = trainerList[a];
                    trainerList[a].SetTrainerID("");
                    trainerList[a].SetTrainerName("");
                    trainerList[a].SetMailingAddress("");
                    trainerList[a].SetTrainerEmailAddress("");
                }
                PrintFile();
                System.Console.WriteLine("Trainer has been Deleted!");
            }
        
        public int findTrainer(string name,ref Trainer[]trainerList){
            for(int i = 0; i <= Trainer.GetCount();i++){
                if(trainerList[i].GetTrainerName() == name){
                    return i;
                }
            }
            return -1;
        }

        //A method to inform the user that they have given an invalid input
        static void SayInvalid(){
                System.Console.WriteLine("\n");
                System.Console.WriteLine("Sorry your choice is invalid");
                PauseAction();
        }

        //A method used to pause the users interface after they have given an invalid choice
        static void PauseAction(){
            System.Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        //check to see if the User chose a valid menu option
        static bool IsValidChoice(String userInput){
        if(userInput == "1"|| userInput == "2"||userInput == "3"||userInput == "4"){
         return true;
        }
        return false;

}
    }
}

