using Lesson_50_HT.Controller;
using Lesson_50_HT.Model;
using Lesson_50_HT.Services.Messages;
using Lesson_50_HT.Services.Patterns;
using Lesson_50_HT.Services.RandomGenerator;
using Lesson_50_HT.Services.FileServices;
using System.IO;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

string main_path = Assembly.GetExecutingAssembly().Location;

for (int i = 0; i < 4; i++)
{
    main_path = Path.GetDirectoryName(main_path);
}

Directory.CreateDirectory(main_path + "/data");

Directory.CreateDirectory(main_path + "/Students's results");

string students_result_path = main_path + "/Students's results/";
main_path += "/data/";



string student_path = "students.txt";
string category_path = "categories.txt";
string results_path = "results.txt";

_create_default_neccessary_files();


AdminController adminController = new AdminController();
StudentController studentController = new StudentController(
    FileServices<Student>.GetData(main_path + student_path),
    FileServices<Result>.GetData(main_path + results_path));

CategoryController categoryController = new CategoryController(
    FileServices<Category>.GetData(main_path + category_path));


_create_default_Admins();

LaunchProgram();
void LaunchProgram()
{
    bool isContinue = true;

    while (isContinue)
    {
        Console.Clear();
        Console.WriteLine("Welcome to Exam center! Please sign in your account");
        Console.WriteLine(
            "1. Sign In\n" +
            "2. Quit");

        Console.Write("Choose option: ");
        switch (Console.ReadLine())
        {
            case "1":
                SignInFunc();
                break;
            case "2":
                Quit();
                isContinue = false;
                break;
            default:
                Errors.NonexistentOptionError();
                break;
        }
    }
}

void SignInFunc()
{
    Console.Clear();
    Console.WriteLine("Enter your Login: ");
    string? inputLogin = Console.ReadLine();

    Console.Write("Enter your Password: ");
    string? inputPassword = Console.ReadLine();

    // Check if email and password is coorect
    Admin? able_admin = adminController.GetAdminByLogin(inputLogin);
    if (able_admin is not null)
    {
        if (able_admin.Password == inputPassword)
        {
            LoggingInAsAdmin(able_admin);
            return;
        }
    }

    Student? able_student = studentController.GetStudentByLogin(inputLogin);
    if (able_student is not null)
    {
        if (able_student.Password == inputPassword)
        {
            LogginInAsStudent(able_student);
            return;
        }
    }
    Errors.LogginInMistake();
};

void LoggingInAsAdmin(Admin currentAdmin) 
{

    bool isContinue = true;
    while (isContinue)
    {
        Console.Clear();
        Console.WriteLine(
            "Your account info: \n" +
            "======================"
            );

        currentAdmin.ShowInfo();

        // Action part
        Console.WriteLine("What do you want to do?\n" +
                "1. Show all students\n" +
                "2. Show students' results\n" +
                "3. Add student\n" +
                "4. Delete student\n" +
                "5. Show all categories\n" +
                "6. Add category\n" +
                "7. Delete category\n" +
                "8. Show all question\n" +
                "9. Add question\n" +
                "10. Delete question\n" +
                "11. Quit");

        Console.Write("Choose option: ");
        switch (Console.ReadLine())
        {
            case "1":
                Console.Clear();
                studentController.ShowAllStudents();
                Message.EndOfProcess();
                break;
            case "2":
                Console.Clear();
                ResultsController.ShowAllResult(studentController.ResultsList);
                Message.EndOfProcess();
                break;
            case "3":
                AddStudentFunc();
                break;
            case "4":
                DeleteStudentFunc();
                break;
            case "5":
                Console.Clear();
                categoryController.ShowAll();
                Message.EndOfProcess();
                break;
            case "6":
                AddCategoryFunc();
                break;
            case "7":
                DeleteCategoryFunc();
                break;
            case "8":
                ShowAllQuestion();
                break;
            case "9":
                AddQuestionFunc();
                break;
            case "10":
                DeleteQuestionFunc();
                break;
            case "11":
                isContinue = false;
                break;
            default:
                Errors.NonexistentOptionError();
                break;
        }

    }

}

