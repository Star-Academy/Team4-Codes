import java.util.*;
public class CalculateOutput {
    String[] keywords;
    ArrayList<String> shouldBe;
    ArrayList<String> mustBe;
    ArrayList<String> mustNotToBe;
    Set<String> output;
        
    CalculateOutput(String[] keywords){
        this.keywords = keywords;
        shouldBe = new ArrayList<String>();
        mustBe = new ArrayList<String>();
        mustNotToBe = new ArrayList<String>();
        output = new HashSet<String>();
    }

    public void processKeywords(){
        for (String keyword : keywords) {
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
    }

    public boolean isContainKey (String keyword, InvertedIndex allTokens){
        return allTokens.getTokens().containsKey(keyword);
    } 

    public Set<String> returnOutput(InvertedIndex allTokens){
        
        processKeywords();
        
        boolean isFirstTime = true;
        for (String keyword : mustBe) {
            if (isContainKey(keyword, allTokens)) {
                if (isFirstTime) {
                    output.addAll(allTokens.getTokens().get(keyword));
                    isFirstTime = false;
                } else {
                    output.retainAll(allTokens.getTokens().get(keyword));
                }
            }
        }
        for (String keyword : shouldBe) {
            if (isContainKey(keyword, allTokens)) {
                output.addAll(allTokens.getTokens().get(keyword));
            }
        }
        for (String keyword : mustNotToBe) {
            if (isContainKey(keyword, allTokens)) {
                output.removeAll(allTokens.getTokens().get(keyword));
            }
        }
        return output;
    }
}

