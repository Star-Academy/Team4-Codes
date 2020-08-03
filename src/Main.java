import java.util.*;

public class Main {


    public static void main(String[] args) {
        //driver code
        
        InvertedIndex allTokens = new InvertedIndex();
        allTokens.fillMap(); //put all words and their respective docs in the reversed index map
        
        //input
        System.out.println("Enter word to search");
        Scanner sc = new Scanner(System.in);
        String keyLine = sc.nextLine();
        keyLine = keyLine.toLowerCase();
        String[] keywords = keyLine.split(" ");

        //calculate final output based on user's input (signs handled)
        OutputCalculator co = new OutputCalculator(allTokens);
        Set<String> output = co.returnOutput(keywords);
        
        //output
        if (output.size() != 0) {
            for (String a : output) {
                System.out.print(a + " ");
            }
        } else {
            System.out.println("no result found");
        }

    }
}