void AddStudentFunc()
{
     List<string> new_student_list =
        studentController.CreateStudent(categoryController.CategoriesList);
    if (new_student_list is not null)
    {
        studentController.Add(
            StudentController.ConvertToStudent(new_student_list));
        Message.NewStudentAdded();
    }
    else
    {
        Errors.MistakeError();
    }

};

void DeleteStudentFunc()
{
    Console.Clear();
    studentController.ShowAllStudents();

    Console.Write("Enter the id of student which you want to delete: ");
    dynamic delete_id = Console.ReadLine();
    if (!Patterns.RE_numeric.IsMatch(delete_id))
    {
        Errors.MistakeError();
        return;
    }
    else
    {
        delete_id = Convert.ToInt32(delete_id);
    }

    if (studentController.DeleteByID(delete_id))
    {
        Message.StudentDeleted();
    }
    else
    {
        Errors.StudentFindError();
    }
}

void AddCategoryFunc()
{
    Console.Clear();
    Console.Write("Enter new category name: ");
    string? category = Console.ReadLine();

    if (category != "") {
        categoryController.Add(new Category(category));
        Message.NewCategoryAdded();
    }
    else
    {
        Errors.MistakeError();
    }
}

void DeleteCategoryFunc()
{
    Console.Clear();
    categoryController.ShowAll();

    Console.Write("Enter the id of category which you want to delete: ");
    dynamic delete_id = Console.ReadLine();
    if (!Patterns.RE_numeric.IsMatch(delete_id))
    {
        Errors.MistakeError();
        return;
    }
    else
    {
        delete_id = Convert.ToInt32(delete_id);
    }

    if (categoryController.Delete(delete_id))
    {
        Message.CategoryDeleted();
    }
    else
    {
        Errors.CategoryFindError();
    }
}

void ShowAllQuestion()
{
    Console.Clear();
    categoryController.ShowAll();
    Console.Write($"Choose category: ");
    dynamic? choosen_category = Console.ReadLine();

    if (!Patterns.RE_numeric.IsMatch(choosen_category))
    {
        Errors.NonexistentOptionError();
        return;
    }
    else
    {
        choosen_category = Convert.ToInt32(choosen_category);
    }

    Category current_category = categoryController.GetCategotyByID(choosen_category);
    if (current_category is null) 
    {
        Errors.CategoryFindError();
        return;
    }
    else
    {
        Console.Clear();
        QuestionController.ShowAll(current_category);
        Message.EndOfProcess();
    }
}

void AddQuestionFunc()
{
    Console.Clear();
    categoryController.ShowAll();
    Console.Write($"Choose category: ");
    dynamic? choosen_category = Console.ReadLine();

    if (!Patterns.RE_numeric.IsMatch(choosen_category))
    {
        Errors.NonexistentOptionError();
        return;
    }
    else
    {
        choosen_category = Convert.ToInt32(choosen_category);
    }

    Category current_category = categoryController.GetCategotyByID(choosen_category);
    if (current_category is null)
    {
        Errors.CategoryFindError();
        return;
    }
    else
    {
        Question? new_quetion = QuestionController.Create();
        if (new_quetion is null)
        {
            Errors.MistakeError();
            return;
        }
        else
        {
            current_category.QuestionList.Add(new_quetion);
            Message.NewQuestionAdded();
        }
    }
}

void DeleteQuestionFunc()
{
    Console.Clear();
    categoryController.ShowAll();
    Console.Write($"Choose category: ");
    dynamic? choosen_category = Console.ReadLine();

    if (!Patterns.RE_numeric.IsMatch(choosen_category))
    {
        Errors.NonexistentOptionError();
        return;
    }
    else
    {
        choosen_category = Convert.ToInt32(choosen_category);
    }

    Category current_category = categoryController.GetCategotyByID(choosen_category);
    if (current_category is null)
    {
        Errors.CategoryFindError();
        return;
    }
    else
    {
        Console.Clear();
        QuestionController.ShowAll(current_category);

        Console.Write("Enter the id of question which you want to delete: ");
        dynamic delete_id = Console.ReadLine();
        if (!Patterns.RE_numeric.IsMatch(delete_id))
        {
            Errors.MistakeError();
            return;
        }
        else
        {
            delete_id = Convert.ToInt32(delete_id);
        }

        if (QuestionController.Delete(current_category, delete_id))
        {
            Message.QuestiionDeleted();
        }
        else
        {
            Errors.QuestionFindError();
        }
    }
}

