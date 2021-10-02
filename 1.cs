using System;
using System.Collections.Generic;					
public class Program
{
	
	public static int word_index;
	
	public static void Main()
	{
	Menu();	
	}
	
	static void Menu(){
	    //สุ่มเลขแล้วใช้เป็นคำ และเขียนหน้าเมนู
		Random random = new Random();
		word_index = random.Next(1,3); //สุ่มเลข IDE ผมมันสุ่มแปลกเลยมาไว้ตรงนี้ ไม่ใช่เรื่อง seed นะผมก็ไม่รู้เหมือนกัน
		string Input_menu;
		Console.Write("Welcome to Hangman Game \n ---------------------------------------- \n 1. Play game \n 2. Exit \n Please Select Menu : ");
		Input_menu = Console.ReadLine();
		switch(Input_menu){
			case "1":
			Game();
			break;	
			case "2":
			Console.Clear();	
			break;
			default:
			Console.Clear();	
			break;	
		}
	}

	 public static void Game(){
	     //เอาเลขที่สุ่มมาโยงกับคำ 
		int score = 0,correct = 0;
		string word;
		bool re = true;
		int check_letter = 0,check_correct = 0; 
		var ans = new List<char>();
		
		//1 = “Tennis”, 2 = “Football”, 3 = “Badminton”
		switch(word_index){
			case 1:
			word = "tennis";
			check_letter = 5;	
			break;	
			case 2:
			word = "football";
			check_letter = 6;	
			break;
			case 3:
			word = "badminton";
			check_letter = 9;	
			break;
			default:
			word = "";	
			break;	
		}
		
		char[] letters = word.ToCharArray();
		//เอา string มาแยกเป็น char array ก่อน
		while(re){
				Console.Clear();
				Console.Write("Welcome to Hangman Game \n ---------------------------------------- \n ");
				Console.Write("Incorrect Score: {0} \n",score);
				
				//ใช้ foreach เขียนคำใน char arrayออกมาทีละตัว
				foreach(char i in letters){
				    //ถ้าตรงกับสักตัว ใน char array ให้เขียนตัวนั้น
					if(ans.Contains(i)){
						Console.Write(i);
					}
					//ถ้าไม่ตรงก็ให้เขียน _ แทน
					else{
					Console.Write("_");
					}
				}
			Console.WriteLine("\n");
			//ถ้าผิดมากกว่า 6 ครั้งให้ขึ้น game over และหยุดลูป
			if(score > 6 ){	
				Console.WriteLine("Game Over");
					re = false;
				}else if(check_correct >= check_letter){ //หรือถ้าตัวอักษรที่ทายถูกครบให้ขึ้น ํyouwinและหยุดลูป
				Console.WriteLine("Your win!!");	
					re = false;
				}
			Console.WriteLine("\n");	
			Console.WriteLine("Input letter alphabet: ");
			char letter = char.Parse(Console.ReadLine()); // รับค่าจากคีย์บอดและเปลี่ยนเป็น char เอาไปใส่ charที่สร้างไว้
			 if (word.Contains(letter.ToString())){  //ตรวจว่า char ที่พิมมาตรงกับตัวใน string มั้ย
						ans.Add(letter);//ตรงก็ใส่ใน list char ที่สร้างไว้แล้ว
						check_correct++; //บวกค่าเช็คถูกเอาไว้กันตัวซ่ำนับคะแนนพลาด
					}
			else {
				ans.Clear(); //ไม่ตรงก็ล้าง list 
				score++;//บวกคะแนนพลาด
				}
				
	}
	}
}

