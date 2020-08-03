import java.util.*;
public class OutputCalculator {
    ArrayList<String> shouldBe;
    ArrayList<String> mustBe;
    ArrayList<String> mustNotToBe;
    Set<String> output;
    InvertedIndex allTokens;
    
    //init defaults
    OutputCalculator(InvertedIndex allTokens){
        shouldBe = new ArrayList<String>();
        mustBe = new ArrayList<String>();
        mustNotToBe = new ArrayList<String>();
        output = new HashSet<String>();
        this.allTokens = allTokens;
    }

    //pre processing for calculating
    public void processKeywords(String[] keywords){
        for (String keyword : keywords) {
            if (keyword.startsWith("+")) { //plus sign handled
                keyword = keyword.substring(1);
                shouldBe.add(keyword);
            } else if (keyword.startsWith("-")) { //minus sign handled
                keyword = keyword.substring(1);
                mustNotToBe.add(keyword);
            } else { //no sign handled
                mustBe.add(keyword);
            }
        }
    }

    //check if toke's map contains the keyword
    public boolean isContainKey (String keyword, InvertedIndex allTokens){
        return allTokens.getTokens().containsKey(keyword);
    } 

    public Set<String> returnOutput(String[] keywords){
        
        processKeywords(keywords);
        
        noSignHandling();
        
        plusSignHandling();
        
        minusSignHandling();

        return output;
    }

    public void noSignHandling(){
        boolean isFirstTime = true;
        for (String keyword : mustBe) {
            if (isContainKey(keyword, allTokens)) {
                if (isFirstTime) { //if it's firs time we just add it after that gonna retain it all
                    output.addAll(allTokens.getTokens().get(keyword));
                    isFirstTime = false;
                } else {
                    output.retainAll(allTokens.getTokens().get(keyword)); //retaining
                }
            }
        }
    }
    public void plusSignHandling(){
        for (String keyword : shouldBe) {
            if (isContainKey(keyword, allTokens)) {
                output.addAll(allTokens.getTokens().get(keyword)); //adding to output
            }
        }
    }
    public void minusSignHandling(){
        for (String keyword : mustNotToBe) {
            if (isContainKey(keyword, allTokens)) {
                output.removeAll(allTokens.getTokens().get(keyword)); //removing from output
            }
        }
    }

}