void LogginInAsStudent(Student current_student)
{
    Message.ExamStarted();

    bool isContinue = true;

    List<Question> question_list = categoryController.GetQuestionsByCategoryID(current_student.Category);

    // Shuffle quetions in randow way
    RandomGenerator<Question>.ShuffleList(ref question_list);

    // for statics
    int counter = 0;
    int right_answers = 0;
    int wrong_answers = 0;

    if (question_list.Count == 0)
    {
        Console.WriteLine("Something went wrong. Try again later!");
        return;
    }

    while (isContinue)
    {
        if (counter >= question_list.Count)
        {
            isContinue = false;
            break;
        }

        Console.Clear();
        Console.WriteLine(
            $"Student: {current_student.Name} {current_student.Surname}\n" +
            $"Subject: {categoryController.GetCategotyByID(current_student.Category).Name}\n" +
            $"Remaining questions: {question_list.Count - counter}\n" +
            $"========================================");

        Question current_question = question_list[counter];
        current_question.ShowQuestion();

        Console.Write("Enter answer or 0 for finish: ");

        dynamic? choosen_answer = Console.ReadLine();

        if (!Patterns.RE_numeric.IsMatch(choosen_answer))
        {
            Errors.NonexistentOptionError();
            continue;
        }

        choosen_answer = Convert.ToInt32(choosen_answer);

        if (choosen_answer == 0) 
        {
            isContinue = false;
            break;
        }

        if (current_question.Answers.Count < choosen_answer)
        {
            Errors.MistakeError();
            continue;
        }

        // Minus -1 becase answesr count start from 1
        choosen_answer--;

        if (choosen_answer == current_question.RightAnswerID)
        {
            right_answers++;
        }
        else
        {
            wrong_answers++;
        }

        counter++;
    }

    Result new_result = new(
        current_student.Name,
        current_student.Surname,
        current_student.Login,
        right_answers,
        wrong_answers,
        question_list.Count,
        question_list.Count - counter); ;

    // Add redult and delete student from lis

    string category_name = categoryController.GetCategotyByID(current_student.Category).Name;


    studentController.ResultsList.Add(new_result);

    string new_file_name =
        current_student.Name + " " + current_student.Surname
        + DateTime.Now.ToString(" dd MMM yyy HH-mm")
        + ".txt";

    FileStream fileStream = new FileStream(
        students_result_path + new_file_name, FileMode.Create);
    fileStream.Close();

    using (StreamWriter sw = new(students_result_path + new_file_name))
    {
        sw.WriteLine(Message.GetResultsText(new_result, category_name));
    }

    Message.ExamFinised(new_result,category_name);

    studentController.DeleteByID(current_student.ID);

}



void _create_default_Admins()
{
    adminController.Add(new Admin("Amdin", "Adminov", "admin@gmail.com", "1234"));
    adminController.Add(new Admin("Elvin", "Cavadov", "e@m.com", "1234"));
}

void _create_default_neccessary_files()
{
    if (!File.Exists(main_path + student_path))
    {
        FileStream fileStream = new FileStream(main_path + student_path, FileMode.Create);
        fileStream.Close();
    }

    if (!File.Exists(main_path + category_path))
    {
        FileStream fileStream = new FileStream(main_path + category_path, FileMode.Create);
        fileStream.Close();
    }

    if (!File.Exists(main_path + results_path))
    {
        FileStream fileStream = new FileStream(main_path + results_path, FileMode.Create);
        fileStream.Close();
    }
}

void Quit()
{
    FileServices<Student>.SaveData(studentController.StudentList.ToList(), main_path + student_path);
    FileServices<Category>.SaveData(categoryController.CategoriesList.ToList(), main_path + category_path);
    FileServices<Result>.SaveData(studentController.ResultsList.ToList(), main_path + results_path);

}