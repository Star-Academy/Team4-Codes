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
                if (child.length() != 0) {
                    FileRead fr = new FileRead(child);
                    fr.goThroughFile();
                }
            }
        }

        System.out.println("Enter word to search");
        Scanner sc = new Scanner(System.in);
        String keyLine = sc.next();
        keyLine = keyLine.toLowerCase();
        String[] keyWords = keyLine.split(" ");
        ArrayList<String> shouldBe = new ArrayList<String>();
        ArrayList<String> mustBe = new ArrayList<String>();
        ArrayList<String> mustNotToBe = new ArrayList<String>();
        for(String keyword : keyWords){
            if(keyword.startsWith("+"))
                shouldBe.add(keyword);
            else if(keyword.startsWith("-"))
                mustNotToBe.add(keyword);
            else
                mustBe.add(keyword);
        }
        Set<Integer> output = new HashSet<Integer>();
        for(String keyword : shouldBe){
            output.addAll(invertedIndex.get(keyword));
        }
        for(String keyword : mustBe){
            output.retainAll(invertedIndex.get(keyword));
        }
        for(String keyword : mustNotToBe){
            output.removeAll(invertedIndex.get(keyword));
        }
        if (output.size()!=0) {
            for (Integer a : output) {
                System.out.print(a + " ");
            }
        }
        else {
            System.out.println("no result found");
        }

    }
}
