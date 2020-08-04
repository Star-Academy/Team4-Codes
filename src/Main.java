import java.util.*;

public class Main {


    static String[] inputFromUser(){
        System.out.println("Enter word to search");
        Scanner sc = new Scanner(System.in);
        String keyLine = sc.nextLine();
        sc.close();
        keyLine = keyLine.toLowerCase();
        return keyLine.split(" ");
    }

    static void output(Set<String> output){
        if (output.size() != 0) {
            for (String a : output) {
                System.out.print(a + " ");
            }
        } else {
            System.out.println("no result found");
        }
    }

    public static void main(String[] args) {
        //driver code
        
        InvertedIndex allTokens = new InvertedIndex();
        allTokens.fillMap(); //put all words and their respective docs in the reversed index map
        
        String[] keywords = inputFromUser();

        //calculate final output based on user's input (signs handled)
        OutputCalculator co = new OutputCalculator(allTokens);
        Set<String> output = co.returnOutput(keywords);
        
        output(output);
    }
}
