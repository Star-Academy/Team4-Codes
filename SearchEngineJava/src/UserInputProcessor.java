import java.util.Scanner;

public class UserInputProcessor {

    String userScanner(){
        System.out.println("Enter word to search");
        Scanner sc = new Scanner(System.in);
        String keyLine = sc.nextLine();
        sc.close();
        return keyLine;
    }
    String[] inputFromUser(){
        String keyLine = userScanner();
        keyLine = keyLine.toLowerCase();
        return keyLine.split(" ");
    }
}
