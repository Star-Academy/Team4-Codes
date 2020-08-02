import java.io.File;
import java.util.*;

public class Main {
    static Map<String, InvertedIndex> invertedIndex = new HashMap<>();

    static InvertedIndex allTokens = new InvertedIndex();

    public static void main(String[] args) {
        //pre process

        allTokens.fillMap();

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
        int i = 0;
        for (String keyword : mustBe) {
            if (allTokens.getTokens().containsKey(keyword)) {
                if (i == 0) {
                    output.addAll(allTokens.getTokens().get(keyword));
                } else {
                    output.retainAll(allTokens.getTokens().get(keyword));
                }
                i++;
            }
        }
        for (String keyword : shouldBe) {
            if (allTokens.getTokens().containsKey(keyword)) {
                output.addAll(allTokens.getTokens().get(keyword));
            }
        }
        for (String keyword : mustNotToBe) {
            if (allTokens.getTokens().containsKey(keyword)) {
                output.removeAll(allTokens.getTokens().get(keyword));
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
