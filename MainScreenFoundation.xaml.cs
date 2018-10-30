using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace GroupGrindr
{
    /// <summary>
    /// Interaction logic for MainScreenFoundation.xaml
    /// </summary>
    /// 
    // tell josh to do his on database huh?
    // LoveLiz
    // SkinnyNerd


    public class Person
    {

        public Person(string firstname, string lastname, string email, string username, int personid)
        {
            FName = firstname;
            LName = lastname;
            Email = email;
            Username = username;
            personID = personid;
        }

        public string FName;
        public string LName;
        public string Email;
        public string Username;
        public int personID;
    }

    public class GlobalVariables
    {
        public static SQLiteConnection connection;
        public static int selectedGroup;
        public static Person currentPerson;
        public static void connectToDatabase()
        {
            GlobalVariables.connection = new SQLiteConnection("Data Source=Database.sqlite;Version=3;");
            GlobalVariables.connection.Open();
        }
        public static DateTime taskTime;

        public static void insertIntoPeople(string FName, string LName, string Password, int Email, string Username)
        {
            string sql = $"INSERT into People (FName,LName,Password,Email,Username) values ('{FName}','{LName}','{GlobalVariables.hashPassword(Password)}',{Email},'{Username}')";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            command.ExecuteNonQuery();
        }
        public static void removeFromPeople(int personID)
        {
            string sql = $"DELETE FROM People WHERE PersonID == {personID}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            command.ExecuteNonQuery();
        }
        public static void removePersonFromGroups(int groupID, int personID)
        {
            string sql = $"DELETE FROM GroupsIn WHERE (PersonID == {personID} AND GroupID == {groupID})";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            command.ExecuteNonQuery();
        }
        public static void insertPersonIntoGroup(int PersonID, int GroupID)
        {
            string sql = $"INSERT INTO GroupsIn (PersonID, GroupID) values ({PersonID},{GroupID})";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            command.ExecuteNonQuery();
        }

        public static int usernametoID(string username)
        {
            string sql = $"SELECT PersonID FROM People WHERE Username == '{username}'";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return int.Parse(reader["PersonID"].ToString());
        }
        public static int emailToID(string email)
        {
            string sql = $"SELECT PersonID FROM People WHERE Email == '{email}'";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return int.Parse(reader["PersonID"].ToString());
        }
        public static string iDToEmail(int personID)
        {
            string sql = $"SELECT Email FROM People WHERE PersonID == {personID}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["Email"].ToString();
        }
        public static string iDToUsername(int personID)
        {
            string sql = $"SELECT Username FROM People WHERE PersonID == {personID}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["Username"].ToString();
        }

        public static int returnPersonIDFromEmail(string email)
        {
            string sql = $"SELECT PersonID FROM People WHERE Email == '{email}'";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return int.Parse(reader["PersonID"].ToString());
        }


        public static List<string> returnPersonInfo(int personID)
        {
            string sql = $"SELECT * FROM People WHERE PersonID == {personID}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return new List<string>()
            {
                reader["FName"].ToString(),
                reader["LName"].ToString(),
                reader["Email"].ToString(),
                reader["Username"].ToString()
            };
        }

        public static void insertIntoGroup(string Name, string Colour, string Description)
        {
            string sql = $"INSERT INTO Groups (Name, Colour, Description) values ('{Name}','{Colour}','{Description}')";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            command.ExecuteNonQuery();
        }
        public static void removeFromGroup(int groupID)
        {
            string sql = $"DELETE FROM Groups WHERE GroupID == {groupID}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            command.ExecuteNonQuery();
        }
        public static int returnAmountOfGroups()
        {
            string sql = "SELECT COALESCE(MAX(GroupID), 0) FROM Groups";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            int returnValue = Convert.ToInt32(reader["COALESCE(MAX(GroupID), 0)"]);
            return returnValue;
        }
        public static List<string> returnListGroups()
        {
            List<string> groups = new List<string>();
            string sql = "SELECT Name from Groups";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                groups.Add(reader["Name"].ToString());
            }
            return groups;
        }

        public static List<string> returnListGroupsIn(int personID)
        {
            List<int> groupIDs = new List<int>();
            List<string> returnGroup = new List<string>();
            string sql = $"SELECT GroupID FROM GroupsIn WHERE PersonID == {personID}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                groupIDs.Add(int.Parse(reader["GroupID"].ToString()));
            }
            foreach (int groupID in groupIDs)
            {
                returnGroup.Add(GlobalVariables.returnGroupInfo(groupID)[0]);
            }
            return returnGroup;
        }

        public static List<string> returnNamesGroup(int groupID)
        {
            string sql = $"SELECT PersonID FROM GroupsIn WHERE GroupID == {groupID}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<int> peopleID = new List<int>();
            while (reader.Read())
            {
                peopleID.Add(int.Parse(reader["PersonID"].ToString()));
            }
            List<string> returnList = new List<string>();
            foreach (int ID in peopleID)
            {
                returnList.Add(GlobalVariables.iDToEmail(ID));
            }
            return returnList;

        }

        public static List<string> returnNamesGroupForMembers(int groupID)
        {
            string sql = $"SELECT PersonID FROM GroupsIn WHERE GroupID == {groupID}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<int> peopleID = new List<int>();
            while (reader.Read())
            {
                peopleID.Add(int.Parse(reader["PersonID"].ToString()));
            }
            List<string> returnList = new List<string>();
            foreach (int ID in peopleID)
            {
                returnList.Add($"{GlobalVariables.iDToEmail(ID)}  ({GlobalVariables.iDToUsername(ID)})");
            }
            return returnList;

        }


        public static string hashPassword(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashed = md5.ComputeHash(inputBytes);

            // convert byte array to a hex string

            StringBuilder stringB = new StringBuilder();
            for (int i = 0; i < hashed.Length; i++)
            {
                stringB.Append(hashed[i].ToString("X2"));
            }
            return stringB.ToString();
        }

        public static bool uniqueEmail(int email)
        {
            string sql = $"SELECT PersonID FROM People WHERE Email == {email}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["PersonID"].ToString() == "";
        }

        public static bool uniqueUsername(string username)
        {
            string sql = $"SELECT PersonID FROM People WHERE Username == '{username}'";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["PersonID"].ToString() == "";
        }

        // returns a true/false bool value (if it is correct)
        // allows for user to input email or username
        public static bool isCorrectPasswordEmail(string inputPassword, int email)
        {
            string sql = $"SELECT Password FROM People WHERE Email == '{email}'";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            string databasePassword = (reader["Password"]).ToString();
            return databasePassword == hashPassword(inputPassword);

        }
        public static bool isCorrectPasswordUsername(string inputPassword, string username)
        {
            string sql = $"SELECT Password FROM People WHERE Username == '{username}'";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            string databasePassword = (reader["Password"]).ToString();
            return databasePassword == hashPassword(inputPassword);
        }

        // Not done
        public static bool isUsernameInPeople(string username)
        {
            string sql = $"SELECT PersonID FROM People WHERE Username == '{username}'";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["PersonID"].ToString() != "";
        }

        public static bool isEmailInPeople(string email)
        {
            string sql = $"SELECT PersonID FROM People WHERE Email == '{email}'";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["PersonID"].ToString() != "";
        }

        // returns a true or false value if it is in database - must not be null
        public static bool isGroupInDatabase(int id)
        {
            string sql = $"SELECT Name FROM Groups WHERE (GroupID == {id})";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["Name"].ToString() != "";
        }

        public static int returnGroupIDfromName(string name)
        {
            string sql = $"SELECT GroupID FROM Groups WHERE (Name == '{name}')";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return int.Parse(reader["GroupID"].ToString());
        }

        // returns name, colour description
        public static List<string> returnGroupInfo(int id)
        {
            string sql = $"SELECT Name,Colour,Description FROM Groups WHERE (GroupID == {id})";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            List<string> returnList = new List<string>
            {
                reader["Name"].ToString(),
                reader["Colour"].ToString(),
                reader["Description"].ToString()
            };
            return returnList;
        }

        // date stored as a string
        public static void insertIntoTasks(string name, string description, string date)
        {
            string sql = $"INSERT INTO Tasks (Name,Description,ActualDate) VALUES ('{name}','{description}','{date}')";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            command.ExecuteNonQuery();
        }

        public static void assignTaskToGroup(int taskID, int groupID)
        {
            string sql = $"INSERT INTO TasksIn (GroupID,TaskID) VALUES ({groupID},{taskID})";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            command.ExecuteNonQuery();
        }

        public static List<string> returnTaskGroups()
        {
            List<string> tasks = new List<string>();
            string sql = "SELECT Name from Tasks";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tasks.Add((string)reader["Name"]);
            }
            return tasks;
        }

        public static int returnTaskAmount()
        {
            List<string> groups = GlobalVariables.returnTaskGroups();
            return groups.Count();
        }

        public static int returnTaskID(string name, string description, string date)
        {
            string sql = $"SELECT TaskID FROM Tasks WHERE (Name == '{name}' AND Description == '{description}' AND ActualDate == '{date}')";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return int.Parse(reader["TaskID"].ToString());
        }

        public static bool userInGroup(int personID, int groupID)
        {
            string sql = $"SELECT PersonID FROM GroupsIn WHERE GroupID == {groupID}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<string> peopleList = new List<string>();
            while (reader.Read())
            {
                peopleList.Add(reader["PersonID"].ToString());
            }
            if (peopleList.Contains(personID.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool userInDatabase(int userID)
        {
            string sql = $"SELECT PersonID FROM People WHERE Email == '{userID}'";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();

            reader.Read();
            if (reader["PersonID"].ToString() == "")
            {
                return false;
            } else
            {
                return true;
            }
        }

        public static void testStuff()
        {
            //MessageBox.Show((GlobalVariables.returnAmountOfGroups() == GlobalVariables.returnListGroups().Count).ToString());
        }
        // .ToShortDateString()). have to use datetime
        public static List<string> returnTask(int taskID)
        {
            // assume taskID is in tasks
            string sql = $"SELECT ActualDate,Name,Description FROM Tasks WHERE (TaskID == {taskID})";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return new List<string>{
                reader["ActualDate"].ToString(),
                reader["Name"].ToString(),
                reader["Description"].ToString()
            };
        }

        public static List<List<string>> returnTasks(int groupID)
        {
            // assume groupID in groups
            // step 1 - get a id of tasks that belong to the group
            // step 2 - use the function getTask to get the tasks and append them
            string sql = $"SELECT TaskID FROM TasksIn WHERE (GroupID == {groupID})";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<int> taskIDs = new List<int>();
            while (reader.Read())
            {
                taskIDs.Add(int.Parse(reader["TaskID"].ToString()));
            }
            // step 1 done - 
            List<List<string>> listOfTasks = new List<List<string>>();
            foreach (int taskID in taskIDs)
            {
                listOfTasks.Add(returnTask(taskID));
            }
            return listOfTasks;
        }

        public static string returnName(string email)
        {
            string sql = $"SELECT Username FROM People WHERE Email == '{email}'";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["Username"].ToString();
        }

        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static void leaveGroup()
        {
            string sql = $"DELETE FROM GroupsIn WHERE GroupID == {GlobalVariables.selectedGroup} AND PersonID == {GlobalVariables.currentPerson.personID}";
            SQLiteCommand command = new SQLiteCommand(sql, GlobalVariables.connection);
            command.ExecuteNonQuery();
        }


    }

    public partial class MainScreenFoundation : Page
    {

        public MainScreenFoundation()
        {
            InitializeComponent();
            GlobalVariables.connectToDatabase();
        }

        private void MyGroups_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
