import java.io.File;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    static ArrayList<FileRead> allFiles = new ArrayList<>();


    public static InvertedIndex searchThroughFilesForKeyWord(String key){
        InvertedIndex newKey = new InvertedIndex(key);
        for (int i = 0; i < Main.allFiles.size(); i++) {
            FileRead fileRead = Main.allFiles.get(i);
            if (fileRead.containsWord(key)){
             newKey.addNewPosting(fileRead.getDocID());
            }
        }
        return newKey;
    }

    public static void main(String[] args) {
        Main.allFiles.add(new FileRead("C:\\invertedIndex\\57110"));
        Main.allFiles.add(new FileRead("C:\\invertedIndex\\58043"));
        Main.allFiles.add(new FileRead("C:\\invertedIndex\\58044"));
        Main.allFiles.add(new FileRead("C:\\invertedIndex\\58045"));

        System.out.println("Enter word to search");
        Scanner input = new Scanner(System.in);
        String keyWord = input.next();
        keyWord = keyWord.toLowerCase();
        InvertedIndex keyInvertedIndex = searchThroughFilesForKeyWord(keyWord);
        System.out.println(keyInvertedIndex);
    }
}
