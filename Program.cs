using System;
namespace Program;
class Person{
    private string _name;
    private int _age;
    public string Name{get=>_name;set{
        if(value!=null && value!="" && value.Length <=32){
            _name=value;
        }else{
            throw new Exception("Invalid name!");
        }
    }}
    public int Age{get=>_age;set{
        if(value>0 && value <= 128){
            _age=value;
        }else{
            throw new Exception("invalid age!");
        }
    }}
    public Person(string name,int age){
        Name=name;
        Age=age;
    }
    public virtual void Print(){
        Console.WriteLine("My name is " + Name + ", My age is " + Age);
    }
}
class Student:Person{
    private int _year;
    private float _gpa;
    int Year{get=>_year;set{
        if(value >= 1 && value <=5){
            _year=value;
        }else{
            throw new Exception("wrong value! year should be between 1 and 5 ");
        }
    }}
    float Gpa{get=>_gpa;set{
        if(value>=0 && value<=4){
            _gpa=value;
        }else{
            throw new Exception("wrong value! gpa should be between 0 and 4");
        }
    }}
    public Student(string name,int age, int year,float gpa):base(name,age){
        Year=year;
        Gpa=gpa;
    }
    public override void Print(){
        Console.WriteLine("My name is " + Name + ", my age is " + Age + " and my gpa is " + Gpa);
    }
}
class Staff:Person{
    private double _salary;
    private int _joinyear;
    double Salary{get=>_salary;set{
        if(value>0 && value<=120000){
            _salary=value;
        }else{
            throw new Exception("invalid salary!");
        }
    }}
    int JoinYear{get=>_joinyear;set{
        if(value-(2022-Age)>21){
            _joinyear=value;
        }else{
            throw new Exception("invalid join year!");
        }
    }}
    public Staff(string name,int age,double salary,int joinyear):base(name,age){
        Salary=salary;
        JoinYear=joinyear;
    }
    public override void Print()
    {
        Console.WriteLine("My name is " + Name + ", my age is " + Age + " and my salary is " + Salary);
    }
}
class DataBase{
    int Index=0;
    Person[] People=new Person[50];
    public void addStudent(Student student){
        People[Index++]=student;
        student.Print();
    }
    public void addStaff(Staff staff){
        People[Index++]=staff;
        staff.Print();
    }
    public void addPerson(Person person){
        People[Index++]=person;
        person.Print();
    }
    public void printPeople(){
        for(int i = 0; i < Index;i++){
            People[i].Print();
        }
    }
}
class Task{
    public static void Main(){
        string name;
        int age,joinyear,year;
        int choice;
        float gpa;
        double salary;
        DataBase database=new DataBase();
        while(true){
            Console.WriteLine("1) Student \n 2) Staff \n 3) Person \n 4) Print all ");
            try{
                choice=Convert.ToInt32(Console.ReadLine());
                switch(choice){
                case 1:
                    Console.WriteLine("Enter the Student name : ");
                    name=Console.ReadLine();
                    try{
                        Console.WriteLine("Enter the Student age : ");
                        age=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the year : ");
                        year=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Student gpa : ");
                        gpa=float.Parse(Console.ReadLine());
                        try{
                            Student student=new Student(name,age,year,gpa);
                            database.addStudent(student);
                        }catch(Exception e){
                            Console.WriteLine(e.Message);
                        }
                    }catch{
                        Console.WriteLine("value should be number!");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the Staff name : ");
                    name=Console.ReadLine();
                    try{
                        Console.WriteLine("Enter the Staff age : ");
                        age=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the salary : ");
                        salary=Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the join year: ");
                        joinyear=Convert.ToInt32(Console.ReadLine());
                        try{
                            Staff staff=new Staff(name,age,salary,joinyear);
                            database.addStaff(staff);
                        }catch(Exception e){
                            Console.WriteLine(e.Message);
                    }
                    }catch{
                        Console.WriteLine("value should be number!");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the name : ");
                    name=Console.ReadLine();
                    try{
                        Console.WriteLine("Enter the age : ");
                        age=Convert.ToInt32(Console.ReadLine());
                        try{
                            Person person=new Person(name,age);
                            database.addPerson(person);
                        }catch(Exception e){
                            Console.WriteLine(e.Message);
                    }
                    }catch{
                        Console.WriteLine("value should be number!");
                    }
                    break;
                case 4:
                    database.printPeople();
                    break;
                default:
                    Console.WriteLine("value is not valid choose another value !");
                    break;
            }
            }catch{
                Console.WriteLine("choosen value should be number !");
            }
            
        }
    }
}