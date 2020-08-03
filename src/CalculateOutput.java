import java.util.*;
public class CalculateOutput {
    ArrayList<String> shouldBe;
    ArrayList<String> mustBe;
    ArrayList<String> mustNotToBe;
    Set<String> output;
    
    //init defaults
    CalculateOutput(){
        shouldBe = new ArrayList<String>();
        mustBe = new ArrayList<String>();
        mustNotToBe = new ArrayList<String>();
        output = new HashSet<String>();
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

    public Set<String> returnOutput(InvertedIndex allTokens, String[] keywords){
        
        processKeywords(keywords);
        
        //no sign handling
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
        //plus sign handling
        for (String keyword : shouldBe) {
            if (isContainKey(keyword, allTokens)) {
                output.addAll(allTokens.getTokens().get(keyword)); //adding to output
            }
        }
        //minus sign handling
        for (String keyword : mustNotToBe) {
            if (isContainKey(keyword, allTokens)) {
                output.removeAll(allTokens.getTokens().get(keyword)); //removing from output
            }
        }
        return output;
    }
}

