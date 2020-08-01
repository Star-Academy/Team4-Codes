import java.io.File;
import java.util.*;

public class Main {
    static ArrayList<FileRead> allFiles = new ArrayList<>();
    static Map<String, Set<Integer>> invertedIndex = new HashMap<>();



    public static void main(String[] args) {
    //pre process  
    File dir = new File("C:\\EnglishData");
    File[] directoryListing = dir.listFiles();
    if (directoryListing != null) {
      for (File child : directoryListing) {
        child.FileRead.goThroughFile();
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
