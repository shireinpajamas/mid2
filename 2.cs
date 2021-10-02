using System;
using System.Collections.Generic;
public class Book{//จัดเก็บหนังสือเป็น list
	public string Id;
	public string Name;
	
	public List<Book> id = new List<Book>(){
	new Book{Id = "1",Name = "NOW I UNDERSTAND"},
	new Book{Id = "2",Name = "REVOLUTIONARY WEALTH"},
	new Book{Id = "3",Name = "Six Degrees"},
	new Book{Id = "4",Name = "Les Vacances"}	
	};
	
}
public class User
{
		
		//field
		public string Name{get; set;}
		public string Id{get; set;}
		public string Password{get; set;}
		public int type{get; set;}
		//Constructor
		public User(){
			Name = "";
			Id = "";
			Password = "";	
		}
		public User(string Name,string Id,string Password){
			Name = this.Name;
			Id = this.Id;
			Password = this.Password;
		}
		//behavior

		public void print_name_Id(){
			Console.WriteLine("Name: {0}",Name);
			Console.WriteLine("Employee ID: {0}",Id);	
		}
		
}
public class Student : User
{
	// Type 1 = Student, 2
	private int user_type = 1;
	
	public Student(){}
	public Student(string Name,string Id,string Password): base(Name,Id,Password){base.type = user_type;}
	
	public void Register_id(){
	Console.Write("Student ID: ");
	base.Id = Console.ReadLine();
	}
}
public class Employee : User
{
	// Type 1 = Student, 2
	private int user_type = 2;
	
	public Employee(){}
	public Employee(string Name,string Id,string Password): base(Name,Id,Password){base.type = user_type;}
	
	public void Register_id(){
	Console.Write("Employee ID: ");
	base.Id = Console.ReadLine();
	}
	
}

public class Program
{
	
	public void Main()
	{
		menu();	
	}
	void print_booklist(){//แสดงรายการหนังสือ หนังสือน้อยเลยไม่ได้ไล่จาก list
		Console.Write("Book List\n---------\nBook ID: 1\nBook name: NOW I UNDERSTAND\nBook ID: 2\nBook name: REVOLUTIONARY WEALTH\nBook ID: 3\nBook name: Six Degrees\nBook ID: 4\nBook name: Les Vacances");
	}
	void menu(){
		//แสดงหน้าเมนูและให้เลือกเมนู
		int menu_index;
		Console.Clear();
		Console.Write("Welcome to Digital Library \n--------------------------\n1. Login\n2. Register\nSelect Menu: ");
		menu_index = Int32.Parse(Console.ReadLine());
		switch(menu_index){
			case 1:
				login();
				break;
			case 2:
				register();
				break;
			default:
				menu();
				break;
		}
	}
	void register(){
		//สมัครเก็บไว้ที่ตัวแปรและส่งขึ้นคลาส
		var user = new User();
			string name,password;
			Console.Write("Register new Person\n-------------------\n");
			Console.Write("Input name: ");
			name = Console.ReadLine();
			Console.Write("Input Password: ");
			password = Console.ReadLine();
			user.Name = name;
			user.Password = password;
		//แยกหน้าสมัคร
		int type; 
		Console.Write("Input User Type 1 = Student, 2 = Employee: ");
		type = Int32.Parse(Console.ReadLine());
		switch(type){
			case 2:
				var emp = new Employee();
				emp.Register_id();
				menu();
				break;
			case 1:
				var stu = new Student();
				stu.Register_id();
				menu();
				break;
			default:
				menu();
				break;
		}
			
	}
	void login(){
		//หน้า login
		var user = new User();
		string input_name,input_password;
		Console.Clear();
		Console.Write("Login Screen\n------------\n");
		Console.Write("Input name: ");
		input_name = Console.ReadLine();
		Console.Write("Input Password: ");
		input_password = Console.ReadLine();
		if(input_name == user.Name&&input_password == user.Password){
			switch(user.type){
			case 1:
				Console.Write("Employee Management\n-------------------");
				user.print_name_Id();
				Console.WriteLine("-------------------");
				Console.Write("1. Get List Books\nInput Menu: ");
				Console.ReadLine();	
				print_booklist();	
				break;
			case 2:
				Console.Write("Student Management\n-------------------");
				user.print_name_Id();
				Console.WriteLine("-------------------");
				Console.Write("1. Borrow Books\nInput Menu: ");
				Console.ReadLine();
				print_booklist();	
				break;
			default:
				Console.WriteLine("wrong type");
				break;
		}
		}
		else{
			Console.WriteLine("wrong ID or Password");
			Console.WriteLine(user.Name + " " + user.Password);
		}
	}
	
	
	void borrow(){
		//จัดการหนังสือของนักเรียน
    Book book = new Book();		
	var stu_book =  new List<Book>();	
	var user = new User();
	var stu = new Student();
	string book_index ="";	
	Console.Write("Input book ID: ");
	book_index = Console.ReadLine();
	if(book_index!="exit"){
		//เอาหนังสือเข้า list
	switch(book_index){
		case "1":
			stu_book.Add(book.id[1]);
			break;
		case "2":
			stu_book.Add(book.id[2]);
			break;
		case "3":
			stu_book.Add(book.id[3]);
			break;
		case "4":
			stu_book.Add(book.id[4]);
			break;
		default:
			borrow();
			break;
	}
	}
		else{
			user.print_name_Id();
			foreach(var sb in stu_book)
			Console.Write("Book ID: "+ book.Id + "\n"+"Book name " + book.Name+"\n");
		}
	}
	
}


