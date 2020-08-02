import java.io.File;
import java.util.*;

public class Main {
    static Map<String, InvertedIndex> invertedIndex = new HashMap<>();


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
        String keyLine = sc.nextLine();
        keyLine = keyLine.toLowerCase();
        String[] keyWords = keyLine.split(" ");

        ArrayList<String> shouldBe = new ArrayList<String>();
        ArrayList<String> mustBe = new ArrayList<String>();
        ArrayList<String> mustNotToBe = new ArrayList<String>();
        for (String keyword : keyWords) {
            if (keyword.startsWith("+")) {
                keyword = keyword.substring(1);
                shouldBe.add(keyword);
            } else if (keyword.startsWith("-")) {
                keyword = keyword.substring(1);
                mustNotToBe.add(keyword);
            } else {
                mustBe.add(keyword);
            }
        }
        Set<String> output = new HashSet<String>();
        for (String keyword : shouldBe) {
            if (invertedIndex.containsKey(keyword)) {
                output.addAll(invertedIndex.get(keyword).getToken());
            }
        }
        int i = 0;
        for (String keyword : mustBe) {

            if (invertedIndex.containsKey(keyword)) {
                if (i == 0) {
                    output.addAll(invertedIndex.get(keyword).getToken());
                } else {
                    output.retainAll(invertedIndex.get(keyword).getToken());
                }
            }
            i++;
        }
        for (String keyword : mustNotToBe) {
            if (invertedIndex.containsKey(keyword)) {
                output.removeAll(invertedIndex.get(keyword).getToken());
            }
        }
        if (output.size() != 0) {
            for (String a : output) {
                System.out.print(a + " ");
            }
        } else {
            System.out.println("no result found");
        }

    }
}
