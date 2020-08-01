import java.io.File;
import java.util.*;

public class Main {
    static Map<String, Set<Integer>> invertedIndex = new HashMap<>();



    public static void main(String[] args) {
        //pre process
        File dir = new File("C:\\EnglishData");
        File[] directoryListing = dir.listFiles();
        if (directoryListing != null) {
            for (File child : directoryListing) {
                FileRead fr = new FileRead(child);
                fr.goThroughFile();
            }
        }

        System.out.println("Enter word to search");
        Scanner input = new Scanner(System.in);
        String keyWord = input.next();
        keyWord = keyWord.toLowerCase();
        for (Integer a : invertedIndex.get(keyWord)){
            System.out.print(a + " ");
        }

    }
}
