import java.io.File;
import java.util.*;

public class Main {


    public static void main(String[] args) {
        InvertedIndex allTokens = new InvertedIndex();
        allTokens.fillMap();

        System.out.println("Enter word to search");
        Scanner sc = new Scanner(System.in);
        String keyLine = sc.nextLine();
        keyLine = keyLine.toLowerCase();
        String[] keywords = keyLine.split(" ");

        CalculateOutput co = new CalculateOutput(keywords);
        Set<String> output = co.returnOutput(allTokens);
        if (output.size() != 0) {
            for (String a : output) {
                System.out.print(a + " ");
            }
        } else {
            System.out.println("no result found");
        }

    }
}
