using ListingClass;
namespace ListingUtility
{
    public class LUtility
    {
       public Listing[] listingList;

        public LUtility(){
            listingList= new Listing[100];
        }
        public Listing[] GetTrainers(){
            return listingList;
        }


        public void Menu(){
        GetFile();
        System.Console.WriteLine("------------------------------------------------------------");
        System.Console.WriteLine("If you would like to add listings please enter 1");
        System.Console.WriteLine("If you would like to edit listings please enter 2");
        System.Console.WriteLine("If you would like to delete listings please enter 3");
        System.Console.WriteLine("If you would like to go back to the main menu please enter 4");
        string userChoice = Console.ReadLine();
            if(IsValidChoice(userChoice)){
                if(userChoice == "1"){
                    AddListing();
                }
                else if(userChoice == "2"){
                    EditListing();
                }
                else if(userChoice == "3"){
                    DeleteListing();
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
        public Listing[] GetFile(){
            StreamReader inFile = new StreamReader("listing.txt");
            string a = inFile.ReadLine();
            Listing.SetCount(0);
            while (a != null){
                if(!string.IsNullOrWhiteSpace(a)){
                    Array.Resize(ref listingList, Listing.GetCount()+1);
                    string[]  b = a.Split('#');
                    listingList[Listing.GetCount()] = new Listing(b[0], b[1], b[2], b[3], b[4],b[5]);
                    Listing.CountUp();
                }
                a = inFile.ReadLine();
            }
            inFile.Close();
            return listingList;   
        }

        public void PrintFile(){
            StreamWriter outfile = new StreamWriter("listing.txt");
            for(int i = 0; i <= Listing.GetCount(); i++){
                string fileID = listingList[i].GetListingID();
                string fileName = listingList[i].GetTrainerName();
                string fileDate = listingList[i].GetDateOfSession();
                string fileTime = listingList[i].GetTimeOfSession();
                string fileCost = listingList[i].GetCostOfSession();
                string fileTaken = listingList[i].GetTaken();
                outfile.WriteLine($"{fileID}#{fileName}#{fileDate}#{fileTime}#{fileCost}#{fileTaken}\n");
                
            }
        outfile.Close();
        }

        public void AddListing(){
            int counter = Listing.GetCount();
            string a = "a";
            listingList[counter] = new Listing("","","","","","");
            while(a!="!"){
            System.Console.WriteLine("------------------------------------------------------------");
            System.Console.Write("Please enter all your Listing information below for the number ");
            System.Console.Write(counter);
            System.Console.WriteLine(" Listing.");
            System.Console.Write("Please enter ! when you are finished");
            System.Console.Write("\n");
                counter = Listing.GetCount();
               System.Console.WriteLine("Please enter the Listing ID");
               a = Console.ReadLine();
               if(a == "!"){
                break;
                }
                listingList[counter].SetListingID(a);
                System.Console.WriteLine("Please enter the Trainers Name");
                a = Console.ReadLine();
                if(a == "!"){
                    break;
                }
                listingList[counter].SetTrainerName(a);
                System.Console.WriteLine("Please enter the Date of the Session");
                a = Console.ReadLine();
                if(a == "!"){
                break;
                }
                listingList[counter].SetDateofSession(a);
                System.Console.WriteLine("Please enter the Time of the Session");
                a = Console.ReadLine();
                if(a == "!"){
                break;
                }
                listingList[counter].SetTimeofSession(a);
                if(a == "!"){
                break;
                }
                System.Console.WriteLine("Please enter the Cost of Session");
                a = Console.ReadLine();
                if(a == "!"){
                    break;
                }
                listingList[counter].SetCostOfSession(a);
                System.Console.WriteLine("Please enter True if the File is Taken or False if it is free");
                a = Console.ReadLine();
                if(a == "!"){
                    break;
                }
                while(!CheckTaken(a)){
                    System.Console.WriteLine("Im sorry that is not True or False");
                    System.Console.WriteLine("Please enter True if the File is Taken or False if it is free");
                    System.Console.WriteLine("If you would like to keep the status as what it is please press enter");
                    a = Console.ReadLine();
                    if(CheckTaken(a)){
                        listingList[counter].SetTaken(a);
                        break;
                    }
                }
                listingList[counter].SetTaken(a);
                counter++;
                Listing.CountUp();
            }
            PrintFile();
            Menu();
        }

        public void EditListing(){
            System.Console.WriteLine("------------------------------------------------------------");
            System.Console.WriteLine("Please enter the ListingID of the Listing you would like to edit");
            Listing tempList = null;
            string temp = "";
            string id = Console.ReadLine();
            int a = findListing(id,ref listingList);
            if(a == -1){
                System.Console.WriteLine("Sorry that ListingID does not exist");
            }
            else{
                tempList = listingList[a];
                System.Console.WriteLine("You are now editing if you would like to leave something the same please leave it blank");
                System.Console.WriteLine("Please enter the Listing ID");
               temp = Console.ReadLine();
               if(!string.IsNullOrEmpty(temp)){
                    listingList[a].SetListingID(temp);
                }
                System.Console.WriteLine("Please enter the Trainers Name");
                temp = Console.ReadLine();
                if(!string.IsNullOrEmpty(temp)){
                    listingList[a].SetTrainerName(temp);
                }
                System.Console.WriteLine("Please enter the Date of the Session");
                temp = Console.ReadLine();
                if(!string.IsNullOrEmpty(temp)){
                    listingList[a].SetDateofSession(temp);
                }
                System.Console.WriteLine("Please enter the Time of the Session");
                temp = Console.ReadLine();
                if(!string.IsNullOrEmpty(temp)){
                    listingList[a].SetTimeofSession(temp);
                }
                System.Console.WriteLine("Please enter the Cost of Session");
                temp = Console.ReadLine();
                if(!string.IsNullOrEmpty(temp)){
                    listingList[a].SetCostOfSession(temp);
                }
                
                System.Console.WriteLine("Please enter True if the File is Taken or False if it is free");
                temp = Console.ReadLine();
                while(!string.IsNullOrEmpty(temp)){
                    if(CheckTaken(temp)){
                        listingList[a].SetTaken(temp);
                    }
                    else{
                        System.Console.WriteLine("Im sorry that is not True or False");
                        System.Console.WriteLine("Please enter True if the File is Taken or False if it is free");
                        System.Console.WriteLine("If you would like to keep the status as what it is please press enter");
                        temp = Console.ReadLine();
                    }
                    
                }
                
                PrintFile();
                System.Console.WriteLine("Editing is Complete!");
            }

        }
        public void DeleteListing(){
            System.Console.WriteLine("------------------------------------------------------------");
            System.Console.WriteLine("Please enter the Listing ID of the Listing you would like to delete");
            Listing tempList = null;
            string temp = "";
            string name = Console.ReadLine();
            int a = findListing(name,ref listingList);
            if(a == -1){
                System.Console.WriteLine("Sorry the ID of that Listing does not exist");
            }
            else{
                tempList = listingList[a];
                    listingList[a].SetListingID("");
                    listingList[a].SetTrainerName("");
                    listingList[a].SetDateofSession("");
                    listingList[a].SetTimeofSession("");
                    listingList[a].SetCostOfSession("");
                    listingList[a].SetTaken("");
                }
                PrintFile();
                System.Console.WriteLine("Trainer has been Deleted!");
            }
        
        public int findListing(string id,ref Listing[]listingList){
            for(int i = 0; i <= Listing.GetCount();i++){
                if(listingList[i].GetTrainerName() == id){
                    return i;
                }
            }
            return -1;
        }

        static bool CheckTaken(String userInput){
            if(userInput.ToLower() == "true"|| userInput.ToLower() == "false"){
            return true;
            }
            return false;
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